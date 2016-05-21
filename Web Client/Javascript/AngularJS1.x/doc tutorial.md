##Markup: css on top, script at the bottom before </body>
https://stackoverflow.com/questions/436411/where-is-the-best-place-to-put-script-tags-in-html-markup

##IIFE

(function() {


})();

##module

###setter:

angular.module(‘app’, []);

###getter

angular.module(‘app’);

##Use promist $q instead of callbacks

##custom prefix for names: NO $, NO ng, NO ui

##Specify Dependencies order: built-in first
[$rootScope, $timeout, myDepend1, myDepend 2] 

##Module naming: "a.b" // b is a submodule of module a

##Controller: 


####No DOM manipulation bcos it's a VM, leave DOM manipulation to Directive.
No business Logic, leave that to Services

####Cross Controller Communication using $scope
// up the $scope
$scope.$emit('customEvent', data); 
// down the $scope
$scope.$broadcast('customEvent', data);
$scope.$on('customEvent', function() { ... });

// ??? you mean .broadcast ???
$rootScope.$emit('customEvent', data); 


####ControllerAs:

// Controller Instantiation in Route
module.config(function ($routeProvider) {
  $routeProvider
    .when('/route', {
      templateUrl: 'partials/template.html',
      controller: 'HomeCtrl',
      controllerAs: 'home’,
    });
});

function HomeCtrl() {
  this.bindingValue = 42;
}

// Controller function
m.controller(‘myCtrl’, function() {
	var vm = this;
	vm.prop = "";
});

if got warning from jshint regarding the var vm=this, try

* put comment /* jshint validthis: true */ above the line
* create a named function and use UpperCamelCase. As this convention means it is a constructor function.

// Controller Instantiation in View

<div ng-controller="HomeCtrl as home" >
{{home.prop}}
</div>

##Directive

lowerCamelCase

Use scope instead of $scope (DI) in link function

DOM manipulation here

###Create Isolated scope
m.directive(‘myDir’, function() {
	return {
		scope : {
		},
	};
});

###templating

Use Array.join('') for clean templating
m.directive(‘myDir’, function() {
	return {
		template : [
		'<div> class="...">',
		'<h1>...</h1>',
		'</div>'
		].join(''),
		
	};
});

###controllerAs

// Using directive
<div myDir attr1='val1' />

// Define Directive. 
m.directive(‘myDir’, function() {
	return {
		templateUrl : 'myDirTemplate.html'		
		scope : {
			// create new isolated scode properties based on attributes used by the directive at runtime
			attr1 : '='
		},
		controllerAs : 'vm',
		controller : function () {
			var vm = this;
			// create new properties for the isolated scope within controller
			vm.prop = '';
			
		},
		link : function(scope, element, attr, ctrl) {
			console.log(scope.vm.attr1);
			console.log(scope.vm.prop); 
		},
		// bind the outer scope to the directive's isolated scope
		bindToController = true
	};
});

// Template of Directive: myDirTemplate.html. 
// Use controller as 'vm'
// Using scope properties from controller & directive attribute
<div>
{{vm.attr1}}
{{vm.prop}}
</div>





### cleanup

Use $scope.$on('$destroy', fn) for cleaning up

Use $sce for untrusted content

##Filters

##Services

Business Logic here

###Factory
m.factory('myFac', myFac);


function myFac() {
	var f = { 
		prop : '',
		foo : function() { ... }
	};
	return f;
};

###Service
m.service('myService', myService);

function myService() {
	this.prop = '';
	this.foo = function() { ... };	
};

####Return the promise

return the promise of a data service to the calling function to support chaining to other data service

##Templates (View/PartialView)

Use ng-src, ng-href, ng-cloak

##Routing

Resolve Controller dependencies before the view is shown using $routeProvider, $stateProvider of ui-router

m.config($routeProvider) {
	$routeProvider
		.when('/', {
			templateUrl : 'xyz.html',
			controllerAs : 'vm',
			resolve : {
				// resolve here
			}
		});

};

Reference:

Google JavaScript Style Guide:
http://google-styleguide.googlecode.com/svn/trunk/javascriptguide.xml

Airbnb JavaScript Style Guide:
https://github.com/airbnb/javascript

##Documentation

jsDoc

##Minification

Use ng-annotate for Gulp to automate the DI in the form of string

##Named vs Anonymous Functions

* Much easier to debug
* More readable code

##Exception Handling

i know nothing ... need to learn the basic before the style guide

##Unit Test

* file suffix 'spec'. 
* Client code testing: place spec file side-by-side. e.g. product.controller.js next to product.controller.spec.js
* Server/Service code testing: place it in a separate 'test' folder



###Library
Jasmine or Mocha w/ Chai

###Runner
Karma

###Stub/Spy 
Sinon

###Headless Browser
PhantomJS

##Moularity

* 1 Application Root Module 'app'
* 1+ reusable modules e.g. exception handling 'app.exception', logging 'app.logger', diagnostics 'app.debug', security 'app.security', local data stashing
* 1+ app specific modules e.g. UI: layout 'app.layout', dashboard 'app.dashboard'. Business: customers 'app.customers', products 'app.products', shopping cart 'app.shoppingcart', admin 'app.admin'
* 3rd party modules. e.g. ui.router, ngAnimate, ngSanitize, etc...


##Code Analysis
JSHint

Alleviate globals for jshint rules. e.g. 
/* global sinon, describe, it, afterEach, beforeEach, expect, inject */

Use an Options File


##Vendor Globals
Inject vendor libraries globals behind constants.

Create a constants.js

/* globals moment:false */
(function(){
	'use strict';
	angular.module('app.core')
		.constant('moment', moment);
})();
