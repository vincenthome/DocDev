
##Bootstrap components written in pure AngularJS

[http://angular-ui.github.io/bootstrap/](http://angular-ui.github.io/bootstrap/)

Doc Angular Components (non-js)

http://getbootstrap.com/components/

##Accordion


###Alert /w close button

This directive can be used to generate alerts from the dynamic model data (using the ng-repeat directive);

The presence of the close attribute determines if a close button is displayed

```html
    <alert type='info/success/danger/warning' close="removeAlert()">Some Message</alert>
```
    
###Button

* Toggle directive: btn-checkbox/btn-checkbox-true=''/btn-checkbox-false=''
* Checkboxes group directive: btn-checkbox/btn-checkbox-true=''/btn-checkbox-false=''
* Radio buttons directive btn-radio

```html
<button ... btn-checkbox btn-checkbox-true="1" btn-checkbox-false="0">
    Single Toggle
</button>
// Checkbox Group
<pre>{{checkModel}}</pre>
<div class="btn-group">
    <label class="btn btn-primary" ng-model="checked.a" btn-checkbox>A</label>
    <label class="btn btn-primary" ng-model="checked.b" btn-checkbox>B</label>
    <label class="btn btn-primary" ng-model="checked.c" btn-checkbox>C</label>
</div>
// Radio Button Group
<pre>{{radioModel || 'null'}}</pre>
<div class="btn-group">
    <label class="btn btn-primary" ng-model="radio" btn-radio="'a'">A</label>
    <label class="btn btn-primary" ng-model="radio" btn-radio="'b'">B</label>
    <label class="btn btn-primary" ng-model="radio" btn-radio="'c'">C</label>
</div>
```


###Carousel

The carousel also offers support for touchscreen devices in the form of swiping. To enable swiping, load the ngTouch module as a dependency

```html
<carousel interval="myInterval">
  <slide ng-repeat="slide in slides" active="slide.active">
    <img ng-src="{{slide.image}}" style="margin:auto;">
    <div class="carousel-caption">
      <h4>Slide {{$index}}</h4>
      <p>{{slide.text}}</p>
    </div>
  </slide>
</carousel>
```

###Collapse

Simple way to hide and show with CSS transition

```html
<div collapse="isCollapsed">
    <div class="well well-lg">Some content</div> 
</div>

```

###Datepicker

####Settings

* DatePicker
    - All settings can be provided as attributes in the datepicker or globally configured through the datepickerConfig.
* Popup
    - Options for datepicker can be passed as JSON using the datepicker-options attribute. Specific settings for the datepicker-popup, that can globally configured through the datepickerPopupConfig
* Keyboard

####Inline

```html
<div style="display:inline-block; min-height:290px;">
    <datepicker ng-model="dt" class="well well-sm"
        min-date="minDate" 
        show-weeks="true">
    </datepicker>
</div>
```

####Popup

```html
<div class="row">
    <div class="col-md-6">
        <p class="input-group">
          <input type="text" class="form-control" ng-model="dt"
            datepicker-popup="{{format}}" 
            is-open="opened" 
            min-date="minDate" 
            max-date="'2015-06-22'" 
            datepicker-options="dateOptions" 
            date-disabled="disabled(date, mode)" ng-required="true" 
            close-text="Close" />
          <span class="input-group-btn">
            <button type="button" class="btn btn-default" 
                ng-click="open($event)">
                    <i class="glyphicon glyphicon-calendar"></i>
            </button>
          </span>
        </p>
    </div>
</div>

<hr />
<button type="button" class="btn btn-sm btn-info" 
    ng-click="today()">Today</button>
<button type="button" class="btn btn-sm btn-default" 
    ng-click="dt = '2009-08-24'">2009-08-24</button>
<button type="button" class="btn btn-sm btn-danger" 
    ng-click="clear()">Clear</button>
<button type="button" class="btn btn-sm btn-default" 
    ng-click="toggleMin()" tooltip="After today restriction">Min date</button>
```

```js
this.today = function() {
    this.dt = new Date();
};

this.clear = function () {
    this.dt = null;
};

// Disable weekend selection
this.disabled = function(date, mode) {
    return ( mode === 'day' && ( date.getDay() === 0 || date.getDay() === 6 ));
};

this.toggleMin = function() {
    this.minDate = this.minDate ? null : new Date();
};

this.open = function($event) {
    $event.preventDefault();
    $event.stopPropagation();

    this.opened = true;
};

this.dateOptions = {
    formatYear: 'yy',
    startingDay: 1
};

this.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
this.format = this.formats[0];

```

###Dropdown

You can either use is-open to toggle or add inside a <a dropdown-toggle> element to toggle it when is clicked. There is also the on-toggle(open) optional expression fired when dropdown changes state.


###Modal
###Pagination
###Popover
###Progressbar
###Rating
###Tabs
###Timepicker
###Tooltip
###Typeahead


