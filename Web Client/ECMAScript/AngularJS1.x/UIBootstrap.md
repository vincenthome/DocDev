# Angular.UI.Bootstrap
Doc and Samples of Bootstrap components written in pure AngularJS by the AngularUI Team

#UIBootstrap by AngularUI
[https://angular-ui.github.io/bootstrap/#/top](https://angular-ui.github.io/bootstrap/#/top)

* [Accordion](https://angular-ui.github.io/bootstrap/#/accordion)
* [Alert](https://angular-ui.github.io/bootstrap/#/alert)
* [Buttons](https://angular-ui.github.io/bootstrap/#/buttons)
* [Carousel](https://angular-ui.github.io/bootstrap/#/carousel)
* [Collapse](https://angular-ui.github.io/bootstrap/#/collapse)
* [Datepicker](https://angular-ui.github.io/bootstrap/#/datepicker)
* [Dropdown](https://angular-ui.github.io/bootstrap/#/dropdown)
* [Modal](https://angular-ui.github.io/bootstrap/#/modal)
* [Pagination](https://angular-ui.github.io/bootstrap/#/pagination)
* [Popover](https://angular-ui.github.io/bootstrap/#/popover)
* [Progressbar](https://angular-ui.github.io/bootstrap/#/progressbar)
* [Rating](https://angular-ui.github.io/bootstrap/#/rating)
* [Tabs](https://angular-ui.github.io/bootstrap/#/tabs)
* [Timepicker](https://angular-ui.github.io/bootstrap/#/timepicker)
* [Tooltip](https://angular-ui.github.io/bootstrap/#/tooltip)
* [Typeahead](https://angular-ui.github.io/bootstrap/#/typeahead)

##Dependencies

* AngularJS 1.2.x
* Bootstrap CSS 3.1.1

##Install

* Download Button: [http://angular-ui.github.io/bootstrap](http://angular-ui.github.io/bootstrap)  
* bower install angular-bootstrap

##Get Started

```
angular.module('myModule', ['ui.bootstrap']);
```

##FAQ
[https://github.com/angular-ui/bootstrap/wiki/FAQ](https://github.com/angular-ui/bootstrap/wiki/FAQ)


##[Tabs](https://angular-ui.github.io/bootstrap/#/tabs)

[http://plnkr.co/edit/f7s7KaYEalnAS6vekD0E?p=preview](http://plnkr.co/edit/f7s7KaYEalnAS6vekD0E?p=preview)

* E: tabset A: vertical="true/false", type="tabs/pills", justified(tabset fills the parent)="true/false"
* E: tab A: heading="text", active="t/f", disabled="t/f", select="method", deselect="method"
```html
<body ng-app="ui.bootstrap.demo">
...
<!-- Combine Static and Dynamic tabs. Also demo select() event. -->
<tabset>
    <tab heading="Static title">Static content</tab>
    <tab ng-repeat="tab in tabs" heading="{{tab.title}}" active="tab.active" disabled="tab.disabled">
      {{tab.content}}
    </tab>
    <tab select="alertMe()">
      <tab-heading>
        <i class="glyphicon glyphicon-bell"></i> Alert!
      </tab-heading>
      I've got an HTML heading, and a select callback. Pretty cool!
    </tab>
  </tabset>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('TabsDemoCtrl', function ($scope, $window) {
  $scope.tabs = [
    { title:'Dynamic Title 1', content:'Dynamic content 1' },
    { title:'Dynamic Title 2', content:'Dynamic content 2', disabled: true }
  ];

  $scope.alertMe = function() {
    setTimeout(function() {
      $window.alert('You\'ve selected the alert tab!');
    });
  };
});
```

##[Dropdown](https://angular-ui.github.io/bootstrap/#/dropdown)

[http://plnkr.co/edit/HZFvz04Q51yId52vIcVc?p=preview](http://plnkr.co/edit/HZFvz04Q51yId52vIcVc?p=preview)

Don't confused this with Select/Option. Use this as a Container for Links!

* You can either use is-open to toggle or add inside a <a dropdown-toggle> element to toggle it when is clicked. There is also the on-toggle(open) optional expression fired when dropdown changes state
* E: a/button, A: dropdown-toggle
* E: span, A: dropdown, on-toggle="method"

```html
<body ng-app="ui.bootstrap.demo">
...
<div ng-controller="DropdownCtrl">
    <!-- Simple dropdown -->
    <span class="dropdown" dropdown on-toggle="toggled(open)">
      <a href class="dropdown-toggle" dropdown-toggle>
        Click me for a dropdown, yo!
      </a>
      <ul class="dropdown-menu">
        <li ng-repeat="choice in items">
          <a href>{{choice}}</a>
        </li>
      </ul>
    </span>
    <!-- Single button -->
    <div class="btn-group" dropdown is-open="status.isopen">
      <button type="button" class="btn btn-primary dropdown-toggle" dropdown-toggle ng-disabled="disabled">
        Button dropdown <span class="caret"></span>
      </button>
      <ul class="dropdown-menu" role="menu">
        <li><a href="#">Action</a></li>
        <li><a href="#">Another action</a></li>
        <li><a href="#">Something else here</a></li>
        <li class="divider"></li>
        <li><a href="#">Separated link</a></li>
      </ul>
    </div>
    <!-- Split button -->
    <div class="btn-group" dropdown>
      <button type="button" class="btn btn-danger">Action</button>
      <button type="button" class="btn btn-danger dropdown-toggle" dropdown-toggle>
        <span class="caret"></span>
        <span class="sr-only">Split button!</span>
      </button>
      <ul class="dropdown-menu" role="menu">
        <li><a href="#">Action</a></li>
        <li><a href="#">Another action</a></li>
        <li><a href="#">Something else here</a></li>
        <li class="divider"></li>
        <li><a href="#">Separated link</a></li>
      </ul>
    </div>
    <p>
        <!-- Programmatically open/close the dropdown -->
        <button type="button" class="btn btn-default btn-sm" ng-click="toggleDropdown($event)">Toggle button dropdown</button>
        <button type="button" class="btn btn-warning btn-sm" ng-click="disabled = !disabled">Enable/Disable</button>
    </p>

</div>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('DropdownCtrl', function ($scope, $log) {
  $scope.items = [
    'The first choice!',
    'And another choice for you.',
    'but wait! A third!'
  ];

  $scope.status = {
    isopen: false
  };

  $scope.toggled = function(open) {
    $log.log('Dropdown is now: ', open);
  };
  // Programmatically open/close the dropdown
  $scope.toggleDropdown = function($event) {
    $event.preventDefault();
    $event.stopPropagation();
    $scope.status.isopen = !$scope.status.isopen;
  };
});
```

##[Modal](https://angular-ui.github.io/bootstrap/#/modal)

[http://plnkr.co/edit/DdvIl7aUlezTDPDOS0DM?p=preview](http://plnkr.co/edit/DdvIl7aUlezTDPDOS0DM?p=preview)

* Creating custom modals: create a partial view, its controller and reference them when using the service.
* The **$modal** service has only one method: open(options) and plenty options.

```html
<body ng-app="ui.bootstrap.demo">
...
<div ng-controller="ModalDemoCtrl">
    <!-- Partial View Template -->
    <script type="text/ng-template" id="myModalContent.html">
        <div class="modal-header">
            <h3 class="modal-title">I am a modal!</h3>
        </div>
        <div class="modal-body">
            <ul>
                <li ng-repeat="item in items">
                    <a ng-click="selected.item = item">{{ item }}</a>
                </li>
            </ul>
            Selected: <b>{{ selected.item }}</b>
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" ng-click="ok()">OK</button>
            <button class="btn btn-warning" ng-click="cancel()">Cancel</button>
        </div>
    </script>

    <button class="btn btn-default" ng-click="open()">Open me!</button>
    <button class="btn btn-default" ng-click="open('lg')">Large modal</button>
    <button class="btn btn-default" ng-click="open('sm')">Small modal</button>
    <div ng-show="selected">Selection from a modal: {{ selected }}</div>
</div>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('ModalDemoCtrl', function ($scope, $modal, $log) {

  $scope.items = ['item1', 'item2', 'item3'];

  $scope.open = function (size) {

    var modalInstance = $modal.open({
      templateUrl: 'myModalContent.html',
      controller: 'ModalInstanceCtrl',
      size: size,
      resolve: {
        // pass into the custom modal's controller ctor
        items: function () {
          return $scope.items;
        }
      }
    });

    modalInstance.result.then(function (selectedItem) {
      $scope.selected = selectedItem;
    }, function () {
      $log.info('Modal dismissed at: ' + new Date());
    });
  };
});

// Here is the Custom Modal's Controller
// Please note that $modalInstance represents a modal window (instance) dependency.
// It is not the same as the $modal service used above.

angular.module('ui.bootstrap.demo').controller('ModalInstanceCtrl', function ($scope, $modalInstance, items) {

  $scope.items = items;
  $scope.selected = {
    item: $scope.items[0]
  };

  $scope.ok = function () {
    $modalInstance.close($scope.selected.item);
  };

  $scope.cancel = function () {
    $modalInstance.dismiss('cancel');
  };
});
```

##[Alert](https://angular-ui.github.io/bootstrap/#/alert)

[http://plnkr.co/edit/BfJsJeH05Hn8uqvWvONv?p=preview](http://plnkr.co/edit/BfJsJeH05Hn8uqvWvONv?p=preview)

* E:alert, A:type="success/warning/info/danger", A:close="method"

```html
<body ng-app="ui.bootstrap.demo">
...
<div ng-controller="AlertDemoCtrl">
  <alert ng-repeat="alert in alerts" type="{{alert.type}}" close="closeAlert($index)">{{alert.msg}}</alert>
  <button class='btn btn-default' ng-click="addAlert()">Add Alert</button>
</div>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('AlertDemoCtrl', function ($scope) {
  $scope.alerts = [
    { type: 'danger', msg: 'Oh snap! Change a few things up and try submitting again.' },
    { type: 'success', msg: 'Well done! You successfully read this important alert message.' }
  ];

  $scope.addAlert = function() {
    $scope.alerts.push({msg: 'Another alert!'});
  };

  $scope.closeAlert = function(index) {
    $scope.alerts.splice(index, 1);
  };
});
```

##[Tooltip](https://angular-ui.github.io/bootstrap/#/tooltip)

[http://plnkr.co/edit/UmS0zc9ggbOTch1z0C1B?p=preview](http://plnkr.co/edit/UmS0zc9ggbOTch1z0C1B?p=preview)

* E: a, input A: tooltip="content", tooltip-placement="left/right/top/bottom", tooltip-trigger="mouseenter/focus/click"
* Look at Popover for example

```html
<body ng-app="ui.bootstrap.demo">
  <h1>UI-Bootstrap Tooltip</h1>
  <style>
    /* Specify styling for tooltip contents */
    .tooltip.customClass .tooltip-inner {
      color: #880000;
      background-color: #ffff66;
      box-shadow: 0 6px 12px rgba(0, 0, 0, .175);
    }
    /* Hide arrow */
    .tooltip.customClass .tooltip-arrow {
      display: none;
    }
  </style>

  <div ng-controller="TooltipDemoCtrl">
    <p>
      Pellentesque <a href="#" tooltip="{{dynamicTooltip}}">{{dynamicTooltipText}}</a>,
      <a href="#" tooltip-placement="left" tooltip="On the Left!">left</a> abc
      <a href="#" tooltip-placement="right" tooltip="On the Right!">right</a> def
      <a href="#" tooltip-placement="bottom" tooltip="On the Bottom!">bottom</a> ghi
      <a href="#" tooltip-popup-delay='1000' tooltip='appears with delay'>delayed</a> jkl
    </p>

    <p>
      I can even contain HTML. <a href="#" tooltip-html="htmlTooltip">Check me out!</a>
    </p>

    <p>
      I can have a custom class. <a href="#" tooltip="I can have a custom class applied to me!" tooltip-class="customClass">Check me out!</a>
    </p>

    <form role="form">
      <div class="form-group">
        <label>Or use custom triggers, like focus:</label>
        <input type="text" value="Click me!" tooltip="See? Now click away..." tooltip-trigger="focus" tooltip-placement="top" class="form-control" />
      </div>

      <div class="form-group" ng-class="{'has-error' : !inputModel}">
        <label>Disable tooltips conditionally:</label>
        <input type="text" ng-model="inputModel" class="form-control" placeholder="Hover over this for a tooltip until this is filled" tooltip="Enter something in this input field to disable this tooltip" tooltip-placement="top" tooltip-trigger="mouseenter" tooltip-enable="!inputModel"
        />
      </div>
    </form>
  </div>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('TooltipDemoCtrl', function ($scope, $sce) {
  $scope.dynamicTooltip = 'Hello, World!';
  $scope.dynamicTooltipText = 'dynamic';
  $scope.htmlTooltip = $sce.trustAsHtml('I\'ve been made <b>bold</b> and <i>italic</i>!');
});
```

##[Popover](https://angular-ui.github.io/bootstrap/#/popover)

[http://plnkr.co/edit/PErJhCKRoUuYOqF3lTXs?p=preview](http://plnkr.co/edit/PErJhCKRoUuYOqF3lTXs?p=preview)

* E: button, input A: popover="content", popover-trigger="mouseenter/focus/click", popover-title, popover-placement="left/right/top/bottom"

For more goto documentation.
```html
<body ng-app="ui.bootstrap.demo">
...
<h4>Triggers</h4>
    <p>
      <button popover="I appeared on mouse enter!" popover-trigger="mouseenter" class="btn btn-default">Mouseenter</button>
    </p>
    <input type="text" value="Click me!" popover="I appeared on focus! Click away and I'll vanish..."  popover-trigger="focus" class="form-control">
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
```


##[Datepicker](https://angular-ui.github.io/bootstrap/#/datepicker)

[http://plnkr.co/edit/OVh5h7GJYkthVwCUkZwJ?p=preview](http://plnkr.co/edit/OVh5h7GJYkthVwCUkZwJ?p=preview)

* E: datepicker, A:min-date="some date", A:show-weeks="true/false"
* E: input, A:datepicker-popup="someformat e.g. MM-dd-yy", A: is-open="true/false", A: datepicker-options="...", A: date-disabled="true/false", A: close-text="Close" 
* Please see the documentation for more details

```html
<body ng-app="ui.bootstrap.demo">
...
<div ng-controller="DatepickerDemoCtrl">
    <pre>Selected date is: <em>{{dt | date:'fullDate' }}</em></pre>

    <h4>Inline</h4>
    <div style="display:inline-block; min-height:290px;">
        <datepicker ng-model="dt" min-date="minDate" show-weeks="true" class="well well-sm"></datepicker>
    </div>

    <h4>Popup</h4>
    <div class="row">
        <div class="col-md-6">
            <p class="input-group">
              <input type="text" class="form-control" datepicker-popup="{{format}}" ng-model="dt" is-open="opened" min-date="minDate" max-date="'2015-06-22'" datepicker-options="dateOptions" date-disabled="disabled(date, mode)" ng-required="true" close-text="Close" />
              <span class="input-group-btn">
                <button type="button" class="btn btn-default" ng-click="open($event)"><i class="glyphicon glyphicon-calendar"></i></button>
              </span>
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <label>Format:</label> <select class="form-control" ng-model="format" ng-options="f for f in formats"><option></option></select>
        </div>
    </div>

    <hr />
    <button type="button" class="btn btn-sm btn-info" ng-click="today()">Today</button>
    <button type="button" class="btn btn-sm btn-default" ng-click="dt = '2009-08-24'">2009-08-24</button>
    <button type="button" class="btn btn-sm btn-danger" ng-click="clear()">Clear</button>
    <button type="button" class="btn btn-sm btn-default" ng-click="toggleMin()" tooltip="After today restriction">Min date</button>
</div>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('DatepickerDemoCtrl', function ($scope) {
  $scope.today = function() {
    $scope.dt = new Date();
  };
  $scope.today();

  $scope.clear = function () {
    $scope.dt = null;
  };

  // Disable weekend selection
  $scope.disabled = function(date, mode) {
    return ( mode === 'day' && ( date.getDay() === 0 || date.getDay() === 6 ) );
  };

  $scope.toggleMin = function() {
    $scope.minDate = $scope.minDate ? null : new Date();
  };
  $scope.toggleMin();

  $scope.open = function($event) {
    $event.preventDefault();
    $event.stopPropagation();

    $scope.opened = true;
  };

  $scope.dateOptions = {
    formatYear: 'yy',
    startingDay: 1
  };

  $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
  $scope.format = $scope.formats[0];
});
```

##[Timepicker](https://angular-ui.github.io/bootstrap/#/timepicker)

[http://plnkr.co/edit/AW3dDzRAHgDUzomN7SYK?p=preview](http://plnkr.co/edit/AW3dDzRAHgDUzomN7SYK?p=preview)

* E: timepicker, A: ng-model="theTime", show-meridian(12/24H)="true/false", readonly-input(editbox enable or not)
```html
<body ng-app="ui.bootstrap.demo">
...
<timepicker ng-model="mytime" show-meridian="ismeridian"></timepicker>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('TimepickerDemoCtrl', function ($scope, $log) {
  $scope.mytime = new Date();

  $scope.ismeridian = true;
  $scope.toggleMode = function() {
    $scope.ismeridian = ! $scope.ismeridian;
  };

  $scope.changeTime = function() {
    var d = new Date();
    d.setHours( 14 );
    d.setMinutes( 0 );
    $scope.mytime = d;
  };

  $scope.clear = function() {
    $scope.mytime = null;
  };
});
```

##[Pagination](https://angular-ui.github.io/bootstrap/#/pagination)
Will take care of visualising a pagination bar and enable / disable buttons correctly!

[http://plnkr.co/edit/eyvTC9ViILk6XVrryVmf?p=preview](http://plnkr.co/edit/eyvTC9ViILk6XVrryVmf?p=preview)

* E: pagination, A: ng-model(current page),direction-links(Previous/Next buttons), boundary-links(First/Last buttons), total-items, items-per-page, max-size, rotate(keep current page in the middle)
##[Pager](https://angular-ui.github.io/bootstrap/#/pagination)
* E: pager, A: total-items, ng-model="current page #", align="true/false", previous-text, next-text

```html
<body ng-app="ui.bootstrap.demo">
...
<div ng-controller="PaginationDemoCtrl">
    <h4>Default</h4>
    <pagination total-items="totalItems" ng-model="currentPage" ng-change="pageChanged()"></pagination>
    <pagination boundary-links="true" total-items="totalItems" ng-model="currentPage" class="pagination-sm" previous-text="&lsaquo;" next-text="&rsaquo;" first-text="&laquo;" last-text="&raquo;"></pagination>
    <pagination direction-links="false" boundary-links="true" total-items="totalItems" ng-model="currentPage"></pagination>
    <pagination direction-links="false" total-items="totalItems" ng-model="currentPage" num-pages="smallnumPages"></pagination>
    <pre>The selected page no: {{currentPage}}</pre>
    <button class="btn btn-info" ng-click="setPage(3)">Set current page to: 3</button>

    <hr />
    <h4>Pager</h4>
    <pager total-items="totalItems" ng-model="currentPage"></pager>

    <hr />
    <h4>Demonstrate maximum visible buttons and center current page among visible</h4>
    <pagination total-items="bigTotalItems" ng-model="bigCurrentPage" max-size="maxSize" class="pagination-sm" boundary-links="true"></pagination>
    <pagination total-items="bigTotalItems" ng-model="bigCurrentPage" max-size="maxSize" class="pagination-sm" boundary-links="true" rotate="false" num-pages="numPages"></pagination>
    <pre>Page: {{bigCurrentPage}} / {{numPages}}</pre>
</div>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('PaginationDemoCtrl', function ($scope, $log) {
  $scope.totalItems = 64;
  $scope.currentPage = 4;

  $scope.setPage = function (pageNo) {
    $scope.currentPage = pageNo;
  };

  $scope.pageChanged = function() {
    $log.log('Page changed to: ' + $scope.currentPage);
  };

  $scope.maxSize = 5;
  $scope.bigTotalItems = 175;
  $scope.bigCurrentPage = 1;
});
```

##[Typeahead](https://angular-ui.github.io/bootstrap/#/typeahead)

[http://plnkr.co/edit/ag8k3ze6RvTZPEmLJdxn?p=preview](http://plnkr.co/edit/ag8k3ze6RvTZPEmLJdxn?p=preview)

* A: ng-model="selectedItem" typeahead="item for item in myArray | filter:$viewValue | limitTo:8"
* Async example: typeahead="item for item in getLocation($viewValue)" typeahead-loading="loadingLocations"
* A: typeahead-min-length, typeahead-wait-ms

```html
<body ng-app="ui.bootstrap.demo">
    <h1>UI-Bootstrap Typeahead</h1>
    
<script type="text/ng-template" id="customTemplate.html">
  <a>
      <img ng-src="http://upload.wikimedia.org/wikipedia/commons/thumb/{{match.model.flag}}" width="16">
      <span bind-html-unsafe="match.label | typeaheadHighlight:query"></span>
  </a>
</script>
<div class='container-fluid' ng-controller="TypeaheadCtrl">

    <h4>Static arrays</h4>
    <pre>Model: {{selected | json}}</pre>
    <input type="text" placeholder="e.g. New Jer" ng-model="selected" typeahead="state for state in states | filter:$viewValue | limitTo:8" class="form-control">

    <h4>Asynchronous results</h4>
    <pre>Model: {{asyncSelected | json}}</pre>
    <input type="text" ng-model="asyncSelected" placeholder="Locations loaded via $http " typeahead="address for address in getLocation($viewValue)" typeahead-loading="loadingLocations" class="form-control">
    <i ng-show="loadingLocations" class="glyphicon glyphicon-refresh"></i>

    <h4>Custom templates for results</h4>
    <pre>Model: {{customSelected | json}}</pre>
    <input type="text" ng-model="customSelected" placeholder="Custom template" typeahead="state as state.name for state in statesWithFlags | filter:{name:$viewValue}" typeahead-template-url="customTemplate.html" class="form-control">
</div>    
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('TypeaheadCtrl', function($scope, $http) {

  $scope.selected = undefined;
  $scope.states = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California', 'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii', 'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana', 'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota', 'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire', 'New Jersey', 'New Mexico', 'New York', 'North Dakota', 'North Carolina', 'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island', 'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont', 'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'];
  // Any function returning a promise object can be used to load values asynchronously
  $scope.getLocation = function(val) {
    return $http.get('http://maps.googleapis.com/maps/api/geocode/json', {
      params: {
        address: val,
        sensor: false
      }
    }).then(function(response){
      return response.data.results.map(function(item){
        return item.formatted_address;
      });
    });
  };

  $scope.statesWithFlags = [{'name':'Alabama','flag':'5/5c/Flag_of_Alabama.svg/45px-Flag_of_Alabama.svg.png'},{'name':'Alaska','flag':'e/e6/Flag_of_Alaska.svg/43px-Flag_of_Alaska.svg.png'},{'name':'Arizona','flag':'9/9d/Flag_of_Arizona.svg/45px-Flag_of_Arizona.svg.png'},{'name':'Arkansas','flag':'9/9d/Flag_of_Arkansas.svg/45px-Flag_of_Arkansas.svg.png'},{'name':'California','flag':'0/01/Flag_of_California.svg/45px-Flag_of_California.svg.png'},{'name':'Colorado','flag':'4/46/Flag_of_Colorado.svg/45px-Flag_of_Colorado.svg.png'},{'name':'Connecticut','flag':'9/96/Flag_of_Connecticut.svg/39px-Flag_of_Connecticut.svg.png'},{'name':'Delaware','flag':'c/c6/Flag_of_Delaware.svg/45px-Flag_of_Delaware.svg.png'},{'name':'Florida','flag':'f/f7/Flag_of_Florida.svg/45px-Flag_of_Florida.svg.png'},{'name':'Georgia','flag':'5/54/Flag_of_Georgia_%28U.S._state%29.svg/46px-Flag_of_Georgia_%28U.S._state%29.svg.png'},{'name':'Hawaii','flag':'e/ef/Flag_of_Hawaii.svg/46px-Flag_of_Hawaii.svg.png'},{'name':'Idaho','flag':'a/a4/Flag_of_Idaho.svg/38px-Flag_of_Idaho.svg.png'},{'name':'Illinois','flag':'0/01/Flag_of_Illinois.svg/46px-Flag_of_Illinois.svg.png'},{'name':'Indiana','flag':'a/ac/Flag_of_Indiana.svg/45px-Flag_of_Indiana.svg.png'},{'name':'Iowa','flag':'a/aa/Flag_of_Iowa.svg/44px-Flag_of_Iowa.svg.png'},{'name':'Kansas','flag':'d/da/Flag_of_Kansas.svg/46px-Flag_of_Kansas.svg.png'},{'name':'Kentucky','flag':'8/8d/Flag_of_Kentucky.svg/46px-Flag_of_Kentucky.svg.png'},{'name':'Louisiana','flag':'e/e0/Flag_of_Louisiana.svg/46px-Flag_of_Louisiana.svg.png'},{'name':'Maine','flag':'3/35/Flag_of_Maine.svg/45px-Flag_of_Maine.svg.png'},{'name':'Maryland','flag':'a/a0/Flag_of_Maryland.svg/45px-Flag_of_Maryland.svg.png'},{'name':'Massachusetts','flag':'f/f2/Flag_of_Massachusetts.svg/46px-Flag_of_Massachusetts.svg.png'},{'name':'Michigan','flag':'b/b5/Flag_of_Michigan.svg/45px-Flag_of_Michigan.svg.png'},{'name':'Minnesota','flag':'b/b9/Flag_of_Minnesota.svg/46px-Flag_of_Minnesota.svg.png'},{'name':'Mississippi','flag':'4/42/Flag_of_Mississippi.svg/45px-Flag_of_Mississippi.svg.png'},{'name':'Missouri','flag':'5/5a/Flag_of_Missouri.svg/46px-Flag_of_Missouri.svg.png'},{'name':'Montana','flag':'c/cb/Flag_of_Montana.svg/45px-Flag_of_Montana.svg.png'},{'name':'Nebraska','flag':'4/4d/Flag_of_Nebraska.svg/46px-Flag_of_Nebraska.svg.png'},{'name':'Nevada','flag':'f/f1/Flag_of_Nevada.svg/45px-Flag_of_Nevada.svg.png'},{'name':'New Hampshire','flag':'2/28/Flag_of_New_Hampshire.svg/45px-Flag_of_New_Hampshire.svg.png'},{'name':'New Jersey','flag':'9/92/Flag_of_New_Jersey.svg/45px-Flag_of_New_Jersey.svg.png'},{'name':'New Mexico','flag':'c/c3/Flag_of_New_Mexico.svg/45px-Flag_of_New_Mexico.svg.png'},{'name':'New York','flag':'1/1a/Flag_of_New_York.svg/46px-Flag_of_New_York.svg.png'},{'name':'North Carolina','flag':'b/bb/Flag_of_North_Carolina.svg/45px-Flag_of_North_Carolina.svg.png'},{'name':'North Dakota','flag':'e/ee/Flag_of_North_Dakota.svg/38px-Flag_of_North_Dakota.svg.png'},{'name':'Ohio','flag':'4/4c/Flag_of_Ohio.svg/46px-Flag_of_Ohio.svg.png'},{'name':'Oklahoma','flag':'6/6e/Flag_of_Oklahoma.svg/45px-Flag_of_Oklahoma.svg.png'},{'name':'Oregon','flag':'b/b9/Flag_of_Oregon.svg/46px-Flag_of_Oregon.svg.png'},{'name':'Pennsylvania','flag':'f/f7/Flag_of_Pennsylvania.svg/45px-Flag_of_Pennsylvania.svg.png'},{'name':'Rhode Island','flag':'f/f3/Flag_of_Rhode_Island.svg/32px-Flag_of_Rhode_Island.svg.png'},{'name':'South Carolina','flag':'6/69/Flag_of_South_Carolina.svg/45px-Flag_of_South_Carolina.svg.png'},{'name':'South Dakota','flag':'1/1a/Flag_of_South_Dakota.svg/46px-Flag_of_South_Dakota.svg.png'},{'name':'Tennessee','flag':'9/9e/Flag_of_Tennessee.svg/46px-Flag_of_Tennessee.svg.png'},{'name':'Texas','flag':'f/f7/Flag_of_Texas.svg/45px-Flag_of_Texas.svg.png'},{'name':'Utah','flag':'f/f6/Flag_of_Utah.svg/45px-Flag_of_Utah.svg.png'},{'name':'Vermont','flag':'4/49/Flag_of_Vermont.svg/46px-Flag_of_Vermont.svg.png'},{'name':'Virginia','flag':'4/47/Flag_of_Virginia.svg/44px-Flag_of_Virginia.svg.png'},{'name':'Washington','flag':'5/54/Flag_of_Washington.svg/46px-Flag_of_Washington.svg.png'},{'name':'West Virginia','flag':'2/22/Flag_of_West_Virginia.svg/46px-Flag_of_West_Virginia.svg.png'},{'name':'Wisconsin','flag':'2/22/Flag_of_Wisconsin.svg/45px-Flag_of_Wisconsin.svg.png'},{'name':'Wyoming','flag':'b/bc/Flag_of_Wyoming.svg/43px-Flag_of_Wyoming.svg.png'}];
});
```


##[Rating](https://angular-ui.github.io/bootstrap/#/rating)

[http://plnkr.co/edit/4K94Sas7omG4hcG0m7O3?p=preview](http://plnkr.co/edit/4K94Sas7omG4hcG0m7O3?p=preview)

* E: rating A: ng-model="current rate", max="#ofIcons", readonly, state-on/off
* Event: A: on-hover, on-leave
* Custom Icons: A: rating-states(an array defining properties of ALL icons)
```html
<body ng-app="ui.bootstrap.demo">
...
<div ng-controller="RatingDemoCtrl">
    <h4>Default</h4>
    <rating ng-model="rate" max="max" readonly="isReadonly" on-hover="hoveringOver(value)" on-leave="overStar = null"></rating>
    <span class="label" ng-class="{'label-warning': percent<30, 'label-info': percent>=30 && percent<70, 'label-success': percent>=70}" ng-show="overStar && !isReadonly">{{percent}}%</span>

    <pre style="margin:15px 0;">Rate: <b>{{rate}}</b> - Readonly is: <i>{{isReadonly}}</i> - Hovering over: <b>{{overStar || "none"}}</b></pre>

    <button class="btn btn-sm btn-danger" ng-click="rate = 0" ng-disabled="isReadonly">Clear</button>
    <button class="btn btn-sm btn-default" ng-click="isReadonly = ! isReadonly">Toggle Readonly</button>
    <hr />

    <h4>Custom icons</h4>
    <div ng-init="x = 5"><rating ng-model="x" max="15" state-on="'glyphicon-ok-sign'" state-off="'glyphicon-ok-circle'"></rating> <b>(<i>Rate:</i> {{x}})</b></div>
    <div ng-init="y = 2"><rating ng-model="y" rating-states="ratingStates"></rating> <b>(<i>Rate:</i> {{y}})</b></div>
</div>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('RatingDemoCtrl', function ($scope) {
  $scope.rate = 7;
  $scope.max = 10;
  $scope.isReadonly = false;

  $scope.hoveringOver = function(value) {
    $scope.overStar = value;
    $scope.percent = 100 * (value / $scope.max);
  };

  $scope.ratingStates = [
    {stateOn: 'glyphicon-ok-sign', stateOff: 'glyphicon-ok-circle'},
    {stateOn: 'glyphicon-star', stateOff: 'glyphicon-star-empty'},
    {stateOn: 'glyphicon-heart', stateOff: 'glyphicon-ban-circle'},
    {stateOn: 'glyphicon-heart'},
    {stateOff: 'glyphicon-off'}
  ];
});
```

##[Carousel](https://angular-ui.github.io/bootstrap/#/carousel)

[http://plnkr.co/edit/d97dpUUtb3LBTF22UPSI?p=preview](http://plnkr.co/edit/d97dpUUtb3LBTF22UPSI?p=preview)

* To enable swiping, load the ngTouch module as a dependency
* E:carousel, A:interval="#msec"
* E:slide, A:active="slide.active"

```html
<body ng-app="ui.bootstrap.demo">
...
<div ng-controller="CarouselDemoCtrl">
  <div style="height: 305px">
    <carousel interval="myInterval">
      <slide ng-repeat="slide in slides" active="slide.active">
        <img ng-src="{{slide.image}}" style="margin:auto;">
        <div class="carousel-caption">
          <h4>Slide {{$index}}</h4>
          <p>{{slide.text}}</p>
        </div>
      </slide>
    </carousel>
  </div>
  <div class="row">
    <div class="col-md-6">
      <button type="button" class="btn btn-info" ng-click="addSlide()">Add Slide</button>
    </div>
    <div class="col-md-6">
      Interval, in milliseconds: <input type="number" class="form-control" ng-model="myInterval">
      <br />Enter a negative number or 0 to stop the interval.
    </div>
  </div>
</div>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('CarouselDemoCtrl', function ($scope) {
  $scope.myInterval = 5000;
  var slides = $scope.slides = [];
  $scope.addSlide = function() {
    var newWidth = 600 + slides.length + 1;
    slides.push({
      image: 'http://placekitten.com/' + newWidth + '/300',
      text: ['More','Extra','Lots of','Surplus'][slides.length % 4] + ' ' +
        ['Cats', 'Kittys', 'Felines', 'Cutes'][slides.length % 4]
    });
  };
  for (var i=0; i<4; i++) {
    $scope.addSlide();
  }
});
```

##[Accordion](https://angular-ui.github.io/bootstrap/#/accordion)

[http://plnkr.co/edit/X41Wun7sc96tf299kCJE?p=preview](http://plnkr.co/edit/X41Wun7sc96tf299kCJE?p=preview)

* The accordion directive builds on top of the collapse directive
* E: accordion, A: close-others="t/f"(control whether expanding an item will cause the other items to close)
* E: accordion-group, A: heading="some text", is-open="t/f, is-disabled="t/f". The element accept inner content too, including html.
* E: accordion-heading - support complex html

```html
<body ng-app="ui.bootstrap.demo">
...
<div ng-controller="AccordionDemoCtrl">
  <p>
    <button class="btn btn-default btn-sm" ng-click="status.open = !status.open">Toggle last panel</button>
    <button class="btn btn-default btn-sm" ng-click="status.isFirstDisabled = ! status.isFirstDisabled">Enable / Disable first panel</button>
  </p>

  <label class="checkbox"  style="margin-left: 20px;">
    <input type="checkbox" ng-model="oneAtATime">
    Open only one at a time
  </label>
  <accordion close-others="oneAtATime">
    <accordion-group heading="Static Header, initially expanded" is-open="status.isFirstOpen" is-disabled="status.isFirstDisabled">
      This content is straight in the template.
    </accordion-group>
    <accordion-group heading="{{group.title}}" ng-repeat="group in groups">
      {{group.content}}
    </accordion-group>
    <accordion-group heading="Dynamic Body Content">
      <p>The body of the accordion group grows to fit the contents</p>
        <button class="btn btn-default btn-sm" ng-click="addItem()">Add Item</button>
        <div ng-repeat="item in items">{{item}}</div>
    </accordion-group>
    <accordion-group is-open="status.open">
        <accordion-heading>
            I can have markup, too! <i class="pull-right glyphicon" ng-class="{'glyphicon-chevron-down': status.open, 'glyphicon-chevron-right': !status.open}"></i>
        </accordion-heading>
        This is just some content to illustrate fancy headings.
    </accordion-group>
  </accordion>
</div>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('AccordionDemoCtrl', function ($scope) {
  $scope.oneAtATime = true;

  $scope.groups = [
    {
      title: 'Dynamic Group Header - 1',
      content: 'Dynamic Group Body - 1'
    },
    {
      title: 'Dynamic Group Header - 2',
      content: 'Dynamic Group Body - 2'
    }
  ];

  $scope.items = ['Item 1', 'Item 2', 'Item 3'];

  $scope.addItem = function() {
    var newItemNo = $scope.items.length + 1;
    $scope.items.push('Item ' + newItemNo);
  };

  $scope.status = {
    isFirstOpen: true,
    isFirstDisabled: false
  };
});
```


##[Checkbox Radio Button Group](https://angular-ui.github.io/bootstrap/#/buttons)

[http://plnkr.co/edit/kueGhGcFLrEVpbszEaQh?p=preview](http://plnkr.co/edit/kueGhGcFLrEVpbszEaQh?p=preview)

* A:btn-checkbox, A:btn-checkbox-true="1", A:btn-checkbox-false="0"
* A:btn-radio, A:uncheckable(A hybrid where radio buttons can be unchecked)

```html
<body ng-app="ui.bootstrap.demo">
...
<div ng-controller="ButtonsCtrl">
    <h4>Single toggle</h4>
    <pre>{{singleModel}}</pre>
    <button type="button" class="btn btn-primary" ng-model="singleModel" btn-checkbox btn-checkbox-true="1" btn-checkbox-false="0">
        Single Toggle
    </button>
    <h4>Checkbox</h4>
    <pre>{{checkModel}}</pre>
    <div class="btn-group">
        <label class="btn btn-primary" ng-model="checkModel.left" btn-checkbox>Left</label>
        <label class="btn btn-primary" ng-model="checkModel.middle" btn-checkbox>Middle</label>
        <label class="btn btn-primary" ng-model="checkModel.right" btn-checkbox>Right</label>
    </div>
    <h4>Radio &amp; Uncheckable Radio</h4>
    <pre>{{radioModel || 'null'}}</pre>
    <div class="btn-group">
        <label class="btn btn-primary" ng-model="radioModel" btn-radio="'Left'">Left</label>
        <label class="btn btn-primary" ng-model="radioModel" btn-radio="'Middle'">Middle</label>
        <label class="btn btn-primary" ng-model="radioModel" btn-radio="'Right'">Right</label>
    </div>
    <div class="btn-group">
        <label class="btn btn-success" ng-model="radioModel" btn-radio="'Left'" uncheckable>Left</label>
        <label class="btn btn-success" ng-model="radioModel" btn-radio="'Middle'" uncheckable>Middle</label>
        <label class="btn btn-success" ng-model="radioModel" btn-radio="'Right'" uncheckable>Right</label>
    </div>
</div>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('ButtonsCtrl', function ($scope) {
  $scope.singleModel = 1;
  $scope.radioModel = 'Middle';
  $scope.checkModel = {
    left: false,
    middle: true,
    right: false
  };
});
```


##[Collapse](https://angular-ui.github.io/bootstrap/#/collapse)

[http://plnkr.co/edit/OFULRa19oZIhMG4D2MUc?p=preview](http://plnkr.co/edit/OFULRa19oZIhMG4D2MUc?p=preview)

* To hide and show an element with a css transition (missing)
* A: collapse="true/false toggle"

```html
<body ng-app="ui.bootstrap.demo">
...
<div ng-controller="CollapseDemoCtrl">
    <button class="btn btn-default" ng-click="isCollapsed = !isCollapsed">Toggle collapse</button>
    <hr>
    <div collapse="isCollapsed">
        <div class="well well-lg">Some content</div> 
    </div>
</div>
```

```js
angular.module('ui.bootstrap.demo', ['ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('CollapseDemoCtrl', function ($scope) {
  $scope.isCollapsed = false;
});
```


##[Progressbar](https://angular-ui.github.io/bootstrap/#/progressbar)
