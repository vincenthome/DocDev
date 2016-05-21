(function () {
    'use strict';
    angular.module("myModule.controllers").controller("FirstCtrl", FirstCtrl);
    FirstCtrl.$inject = ['$location', '$http', '$timeout', '$log', '$resource'];
    /* jshint validthis: true */
    function FirstCtrl($location, $http, $timeout, $log, $resource) {
        var vm = this;
        vm.data = "waiting for action";

        vm.getAllRequest = function () {
            // Simple GET request example :
            $http.get("/api/values").
              success(function (data, status, headers, config) {
                  vm.data = data;
                  vm.status = 200;
              }).
              error(function (data, status, headers, config) {
                  $log.error(data);
                  vm.status = status;
              });
        };
        vm.getIdRequest = function () {
            // Simple GET request example :
            $http.get("/api/values/42").
              success(function (data, status, headers, config) {
                  vm.data = data;
                  vm.status = 200;
              }).
              error(function (data, status, headers, config) {
                  $log.error(data);
                  vm.status = status;
              });
        };
        vm.postRequest = function () {
            // Simple GET request example :
            $http.post("/api/values", "\"myData\"").
              success(function (data, status, headers, config) {
                  vm.data = data;
                  vm.status = 200;
              }).
              error(function (data, status, headers, config) {
                  $log.error(data);
                  vm.status = status;
              });
        };
        vm.putRequest = function () {
            // Simple GET request example :
            $http.put("/api/values/42", "\"myData\"").
              success(function (data, status, headers, config) {
                  vm.data = data;
                  vm.status = 200;
              }).
              error(function (data, status, headers, config) {
                  $log.error(data);
                  vm.status = status;
              });
        };
        vm.deleteRequest = function () {
            // Simple GET request example :
            $http.delete("/api/values/42").
              success(function (data, status, headers, config) {
                  vm.data = data;
                  vm.status = 200;
              }).
              error(function (data, status, headers, config) {
                  $log.error(data);
                  vm.status = status;
              });
        };

        var postData = {
            Title: "Fifty Shades of Grey",
            ReleaseDate: "2015-02-13T00:00:00",
            Genre: "Drama",
            Price: 15.99,
            Rating: "R",
            Stars: 5
        };

        var putData = {
            Title: "Ghostbusters ",
            ReleaseDate: "1984-03-13T00:00:00",
            Genre: "Comedy",
            Price: 2.99,
            Rating: "R",
            Stars: 5
        };

        vm.getComplexAllRequest = function () {
            // Simple GET request example :
            $http.get("/api/complextypevalues").
              success(function (data, status, headers, config) {
                  vm.data = data;
                  vm.status = 200;
              }).
              error(function (data, status, headers, config) {
                  $log.error(data);
                  vm.status = status;
              });
        };
        vm.getComplexIdRequest = function () {
            // Simple GET request example :
            $http.get("/api/complextypevalues/42").
              success(function (data, status, headers, config) {
                  vm.data = data;
                  vm.status = 200;
              }).
              error(function (data, status, headers, config) {
                  $log.error(data);
                  vm.status = status;
              });
        };
        vm.postComplexRequest = function () {
            // Simple GET request example :
            $http.post("/api/complextypevalues", postData).
              success(function (data, status, headers, config) {
                  vm.data = data;
                  vm.status = 200;
              }).
              error(function (data, status, headers, config) {
                  $log.error(data);
                  vm.status = status;
              });
        };
        vm.putComplexRequest = function () {
            // Simple GET request example :
            $http.put("/api/complextypevalues/42", putData).
              success(function (data, status, headers, config) {
                  vm.data = data;
                  vm.status = 200;
              }).
              error(function (data, status, headers, config) {
                  $log.error(data);
                  vm.status = status;
              });
        };
        vm.deleteComplexRequest = function () {
            // Simple GET request example :
            $http.delete("/api/complextypevalues/42").
              success(function (data, status, headers, config) {
                  vm.data = data;
                  vm.status = 200;
              }).
              error(function (data, status, headers, config) {
                  $log.error(data);
                  vm.status = status;
              });
        };


        // $resource methods
        var ComplexVal = $resource('/api/complextypevalues/:id', {},
            // Default $resource doesn't support 'PUT', need to add it MANUALLY!
            { 'update': { method: 'PUT' } });

        var postData = {
            Title: "Fifty Shades of Grey",
            ReleaseDate: "2015-02-13T00:00:00",
            Genre: "Drama",
            Price: 15.99,
            Rating: "R",
            Stars: 5
        };

        vm.getRESTComplexAllRequest = function () {
            // Simple GET request example :
            vm.data = ComplexVal.query(function () {
            });

        };
        vm.getRESTComplexIdRequest = function () {
            // Simple GET request example :
            vm.data = ComplexVal.get({ id: 42 }, function () {
            });
        };
        vm.postRESTComplexRequest = function () {
            // Simple GET request example :
            var newComplexVal = new ComplexVal(postData);
            newComplexVal.$save();
            vm.data = newComplexVal;
        };
        vm.putRESTComplexRequest = function () {
            vm.data.Price = 2.99;
            vm.data.$update({ id: 42 });

        };
        vm.deleteRESTComplexRequest = function () {
            vm.data.$delete({ id: 42 });
        };
    }
})();