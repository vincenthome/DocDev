(function () {

    'use strict';

    angular.module('myModule', ['myModule.services', 'myModule.controllers', 'myModule.directives', 'ngResource']);
    angular.module('myModule.directives', []);
    angular.module('myModule.controllers', []);
    // ngResource - an external dependency
    angular.module('myModule.services', []);

}());
