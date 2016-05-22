# HttpClient.Angular
Using AngularJS $http / $resource to GET POST PUT &amp; DELETE


##$http

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

##$resource

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
