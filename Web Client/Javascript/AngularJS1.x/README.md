##Angular Guide

- http://blogs.msdn.com/b/visualstudio/archive/2015/02/05/using-angularjs-in-visual-studio-2013.aspx
- https://github.com/jmbledsoe/angularjs-visualstudio-intellisense
- https://github.com/johnpapa/angularjs-styleguide

##AngularJS Learning:

- https://github.com/jmcunningham/AngularJS-Learning

##Angular Bootstrap

- [Angular.UI.Bootstrap](https://github.com/vincenthome/Angular.UI.Bootstrap)

TODO: 
* Combine Visual Studio Project Template wit angular-seed
* My template for repository service $resource -> MVC Web API
* My template for angular form, CRUD, validation, CSS, ng-messages, integrate with $resource
* sample form app : http://www.codeproject.com/Articles/576246/A-Shopping-Cart-Application-Built-with-AngularJS
* http://weblogs.asp.net/dwahlin/learning-angularjs-by-example-the-customer-manager-application
* http://www.sitepoint.com/creating-crud-app-minutes-angulars-resource/


##Directory Structure

```
.
├── app
│   ├── app.js
│   ├── common
│   │   ├── controllers
│   │   ├── directives
│   │   ├── filters
│   │   └── services
│   ├── home
│   │   ├── controllers
│   │   │   ├── FirstCtrl.js
│   │   │   └── SecondCtrl.js
│   │   ├── directives
│   │   │   └── directive1.js
│   │   │   └── directive1.html
│   │   │   └── directive1.less
│   │   ├── filters
│   │   │   ├── filter1.js
│   │   │   └── filter2.js
│   │   └── services
│   │       ├── service1.js
│   │       └── service2.js
│   └── about
│       ├── controllers
│       │   └── ThirdCtrl.js
│       ├── directives
│       │   ├── directive2.js
│       │   ├── directive2.html
│       │   ├── directive2.less
│       │   └── directive3.js
│       │   └── directive3.html
│       │   └── directive3.less
│       ├── filters
│       │   └── filter3.js
│       └── services
│           └── service3.js
├── assets
│   └── <static files>
├── common
│   └── <reusable code>
├── partials
│   └── <static files>
├── less
│   └── main.less
├── lib
│   ├── angular
│   ├── bootstrap
│   └── other verdors
├── test
│   └── <static files>
├── .bowerrc
├── .gitignore
├── bower.json
├── build.config.js
├── Gruntfile.js
├── Gulpfile.js
├── module.prefix
├── module.suffix
├── package.json
├── 
├── 
├── 
└── 
```

##Scripts - include these

angular.js,
angular-resource.js

##IIFE

```js
(function() {
	...
})();
```

##Module

[http://plnkr.co/edit/4SXUE088kGTBaF3fhCyM?p=preview](http://plnkr.co/edit/4SXUE088kGTBaF3fhCyM?p=preview)

###Define Module - setter

```js
var m = angular.module("myModule", [depends1, depends2, ...]);
```

###Instantiate Module - getter

```js
var m = angular.module("myModule");
```

```html
<html ng-app="myModule">
```
	
###Naming Convention

"myModule.subModule"

###Initialization

* The config method accepts a function, injected with "provider" and "constant" but you cannot inject "service" or "value".
* The run method accepts a function, injected with "service", "value" and "constant" but you cannot inject "providers" into run blocks.

#####Module OnLoad  

```js
m.config(function($routeProvider, myConstant) {
});
```

#####ALL modules loaded

```js
.run(function(myService, myConstant, myValue) {
});
```
    
#####Modularity - Guide Line

* 1 application root module 'myModule'
* 1+ reusable modules e.g. exception handling 'myModule.exception', 'myModule.logger', 'myModule.debug', 'myModule.security', local data stashing
* 1+ app specific modules e.g. UI: 'myModule.layout', 'myModule.dashboard', business: 'myModule.customers', 'myModule.products, 'myModule.shortcart', 'myModule.admin'
* 3rd party modules. e.g. ngAnimate, ngSanitize, etc...

Example:
```
(function () {
    'use strict';
    angular.module('myModule', ['myModule.services', 'myModule.controllers', 'myModule.directives']);
    angular.module('myModule.directives', []);
    angular.module('myModule.controllers', []);
    // ngResource - an external dependency
    angular.module('myModule.services', ['ngResource']);
})();
```

This will include ALL modules automatically:
```
<body ng-app="myModule">
```

##Dependencies Injection

####Specify Dependencies order: built-in first

```js
angular.module("myModule.controllers").controller("myCtrl", myCtrl);
myCtrl.$inject = ['$location', '$http', '$timeout', 'myDepend'];
function myCtrl($location, $http, $timeout, myDepend) { ... });
```

##Controller

###Define Controller

```js
myCtrl.$inject = ['$location', 'myDepend'];
function myCtrl($location, myDepend) {
    var vm = this;
    vm.prop = "";
    vm.myMethod() { ... }
});
```

###Using in 'module.controller'

```javascript
// if got warning from jshit regarding the var vm=this;, 
// try put comment /* jshint validthis: true */ above the line
// Implicity this points to $scope
/* jshint validthis: true */
angular.module("myModule.controllers").controller("myCtrl", myCtrl);
```

```html
<div ng-controller="myCtrl as vm">{{vm.prop}}</div>
```

###Using in 'module.config' $routeProvider

```js
angular.module("myModule.controllers").config(function($routeProvider) {
	$routeProvider
		.when('/route', {
			templateUrl : 'partials/template.html',
			controller : 'myCtrl',
			controllerAs : 'vm', // vm can be used inside template.html
			resolve : {
				// resolve dependency here before controller get instantiated
				dependencyName : function() { .... }
			}
		});
})

// how to DI $location??? Using $myCtrl.$inject
function myCtrl(dependencyName) {
    var vm = this;
    vm.prop = "";
    vm.myMethod() { ... }
}
```


###Using in Directive

```js
angular.module("myModule.directives").directive('myDir', ???);
```

###Eager Load Partial View

```js
angular.module("myModule.controllers").controller('myCtrl', function(..., $templateRequest) {
	$templateRequest('myXYZ.html')
});
```

##Binding

###one-time

[One-time/One-way/Two-way](http://plnkr.co/edit/zAZf2bCQdz1GIrsC2d1H?p=preview)

```html
{{ ::vm.prop }}

ng-repeat="name in ::vm.names"
```

###one-way

```html
{{ vm.prop }}

// to 'Escape'
<div ng-non-bindable > {{ ... }} </div>
```

###two-way

```html
<input/select/textarea  ng-model="" />
```

###ng-repeat

[http://plnkr.co/edit/8isF8jd5wKOpKbgx1WJF?p=preview](http://plnkr.co/edit/8isF8jd5wKOpKbgx1WJF?p=preview)

item/collection:

```html
<tr ng-repeat="item in items">
	<td>{{item.prop1}}</td>
```

Key/Value - For collection, key is the position. For object, key is the property name:

```html
<tr ng-repeat="(key, value) in item/items">
	<td>{{key}} = {{value}}</td>
```

property value/object:

```html
<tr ng-repeat="pv in item">
    <td>{{pv}}</td>
```

Built-in Variables:

```html
// $index, $first, $middle, $last, $even, $odd
<span ng-if="$first || $last">{{item.prop}}</span>
```

More: ng-repeat-start, ng-repeat-end.

##View

####ng-cloak - hide not yet processed {{ ... }}:

```html
Implicitly use CSS to hide elements.
<div ... ng-cloak> ... </div>
```

####ng-show/ng-hide:

[http://plnkr.co/edit/nK0dm5WZujRJiTriZqCA?p=preview](http://plnkr.co/edit/nK0dm5WZujRJiTriZqCA?p=preview)

```html
<div ng-hide="true/false" />
```

####ng-if: will REMOVE element

```html
<div ng-if="true/false" />
```

####ng-class (string/array/map syntax):

[http://plnkr.co/edit/xbP84IQAk7184OquFiRE?p=preview](http://plnkr.co/edit/xbP84IQAk7184OquFiRE?p=preview)

```html
<div ng-class="prop" />
```

#####String syntax:

```js
vm.prop = "class1";
```

######Array syntax:  

```js
vm.prop = ["class1", "class2", ...];
```

######Map object syntax:

```js
vm.prop = {
    // only truthy values will be added
	class1 : true,
	class2 : false,
	...
};
```

####ng-class-odd/ng-class-even:

```html
<tr ng-repeat="..." ng-class-even="prop1" ng-class-odd="prop2" > ... </tr>
```

####ng-href: replace href on 'a' element

Using Angular markup like {{hash}} in an href attribute will make the link go to the wrong URL if the user clicks it before Angular has a chance to replace the {{hash}} markup with its value. Until Angular replaces the markup the link will be broken and will most likely return a 404 error. The ngHref directive solves this problem.

```
The wrong way to write it:
<a href="http://www.gravatar.com/avatar/{{hash}}">link1</a>

The correct way to write it:
<a ng-href="http://www.gravatar.com/avatar/{{hash}}">link1</a>
```

####ng-src: replace src on 'img' element

Using Angular markup like {{hash}} in a src attribute doesn't work right: The browser will fetch from the URL with the literal text {{hash}} until Angular replaces the expression inside {{hash}}. The ngSrc directive solves this problem.

####ng-srcset: replace srcset on 'img' element

###Partial View:

####Ajax:

[http://plnkr.co/edit/nqQccUMHdFkRqWG19ltf?p=preview](http://plnkr.co/edit/nqQccUMHdFkRqWG19ltf?p=preview)

ng-include:

```html
<ng-include src="'partialview.html'" />
```

ng-include /w Dynamic Selection:    

```js
vm.selectView() = function() {
	return vm.selectedView;
};
```

```html
<ng-include src="selectView()" />

<div ng-include="selectView()" onload="foo()" />
```

ng-include event:

* $includeContentRequested
* $includeContentLoaded
* $includeContentError

```js
// The $on scope method ONLY available in $scope
$scope.$on('$includeContentLoaded', function(e, template) { 
	console.log('Loaded: ', template); // output the 'name' of the template
});
```

####Non-Ajax (embedded)

[http://plnkr.co/edit/1JLDVo2hZYXuYhbkl45N?p=preview](http://plnkr.co/edit/1JLDVo2hZYXuYhbkl45N?p=preview)

ng-switch/ng-switch-when/ng-switch-default - /w Dynamic Selection:

```html
<div ng-switch="vm.selectedView">
	<div ng-switch-when="caseValue1"> some html </div>
	<div ng-switch-when="caseValue2"> some other html </div>
	<div ng-switch-default> some other other html </div>
</div>
```

##View /w Route (ng-view / ng-Route)

Include 

* angular-route.js
* angular.moduel('...', ['ng-Route']); in module dependency 
   
Typically called inside the m.config  
Limitation: ng-view NO Nesting! Alternatives: ng-include.

```js
m.config(function($routeProvider, $locationProvider) {
	$locationProvider.html5Mode(true);
    $routeProvider.when("/myRoute", {
    	templateUrl : "/views/myRoute.html"
    });
    $routeProvider.otherwise({
    	templateUrl : "/views/notfound.html"
    });
};
```
   
```html
<ng-view />  
// navigation to /myroute
<a href="#/myroute" ...> Link ...  
http://.../app.html#/myroute
```

Reference: Listing 22-6

###Route Configuration

* controller - override the current <ng-view />'s controller
* templateUrl - view html file
* resolve - specify dependencies for injection - Listing 22-12

###Route Params

* conservative - 1 segment only. e.g. "/edit/:id"
* eager - as many segments as possible. e.g. "/edit/:id/:data*"

###$route Change Events

* routeChangeStart
* routeChangeSuccess
* routeChangeError
* routeUpdate

###$route management

* current
* routes
* reload()
      
```js
// Listing 22-10 - Accessing Route Parameter on Route Changed Event
m.controller("myCtrl", function(... $route, $routeParams, baseUrl) {
	$scope.$on("$routeChangeSuccess", function () { 
		if ($location.path().indexOf("/edit/") == 0) { 
			var id = $routeParams["id"]; 
			for (var i = 0; i < vm.products.length; i++) { 
				if (vm.products[i].id == id) { ... } 
});
```

##Filters - Built-in

[http://plnkr.co/edit/uofY6XEyscAtPT87X78c?p=preview](http://plnkr.co/edit/uofY6XEyscAtPT87X78c?p=preview)

Single Value

* | currency
* | number : #decimalplaces
* | date : "MM-dd-yyyy hh:mm-ss a"
* | uppercase/lowercase
* | json

Collection

* | limitTo : #ofitems / -#oflastitems
* | [filter : { propnameofitem/$/Object : value } / function(item) { ... return predicate; }](https://docs.angularjs.org/api/ng/filter/filter)
* [Example](http://plnkr.co/edit/VxNTlqfHsoh0rciKhQTy?p=preview) // '$' applies of ALL properties

*Sorting*

[orderBy](https://docs.angularjs.org/api/ng/filter/orderBy)

```html
{{ ... | orderBy: "prop1"/"-prop1" / function(item) { ... return value/object; }}
```

Multiple predicates

```html
{{ ... | orderBy : ["prop1", "prop2"] }}
```

*Custom Filter*

```js
m.filter("myFilter", ['depService', function(depService) {  
	return function(data, arg1, arg2, ...) {  
			//data: single or array  
	}
}]);
```
   
```html
{{ data.p1 | myFilter : 'param1'/myMethod1 : 'param2'/myMethod2 }}  
<div nt-repeat="i in data.p2 | myFilter : 'param1'/myMethod1 : 'param2'/myMethod2">  
```

Using Existing Filters in javascript:

```js
m.filter("myOtherFilter", ['$filter', function ($filter) { 
	$filter("myFilter")(param1, param2); 
}]);
```

##Filter 3rd Party  `$ bower install angular-filter`

[https://github.com/a8m/angular-filter](https://github.com/a8m/angular-filter)

##Events

* Click - ng-click/dblclick
* Submit - ng-submit
* Focus - ng-focus/ng-blur (gain / lose focus)
* Editing - ng-copy/cut/paste
* Mouse - ng-mousedown/up/enter/over/leave/move
* Key - ng-keydown/keyup/keypress 

$event parameter:

[https://docs.angularjs.org/guide/expression#-event-](https://docs.angularjs.org/guide/expression#-event-)

```js
$scope.myEvent = function(e) {
	e.type/e.x/e.y
};
```

```html
<div ng-mouseenter="myEvent($event)">Show Me</div>
```

##Form

[http://plnkr.co/edit/iHKFsUrtgtpb9qQwj7SN?p=preview](http://plnkr.co/edit/iHKFsUrtgtpb9qQwj7SN?p=preview)

* ng-disabled
* ng-readonly

###CheckBox

[http://plnkr.co/edit/r50c4epFu37XrspvqUKu?p=preview](http://plnkr.co/edit/r50c4epFu37XrspvqUKu?p=preview)

mapping 'myInput' to true/false:

* ng-true-value
* ng-false-value 

Numeric:    

```html
<input type="checkbox" ng-model="myInput" 
	ng-true-value="1" ng-false-value="0">Check Me</div>
```

String Value:

```html
<input type="checkbox" ng-model="myInput" 
	ng-true-value="'Yes'" ng-false-value="'False'">Check Me</div>
```

**Don't use** ng-checked, use ng-model instead:

```html
<input type="checkbox" ng-checked="true/false">Check Me</div>
```

###DropDown - Select

[http://plnkr.co/edit/mBeGw3thGhx5VA2PrwxH?p=preview](http://plnkr.co/edit/mBeGw3thGhx5VA2PrwxH?p=preview)

####Dynamic option items:

```js
vm.items = [
	{id: 100, prop1 : "a0", prop2 : "b0"},
	{id: 101, prop1 : "a1", prop2 : "b1"},
	{id: 102, prop1 : "a2", prop2 : "b2"}
];
vm.selectedValue = "";
```

Bind ng-model with item - displayed item property 'for'

```html
<select ng-model="selectedValue" ng-options="i.prop1 for i in items">
	<option value="">Pick One Below</option>
</select>
```

Bind ng-model with item' - selected item property 'as'

```html
<select ng-model="selectedValue" ng-options="i.id as i.prop1 for i in items">
	<option value="">Pick One Below</option>
</select>
```

Group By - will generate 'optgroup'

```html
<select ... ng-options="i.prop1 group by i.prop2 for i in items">
```

####Static option items:

ng-selected:

```html
<select ng-model="selectedValue">
    <option ... ng-selected="false">Pick 1</option>
    <option ... ng-selected="true">Pick 2</option>
    <option ... ng-selected="false">Pick 3</option>
```


###TextBox - 'input/textarea'

[http://plnkr.co/edit/go2aXnfTSiqw7ShRAqm3?p=preview](http://plnkr.co/edit/go2aXnfTSiqw7ShRAqm3?p=preview)

####event
ng-change: when input changed

#### helper
ng-trim: auto trim when set to true

####validators

[http://plnkr.co/edit/9E1aZGyzJCwuxFVg0sIf?p=preview](http://plnkr.co/edit/9E1aZGyzJCwuxFVg0sIf?p=preview)

* required // static
* ng-required // allows you to dynamically change it
* ng-minlength
* ng-maxlength
* ng-pattern // DO NOT use it on type="email/url/number". ng will overide it.

####writing to model
Implicitly created Model Property in html

```js
// requires checking in js side for existence of the implicitly created model
if(angular.isDefined(myImplicitProp)) {
}
```

###Date/Time 

```html 
<input type="date/time/datetime-local/month/week" />
```

####convert JSON to Date object

```js
vm.startDate = new Date(jsonfromservice)
```

###Details/Summary

ng-open:

```html
<details id="details" ng-open="true/false">
   <summary>Show/Hide me</summary>
</details>
```

###Binding Moment: ng-model-options

[http://plnkr.co/edit/KFeL5h7WcO8JU3a8Kvnx?p=preview](http://plnkr.co/edit/KFeL5h7WcO8JU3a8Kvnx?p=preview)

* updateOn : "blur"  // model update occur when object lose focus
* debounce : #msec // model update occur when stop typing for #msec
* [http://blog.thoughtram.io/angularjs/2014/10/19/exploring-angular-1.3-ng-model-options.html](http://blog.thoughtram.io/angularjs/2014/10/19/exploring-angular-1.3-ng-model-options.html)
* [http://www.yearofmoo.com/2014/09/taming-forms-in-angularjs-1-3.html#controlling-when-the-model-updates](http://www.yearofmoo.com/2014/09/taming-forms-in-angularjs-1-3.html#controlling-when-the-model-updates)

```html
// update the model property WHEN event 'blur'	
<input 
  type="text" 
  ng-model="vm.prop" 
  ng-model-options="{ updateOn: 'blur' }">

<input 
  type="search" 
  ng-model="vm.searchQuery" 
  ng-model-options="{debounce: 300}">

// this combination is broken:
  ng-model-options="{ updateOn: 'blur', debounce: { 'default': 300, 'blur': 0 } }"
```

###Rollback View Changes to initial pre-edit value in form/field level

??? don't understand how it works???

* myForm.$rollbackViewValue();
* control.$rollbackViewValue();
* [http://blog.thoughtram.io/angularjs/2014/10/19/exploring-angular-1.3-ng-model-options.html](http://blog.thoughtram.io/angularjs/2014/10/19/exploring-angular-1.3-ng-model-options.html)

####Field Level

```html
<input name="myInput" 
	ng-model-options="{updateOn : 'blur'}"
	ng-keyup="vm.cancelEntry(myForm.myInput, $event)" />
```

```js
vm.cancelEntry = function(control, event) {
	if(event.keyCode == 27)
		control.$rollbackViewValue();
}
```

####Form Level

```html
<form name="myForm" 
	ng-model-options="{updateOn : 'submit'}" 
	ng-submit="vm.submit" >
	
	<button ng-click="myForm.$rollbackViewValue()"Reset</button>
</form>
```

###Using getterSetter function in 2-way binding (rather then property)

[http://plnkr.co/edit/eXmMp32Xmb6SfDDdDm13?p=preview](http://plnkr.co/edit/eXmMp32Xmb6SfDDdDm13?p=preview)

```js
vm.myGetterSetterFunction : function(value) {
	if(angular.isDefined(value)) {
		myProp = value
	}
	return myProp;
}
```

```html
<input ng-model="vm.myGetterSetterFunction"
		ng-model-options="{ getterSetter : true }" ... />
```

##'Unsaved Changes' Prompt - $routeChangeStart event

```js
m.controller('myCtrl', function($scope, $rootScope) {
	$rootScope.$on('$routeChangeStart', 
		function(event, next, current) {
			if(!confirm('You have unsaved changes, continue or not?')) {
                // ignore route change request
				event.preventDefault();
			}
	});
});
```

##FormValidation

[https://docs.angularjs.org/api/ng/directive/input](https://docs.angularjs.org/api/ng/directive/input)

###Html

####<form>

**IMPORTANT!**
[https://docs.angularjs.org/api/ng/directive/form](https://docs.angularjs.org/api/ng/directive/form)

```html
<form name="myForm" ng-submit="mySubmit()" novalidate>
```

###View Model - Implicitly added to scope:

```js
<pre>
{{myForm | json}}  // could shows the following:
</pre>

{
  "$error": {
    "required": [ ]
  },
  "$error" : {}. // if no errors found, empty object literal 
  "$dirty": false,
  "$pristine": true,
  "$valid": false,
  "$invalid": true,
  "$submitted": false,
  "myInput": {
    "$validators": {},
    "$asyncValidators": {},

    "$pristine": true,
    "$dirty": false,
    "$valid": false,
    "$invalid": true,
    "$error": {
      "required": true, // if 'required' satisfy, this property won't exist
      "minlength": true,
      "maxlength": true,
      "pattern": true
    },
    "$error" : {} // if no errors found, empty object literal
  }
}
```


####Important object properties to check
```js
myForm
    .$error
    .$invalid
    .$dirty
    ...
    .myInput
        .$error
            .theValidator
            ...
```

###CSS class

####General

ngModel **AUTOMATICALLY** adds/removes these CSS classes to the immediate **form & control**. 

* .ng-valid: the model is valid
* .ng-invalid: the model is invalid
* .ng-valid-[key]: for each valid key added by $setValidity
* .ng-invalid-[key]: for each invalid key added by $setValidity
* .ng-pristine: the control hasn't been interacted with yet
* .ng-dirty: the control has been interacted with
* .ng-touched: the control has been blurred
* .ng-untouched: the control hasn't been blurred
* .ng-pending: any $asyncValidators are unfulfilled

**BUT YOU HAVE TO MANUALLY DEFINE THE CLASS** in your stylesheet like this:
```html
.ng-invalid.ng-touched {
background-color: #FA787E;
}
.ng-valid.ng-touched {
background-color: #78FA89;
}
```

**For non-immediate or non-form/non-control**, manually add/remove class like this:
```html
<div ng-class="myForm.$invalid ? 'ng-invalid' : 'ng-valid'">...</div>
```

####Validator specific

* .ng-valid-required
* .ng-valid-email
* .ng-invalid-required
* .ng-invalid-email
* etc...

angular will IMPLICITYLY set the input element with the above class(es):

```html
<input ... type="email" required ... >
```

Sample Usage:

```html
<input name="myInput" ... ng-required />
<button ng-disabled="myForm.$invalid">Ok</button>
```

###Reuse Validation Error Messages - local & remote messages

[http://plnkr.co/edit/GcAzaXwuX1I9rYLDF4Iz?p=preview](http://plnkr.co/edit/GcAzaXwuX1I9rYLDF4Iz?p=preview)

[http://blog.thoughtram.io/angularjs/2015/01/23/exploring-angular-1.3-ngMessages.html](http://blog.thoughtram.io/angularjs/2015/01/23/exploring-angular-1.3-ngMessages.html)

* bower install angular-messages
* Module Dependency - ['ngMessages']

#####Using it

```html
<form name="myForm" ... >

// ng-messages directive listens 'for' the input field's $error value
// then compare the changes 'when' specific validator failed - in correct order
// OPTIONAL 'ng-messages-multiple' attribute for display ALL messages at the same time

      <div class="form-group">
        <label for="myInputprop1">Input prop1 (ng-required="true" ng-minlength="3" ng-maxlength="5"):</label>
        <input ng-required="true" ng-minlength="3" ng-maxlength="5" ng-model="vm.prop1" name="myInputprop1" id="myInputprop1" type="text" class="form-control" />
        <div ng-messages="myForm.myInputprop1.$error" ng-messages-include="error-messages.html" style="color:red" >
          <div ng-message="required">Override Required Error Message</div>
        </div>
      </div>

```

```html
<!-- remote file: error-messages.html -->
<div ng-message="required">This field is required!</div>
<div ng-message="minlength">Your field is too short</div>
<div ng-message="maxlength">Your field is too long</div>
<div ng-message="email">Your field has an invalid email address</div>
```

####Don’t want to pollute the DOM, use this instead:
```
<ng-messages for="loginForm.password.$error">
  <ng-message when="required">...</ng-message>
  ...
</ng-messages>
```

###Custom $validators

When it comes to creating custom validators, we must first create a directive and then 'require' ng-model directive's controller. in order to register your custom validator into the ngModelController.$validators.

Each function in the $validators object receives the **modelValue** and the **viewValue** as parameters. It is executed every time an input is changed or whenever the bound model changes. Failed validators are stored by key in ngModelController.$error.

```js
var INTEGER_REGEXP = /^\-?\d+$/;
app.directive('integer', function() {
  return {
    // Ask for the ng-model directive's controller. 
    // As the 4th param of the link function
    require: 'ngModel',
    link: function(scope, elm, attrs, ctrl) {
      ctrl.$validators.integer = function(modelValue, viewValue) {
        if (ctrl.$isEmpty(modelValue)) {
          return true; // consider empty models to be valid
        }
        if (INTEGER_REGEXP.test(viewValue)) {
          return true;
        }
        return false; // it is invalid
      };
    }
  };
});
```

```html
<form name="form" class="css-form" novalidate>
Size: <input type="number" ng-model="size" name="size"
        integer />{{size}} // model updated ONLY when valid
        <span ng-show="form.size.$error.integer">Not a valid integer!</span>
</form>
```

###Custom $asyncValidators

todo:

Functions added to the $asyncValidators object instead of returning true or false, it returns a promise (valid is resolve, invalid is reject). In-progress async validations are stored by key in ngModelController.$pending. Asynchronous validations will NOT run unless all of the normal validators have passed.

#####Is the model and/or form still valid during validation? Or invalid?
Both the model and the form set the $valid and $invalid flags to undefined once 1+ asynchronous validators have been triggered and once ALL has been resolved, the $valid and $invalid flags will be restored based on the combined validity status of each of the asynchronous validators. During this time a special object called $pending will be set on both the model and the form to identify which asynchronous validations are ongoing. Once everything is complete then the pending object will be removed.

```js
app.directive('username', function($q, $timeout) {
  return {
    require: 'ngModel',
    link: function(scope, elm, attrs, ctrl) {
      ctrl.$asyncValidators.username = function(modelValue, viewValue) {
        return $q(function (resolve, reject) {
                    userService.checkValidity(viewValue).then(function () {
                        resolve();
                    }, function () {
                        reject();
            });
        });
      };
    };
  };
});
```

```html
<form name="form" class="css-form" novalidate>
    Username:
    <input type="text" ng-model="name" name="name" 
        username />{{name}}  // model updated ONLY when valid
    <span ng-show="form.name.$pending.username">
        Checking if this name is available...
    </span>
    <span ng-show="form.name.$error.username">
        This username is already taken!
    </span>
</form>
```

##Controller & Scope

###Support 1+ instances of controller/scope:

[The scope/VM is unique in multiple instances of same controller](http://plnkr.co/edit/xWKL0nGZxo4dQp0FATzv?p=preview)

```js
m.controller("myCtrl", ['$scope', function($scope) { ... }]);
```

```html
<div id="s1" ng-controller="myCtrl" ...>Section 1</div>
<div id="s2" ng-controller="myCtrl" ...>Section 2</div>
```

Each time applying ng-controller="myCtrl" will create a new instance of myCtrl and $scope. i.e. NO Singleton, NO Sharing 

>myCtrlObj1->$scopeObject1->myViewDiv1  
>myCtrlObj2->$scopeObject2->myViewDiv2

###Cross-Scope Communication

[http://plnkr.co/edit/ybbFtULyyia9R3sKCoCE?p=preview](http://plnkr.co/edit/ybbFtULyyia9R3sKCoCE?p=preview)

[http://toddmotto.com/all-about-angulars-emit-broadcast-on-publish-subscribing/](http://toddmotto.com/all-about-angulars-emit-broadcast-on-publish-subscribing/)

Scopes are organized in hierarchy, starting with $rootScope.

	$rootScope-- __$scope
				|__$scope

####Event Sent to descendants/ancestors

```js
m.controller("myCtrl", ['$rootScope', '$scope', function($rootScope, $scope) {
	$rootScope.$broadcast/
    $scope.$emit('eventId', { 
										prop1: val1, 
										prop2 : val2 
										});
}]);
```

####Event Received

Support both built-in event '$builtinEvent' & 'customEvent'

```js
m.controller("myCtrl", ['$scope', function($scope) {
	$scope.$on('eventId', function(event, args) {
							$scope.prop1 = args.prop1; 
						});
}]);
```

###Controller/Scope Inheritance

[http://plnkr.co/edit/4ZajubcQB7Siixlj2Y2G?p=preview](http://plnkr.co/edit/4ZajubcQB7Siixlj2Y2G?p=preview)

**MUST STILL USE $scope in both base and derived controller to share data! ControllerAs WON'T WORK!**

[Some analysis](http://stackoverflow.com/questions/26647460/accessing-inherited-scope-with-controller-as-approach)

**Trap: parent scope required an intermediary 'data' object to hold the base property. This prevents ng-model directive to implicitly override a property which it couldn't find in the current scope but in fact defined in the parent scope. Chapter 13.**

```js
m.controller("parentCtrl", ['$scope', function($scope) }
	$scope.data = {
		baseProp : "..."
	};
	$scope.baseMethod1 = function() { ... };
	$scope.baseMethod2 = function() { ... };
}]);

m.controller("child1Ctrl", ['$scope', function($scope) }
	$scope.childProp = "...";
	$scope.childMethodUsingBase = function() {
		 // use base property & base method
		var x = $scope.data.baseProp;
		$scope.baseMethod1(); 
	};
}]);

m.controller("child2Ctrl", ['$scope', function($scope) }
	// override base method
	$scope.baseMethod2 = function() { ... };
}]);
```

```html
<div ng-controller="parentCtrl">
	{{data.baseProp}} 
	{{baseMethod1/2()}}
	<div ng-controller="child1Ctrl">
		{{data.baseProp}} {{childProp}}
		{{baseMethod1()}}
		{{baseMethod2()}} 
		{{childMethodUsingBase()}}
	</div>
	<div ng-controller="child2Ctrl">
		{{data.baseProp}}
		{{baseMethod1()}}
		The Overriden: {{baseMethod2()}}  
	</div>
</div>
```

###Explicit Update Scope in other framework like jQuery

* $watchCollection

####jQuery -> Angular

ng use the 'id attribute' to get the '.element()' object, and then get its '.scope()' and then call '.$apply()' to invoke express 'foo()'

```js
$('myButton').button().click(function(e) {
	angular.element(idAttrib).scope().$apply('foo()');
});
```

####Angular -> jQuery

```js
vm.prop1 = val1;
$scope.$watch('prop1', function(newValue) {
	// when value of prop1 changed, this will be called
	// do something in other framework using the newValue
	$('#myButton').button({ disabled : !newValue });
});
```

##Directives

```html
ng-click="myMethod(i)"  
<ng-include src="'xyz.html'"></ng-include>
```

###Custom Directives - when need to manipulate the DOM

```js
m.directive("myDirective", ['depService', function(depService) {
	return {
		restrict : "A/E",
		scope : { // isolated scope and optionally built your directive API
			onewayAttrib : '@',
			twowayAttrib : '=',
			expresssionAttrib : '&'
		},
		templateUrl : "xyz.html", // inside the html, use {{myCtrl.prop}}
		template : [
			'<div class="...">',
			'<h1>{{myCtrl.prop}}</h1>',
			'</div>'
		].join(''), // cleaner way to build string
		controllerAs : 'myCtrl',
		controller : function() {
			// build your internal vm
			// Expose
			var vm = this;
			vm.prop = '...';
		},
		// allow bind to outer controller scope to directive's isolated scope
		bindToController :  true, 
		transclude : true,
		require : "^myOtherDirectiveController", // there are other prefix too
		link : function(scope, element, attrs, directiveController) {
			// customize your DOM, see sample function below
			// use link to interact with other directive's controller
		}
	};
}]);
```

```js
// sample function - Getting Data /w jqLite
var data = scope[attrs["myDirective"]];
var myProperty = attrs["myProperty"];
if(angular.isArray(data) {
	for(var i=0; i < data.length; i++)
		data[i][myProperty];
```

```js
// sample function - Generating Elements /w jqLite
var myProperty = attrs["myProperty"];
if(angular.isArray(data) {
	var newElement = angular.element("<ANY>");
	element.append(newElement);
	for(var i=0; i < data.length; i++)
		newElement.append(angular.element("<ANY2>").text(data[i][myProperty]));
}
```

```js
// passing and evaluate expression - my-property="prop1 | currency"
var myPropertyExpression = attrs["myProperty"];
...
for( ... )
	newElement.append(...).text(scope.$eval(myPropertyExpression, data[i])));
```

```js
// Watch Data Changes
var myPropertyExpression = attrs["myProperty"];
for( ... ) {
	scope.$watch(function(watchScope) {
					return watchScope.$eval(myPropertyExpression, data[i]);
				}, function (newValue, oldValue) {
					newElement.text(newValue);
				});
}
```

```html
// name got normalised  
<my-directive twoway-attrib="prop1" ... />  
<my-directive expression-attrib="some expression" ... />  
<ANY my-directive="..." twoway-attrib="prop1" />  
```

####bindToController

[http://blog.thoughtram.io/angularjs/2015/01/02/exploring-angular-1.3-bindToController.html](http://blog.thoughtram.io/angularjs/2015/01/02/exploring-angular-1.3-bindToController.html)

Allow access to containing controller's VM

####Transclude

transclude allows the inner contents of the html directive access to the scope OUTSIDE of the directive. i.e. inner disappear.

Best Practice: only use transclude : true when you want to create a directive that wraps arbitrary content.

Reference:

Creating a Directive that Wraps Other Elements section in - [https://docs.angularjs.org/guide/directive](https://docs.angularjs.org/guide/directive)

#####Example 1

```js
angular.module('docsTransclusionDirective', [])
.controller('Controller', ['$scope', function($scope) {
  $scope.name = 'Tobias';
}])
.directive('myDialog', function() {
  return {
    restrict: 'E',
    transclude: true,
    templateUrl: 'my-dialog.html'
  };
});
```

######Directive in Html

```html
<div ng-controller="Controller">
  <my-dialog>Check out the contents, {{name}}!</my-dialog>
</div>
```

#####Template Html - my-dialog.html

```html
<div class="alert" ng-transclude>
</div>
```

#####Example 2

Allow inner template to call outer scope expression

```js
angular.module('docsIsoFnBindExample', [])
.controller('Controller', ['$scope', '$timeout', function($scope, $timeout) {
  $scope.name = 'Tobias';
  $scope.message = '';
  $scope.hideDialog = function (message) {
    $scope.message = message;
    $scope.dialogIsHidden = true;
    $timeout(function () {
      $scope.message = '';
      $scope.dialogIsHidden = false;
    }, 2000);
  };
}])
.directive('myDialog', function() {
  return {
    restrict: 'E',
    transclude: true,
    scope: {
      'close': '&onClose'
    },
    templateUrl: 'my-dialog-close.html'
  };
});
```

######Directive in Html

```html
<div ng-controller="Controller">
  {{message}}
  <my-dialog ng-hide="dialogIsHidden" on-close="hideDialog(message)">
    Check out the contents, {{name}}!
  </my-dialog>
</div>
```

#####Template Html - my-dialog-close.html

```html
<div class="alert">
  <a href class="close" ng-click="close({message: 'closing for now'})">&times;</a>
  <div ng-transclude></div>
</div>
```

##Services Built-in

* $**anchorScroll** - scroll to an anchor
* $**animate**
* $compile
* $controller - instantiate controllers via $injector
* $document - a jqLite object that wraps window.document
* $exceptionHandler - 
* $filter - access to filters
* $**http** - Ajax requests
* $**injector** - create instances of ng components
* $interpolate - process binding expression to create content creation function
* $interval - wrapper around window.setInterval
* $**location** - browser location
* $**log** - global console
* $parse - parse expression to create content creation function
* $provide 
* $**q** - deferred objects / promise
* $**resource** - RESTFUL requests
* $rootElement - root element of DOM
* $**rootScope**
* $**route** - url segments info. update route
* $**routeParams** - url segments info
* $sanitize - sanitze html
* $sce - strict contextual escape unsafe html
* $swipe - support swipe gesture
* $timeout - wrapper around window.setTimeout
* $window - window of DOM

# Most Common #

##$http

[https://github.com/vincenthome/HttpClient.Angular](https://github.com/vincenthome/HttpClient.Angular)

Ajax requests and all methods returns a 'promise' object

```js
$http.get(url, [config])
$http.post(url, data, [config])
$http.delete(url, [config])
$http.put(url, data, [config])
$http.head(url, [config])
$http.jsonp(url, [config])    
	// the above returned promise object has methods below
	// which also returns promise object:
	.success(function(data) { ... })
	.error(function(error) { ... error.status/message ... })
	.then(function(resp) {
				resp.data
				resp.status 
				resp.headers("content-type")
				resp.config // request config object used
			}, 
		  function(error) { ... }, 
		  function(progress) { ... });
	.finally(function() { ... })
```

#####[config] object properties (Listing 20.7-8)

* data
* headers
* method
* params
* timeout
* transformRequest/Response
* url
* withCredentials

####$httpProvider object properties - default $http settings (Listing 20.9-10)

* default.headers.common/post/put
* default.transforRequest/Response
* interceptors
* withCredentials

todo:
##$resource

[https://github.com/vincenthome/HttpClient.Angular](https://github.com/vincenthome/HttpClient.Angular)

Include angular-resource.js, module dependency "ngResource"

```js
m.config(function($httpProvider) {
	$httpProvider.defaults.withCredentials = true;
});
```

```js
m.controller("myCtrl", function($scope, $resource) {
	// Current editing item
    $scope.editingItem = null;
    // Working on current editing item
    $scope.startEdit = function(item) { $scope.editingItem = item; };
    $scope.cancelEdit = function() {
        $scope.editingItem = null;
        // sometimes to 'restore' an item, you can:
        //$scope.editingItem.$get();
    };
	
    // 1st argument: create variable segment(s)
	// 2nd argument: itemId is a property of the data object
	$scope.myResource = $resource(url + ":id", { id : "@itemId" });
    
    // Working on '$resource' level
	$scope.listItems = function() {
		// myResource.query() returns an augmented 'wrapped' items
		$scope.items = $scope.myResource.query();	
		// optionally, to intercept the data using promise
		//$scope.items.$promise.then(function { ... } );
	};
	$scope.createItem = function(item) {
		// myResource(item) create a 'wrapped' item
		// ALL $resource methods returns promise object.
		// Here demonstrate using the promise returned by $save()
		new $scope.myResource(item).$save()
					.then(function(newItem) {
						$scope.items.push(newItem);
						$scope.editingItem = null;
					});
	};
    
    // Working on 'item' level
    $scope.updateItem = function(item) {
        // item is a 'wrapped' item
        item.$save();
        $scope.editingItem = null;
    };
	$scope.deleteItem = function(item) {
		// item is a 'wrapped' item
		item.$delete()
				.then(function() {
					$scope.items.splice($scope.items.indexof(item), 1);
				});
	};
    
    // run the $resource query
	$scope.listItems();
});
```

```html
<tr ng-repeat="i in items" ng-hide="i.id == editingItem.id">
	<td> {{i.name}} </td>
	<td>
		<button ng-click="startEdit(i)">Edit</button>
		<button ng-click="deleteItem(i)">Delete</button>
	</td>
</tr>
<tr>
	<td> <input ng-model="editingItem.name" required /> </td>
	<td>
		<button ng-hide="editingItem.id" ng-click="createItem(editingItem)">Create</button>
		<button ng-show="editingItem.id" ng-click="updateItem(editingItem)">Save</button>
		<button ng-show="editingItem" ng-click="cancelEdit()">Cancel</button>
	</td>   			
</tr>  
```

There is an alternative approach on Form Editing in Listing 21-14.

Avoid Async Data Trap: List 21-17

#####configuration (Listing 21-15):

```js
$scope.myResource = $resource(url + ":id", { id : "@itemId" }, { 
		create : { method: "POST", params : "" , url : "" , isArray : "" },
		save : { method: "PUT"} });
```

todo:
##$location????

```js
$location.path("/myRoute");
```

##$q

2 objects required by a 'promise':

* promise - receive notification
* deferred - send notification

#####$q methods:

* all(promises)
* defer()
* reject(reason)
* when(value)

#####deferred object members:

* resolve(result)
* reject(reason)
* notify(result)
* promise

###$log

**$log.log/warn/info/error/debug("...");**

[http://plnkr.co/edit/Mbo7cV9f24BanBOck2AI?p=preview](http://plnkr.co/edit/Mbo7cV9f24BanBOck2AI?p=preview)

##Services - Custom

[https://docs.angularjs.org/guide/providers](https://docs.angularjs.org/guide/providers)

###Factory - returns a Singleton 'Service Object'

[http://plnkr.co/edit/vPfT0qjvduKt6ugzRlHC?p=preview](http://plnkr.co/edit/vPfT0qjvduKt6ugzRlHC?p=preview)

```js
m.factory('myFactory', ['depService', function(depService) {
	var myPrivateField = "";
	// returns 'Service Object'
	return {
		foo: myPrivateField
	};
}]);
```

```js
// using it
m.controller("...", ['myFactory', function(..., myFactory) { myFactory.foo ... }]);
```

###Service - returns a Singleton 'Service Object'

Compare to .factory , .service will implicitly use 'new' to instantiate the service object. Allows use to optionally provide inheritance impl via prototype (Listing 18.9). Although, we can implement just like the .factory (Listing 18.10).

```js
m.service('myService', myService);

function myService() {
	this.prop = '';
	this.foo = function() { ... };
}

// using it
m.controller("...", ['myService', function(..., myService) { myService.foo ... }]);
```

###Provider - returns a Singleton 'Provider Object' & 'Service Object' (Listing 18.12-13)

```js
m.provider("myObj", ['depService', function(depService) {
	return {
		// providerMethod typically for configure the 'Service Object' inside m.config() 
		providerMethod1: function() { ... },
		providerMethod2: function() { ... },
		$get: function() {
			// returns 'Service Object'
			return {
				foo: ...
			};
		}
	};
}]);
```

```js
// using it. Add 'Provider' suffix to the name of the provider
m.config(['myObjProvider', function(myObjProvider) { 
	myObjProvider.providerMethod1().providerMethod2();
}]);
```

###Constant - can be used in .config()

[http://plnkr.co/edit/XPsI7M32ayvx53Ai5F5z?p=preview](http://plnkr.co/edit/XPsI7M32ayvx53Ai5F5z?p=preview)

```js
angular.module('myModule').constant("myConst", "xyz"/{ ... }); // map to value or object
```

###Value - CANNOT be used in .config()

[http://plnkr.co/edit/XPsI7M32ayvx53Ai5F5z?p=preview](http://plnkr.co/edit/XPsI7M32ayvx53Ai5F5z?p=preview)

```js
angular.module('myModule').value("myValue", "xyz"/{ ... }); // map to value or object
```

##Global Functions

todo:

* angular.bind(self, fn, args)
* angular.bootstrap(element[,modules])
* angular.copy(srcObj/Array, destObj/Array)
* angular.element(rawDOMElement)
* angular.equals(obj1, obj2)
* angular.extend(destObj, srcObj)
* angular.fromJson(jsonString)/toJson(obj)
* angular.forEach(obj, iterator[, context])
* angular.identity()
* angular.injector(modules)
* angular.isArray/Date/Defined/Element/Function/Number/Object/String/Undefined(value)
* angular.lower/uppercase(string)

##Scope Properties/Methods

todo:

* $root/$rootScope
* $parent
* $id
* $destroy([event])
* $apply(exp)
* $digest()
* $eval(expression)
* $evalAsync(expression)
* $new(isolate)

##jqLite

###Navigation/Query

element.

* children()
* next()
* parent()
* find("tagname")
* attr("name")
* css("name")
* hasClass("name")
* prop("name") // defined by the DOM API HTMLElement, often attr & prop are the same.
* text() // concatenated text content from all children
* val() // first element
 
elements.

* eq(i)
* 
```js
return function(scope, element, attrs) {
	var items = element.children(); // children	OR
	var items = element.find("li"); // descendants by tagname
	for(var i = 0; i < items.length; i++) {
		items.eq(i).text(...)
	}
	element.find("div")
};
```

###Update

* addClass("name")
* attr("name", val)
* css("name", val)
* prop("name", val) // prop defined by the DOM API HTMLElement
* removeAttr("name")
* removeClass("name")
* text(val) // all children
* toggleClass("name")
* val(val) // all children

###Create - table 15-5

* angular.element(html);
* after(elements)
* append(elements)
* clone()
* prepend(elements)
* wrap(elements) 

###Delete - table 15-5

* remove()
* replaceWith(elements)

```js
return function(scope, element, sttrs) {
	var listElem = angular.element("<ol>");
	element.append(listElem);
	for(var i = 0; i < scope.names.length; i++ {
		listElem.append(angular.element("<li>")
								.append(angular.element("<span>")
												.text(scope.names[i])))
	}
};
```

###Events

* on(events, handler)
* off(events, handler)
* triggerHandler(event)

###Others

* data(key, val)
* data(key)
* removeData(key)
* html()
* ready(handler)

###jqLite access ng

* controller
* controller(name)
* injector()
* isolatedScope()
* scope()
* inheritedData(key)

###Cleanup

use $scope.$on('$destroy', fn);

##Authentication /w Cookies

```js
$scope.authenticate = function(user, pass) {    
	$http.post(url, {
		username: user,
		password: pass 
	}, {
		withCredentials: true
	})
	.success(...)
	.error(...);
```

##Animation & Touch Chapter 23

##Unit Testing

##Documentation

jsDoc

##Minification

Try ng-annotate. Not sure if this work for Angular 2.0

##Exception Handler ???

##End-to-end test framework

Protractor

##Unit Test

* file suffix 'spec'
* Client code testing: place spec file side-by-side. 
* Server/Service code testing: place it in a separate 'test' folder

##Library

Jasmine or Mocha w/ Chai

##Runner

Karma

##Stub/Spy

Sinon

##Headless Browser

PhantomJS

##Code Analysis

* JSHint
* AngularHint

Alleviate globals for jshint rules. e.g. /* global sinon, describe, it, afterEach, beforeEach, expect, inject */

##Vendor Globals

Inject vendor libraries globals behind constants.

```js
//constants.js
function() {
	'use strict' ;
	angular.module('app.core')
		.constant('moment' moment);
}
```

##Url case sensitivity

```js
$routeProvider.caseInsensitiveMatch = true; // must be set BEFORE calling 'when'
$routeProvider.when(...)
```

##$anchorScroll - scoll will match the url

##ES6 Style Promises with $q

##Animation Lesson 052
https://www.youtube.com/playlist?list=PLDBBFaqYTcl9OQZCO_fBNrSR8TClHR9mz

##Testing Lesson 056
https://www.youtube.com/playlist?list=PLDBBFaqYTcl9OQZCO_fBNrSR8TClHR9mz

##Tips from YearOfMoo.com
[http://www.yearofmoo.com/2012/10/more-angularjs-magic-to-supercharge-your-webapp.html](http://www.yearofmoo.com/2012/10/more-angularjs-magic-to-supercharge-your-webapp.html)

##Sublime Text 3 package

* [https://packagecontrol.io/packages/AngularJS](https://packagecontrol.io/packages/AngularJS)
