# Bootstrap.Components


* [Glyphicon & Fontawesome](http://plnkr.co/edit/FqBL06QgPAvbzZtHBrfg?p=preview)
  - Glyphicon - .glyphicon .glyphicon-*
  - Font Awesome - .fa .fa-*
    + Sizes - .fa-lg .fa-2x .fa-3x .fa-4x .fa-5x
    + Unordered List Bullets - ul tag: .fa-ul .fa-li
    + Fix width - .fa-fw
    + Spinner - .fa-spin/pulse .fa-spinner/refresh/cog/circle-o-notch
    + Flip and Rotate - .fa-rotate-90/180/270
    + Stack Icons - span tag: .fa-stack .fa-lg, i tag: .fa-stack-2s .fa-stack-1s
    + Border - .fa-border
* [Components](http://plnkr.co/edit/GKeOvi59Oelbx4xWhGFW?p=preview)
  - Page Header - .page-header tag: small
  - Label - .label .lable-*Contextual
  - Badges - .badge
  - Jumbotron - .jumbotron
  - Well - .well
  - Panel - .panel .panel-*Contextual .panel-header .panel-title .panel-body 
  - List Group - .list-group .list-group-item .list-group-item-*Contextual .list-group-item-heading .list-group-item-text .active
    + ul & li
    + div & a
  - Static Alerts - .alert .alert-*Contextual
  - Thumbnail - .thumbnail .caption
  - Breadcrumb - .breadcrumb
  - Pager - .page
  - Button Group - .button-group
  - Video - .embed-responsive .embed-responsive-16by9 .embed-responsive-item
  - Media/Media List - .media .media-left/right .media-top/middle/bottom .media-body .media-heading

##CDN for Bootstrap Components and those require javascript
```
<link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" rel="stylesheet">
<script src="//code.jquery.com/jquery-2.1.3.js"></script>
<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
```

###Thumbnail
* [Masonry](http://masonry.desandro.com/)
* [Isotope](http://isotope.metafizzy.co/)
* [Salvattore](http://salvattore.com/)



#Components which require Javascript  (Alternative: UI-Bootstrap for AngularJS instead)

##Alert
###Dismissible(require Javascript) - add .alert-dismissible to <div>
[http://getbootstrap.com/javascript/#alerts](http://getbootstrap.com/javascript/#alerts)  
When using a .close button, it must be the first child of the .alert-dismissible and no text content may come before it in the markup. DON'T USE data-dismiss attribute!  
[http://stackoverflow.com/questions/10903526/how-to-toggle-a-bootstrap-alert-on-and-off-with-button-click](http://stackoverflow.com/questions/10903526/how-to-toggle-a-bootstrap-alert-on-and-off-with-button-click)  
```
<div class="alert alert-warning alert-dismissible">
  <button type="button" class="close">
    <span >&times;</span>
  </button>
  <strong>Warning!</strong> Better check yourself, you're not looking too good.
</div>
```

##Dropdown - .data-toggle="dropdown" on <button> / <a>
[http://getbootstrap.com/javascript/#dropdowns](http://getbootstrap.com/javascript/#dropdowns)
Add data-toggle="dropdown" to a link or button to toggle a dropdown without any javascript

###Usage
Wrap the dropdown's trigger and the dropdown menu within .dropdown

* Alignment: Add .dropdown-menu-right to .dropdown-menu to right align menu
* Header: Add .dropdown-header to <li>
* Divider: Add .divider to <li>
* Disable Menu Item: Add .disabled to <li>

###Single Button
[http://getbootstrap.com/components/#btn-dropdowns-single](http://getbootstrap.com/components/#btn-dropdowns-single)
```
<div class="btn-group">
  <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" >
    Action <span class="caret"></span>
  </button>
  <ul class="dropdown-menu">
    <li><a href="#">A</a></li>
    <li><a href="#">B</a></li>
  </ul>
</div>
```

###Split button
[http://getbootstrap.com/components/#btn-dropdowns-split](http://getbootstrap.com/components/#btn-dropdowns-split)
With the same markup changes, only with a separate button.

```
<div class="btn-group">
  <button type="button" class="btn btn-default">Separate Button</button>
  <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
    <span class="caret"></span>
  </button>
  <ul class="dropdown-menu">
    <li><a href="#">A</a></li>
    <li><a href="#">B</a></li>
  </ul>
</div>
```

###Dropup - .dropup on the .btn-group level

###Buttons Group Dropdown
[http://getbootstrap.com/components/#btn-groups-nested](http://getbootstrap.com/components/#btn-groups-nested)
Place a .btn-group within another .btn-group when you want dropdown menus mixed with a series of buttons.

```
<div class="btn-group" >
  <button type="button" class="btn btn-default">1</button>
  <button type="button" class="btn btn-default">2</button>

  <div class="btn-group">
    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" >
      Action <span class="caret"></span>
    </button>
    <ul class="dropdown-menu" >
      <li><a href="#">A</a></li>
      <li><a href="#">B</a></li>
    </ul>
  </div>
</div>
```

###Tabs/Pills Dropdown - added <li class="dropdown"><a ... >...</a>...</li>
[http://getbootstrap.com/components/#nav-dropdowns](http://getbootstrap.com/components/#nav-dropdowns)
```
<ul class="nav nav-tabs or nav-pills">
  ...
  <!-- here is the dropdown tab -->
  <li class="dropdown">
    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
      Dropdown <span class="caret"></span>
    </a>
    <ul class="dropdown-menu">
      ...
    </ul>
  </li>
  ...
</ul>
```

###Toggle Dropdown - JS
[http://getbootstrap.com/javascript/#dropdowns-methods](http://getbootstrap.com/javascript/#dropdowns-methods)
```
$('#myDropdown').dropdown('toggle')
```



##Tabs/Pills(Nav) - .nav .nav-tabs/pills & .active in <li>
* Component using .active (No Javascript): [http://getbootstrap.com/components/#nav](http://getbootstrap.com/components/#nav)

```
<ul class="nav nav-tabs">
  <li class="active"><a href="#">Home</a></li>
  <li ><a href="#">Profile</a></li>
  <li ><a href="#">Messages</a></li>
</ul>
```

Pills can be stacked Vertically
```
<ul class="nav nav-pills nav-stacked">
  ...
</ul>
```

* Javascript: .data-toggle="tab/pill" on <a>
[http://getbootstrap.com/javascript/#tabs](http://getbootstrap.com/javascript/#tabs)
You can activate a tab or pill navigation without writing any JavaScript by simply specifying data-toggle="tab" or data-toggle="pill"
```
<div role="tabpanel">
  <!-- Nav tabs -->
  <ul class="nav nav-tabs">
    <li class="active"><a href="#home" data-toggle="tab">Home</a></li>
    <li ><a href="#profile" data-toggle="tab">Profile</a></li>
  </ul>
  <!-- Tab panes -->
  <div class="tab-content">
    <div role="tabpanel" class="tab-pane active" id="home">...</div>
    <div role="tabpanel" class="tab-pane" id="profile">...</div>
  </div>
</div>
```

###Justified with equal widths - .nav-justified in <ul>

###Disabled - .disabled in <li>

###Fade - JS
To make tabs fade in, add .fade to each .tab-pane. The first tab pane must also have .in to properly fade in initial content.
```
<div class="tab-content">
  <div role="tabpanel" class="tab-pane fade in active" id="home">...</div>
  <div role="tabpanel" class="tab-pane fade" id="profile">...</div>
</div>
```

###Activate Tab - JS
[http://getbootstrap.com/javascript/#tabs-methods](http://getbootstrap.com/javascript/#tabs-methods)
Activates a tab element and content container. Tab should have either a data-target or an href targeting a container node in the DOM
```
$('#myTab a[href="#profile"]').tab('show') // Select tab by name
$('#myTab a:first').tab('show') // Select first tab
$('#myTab a:last').tab('show') // Select last tab
$('#myTab li:eq(2) a').tab('show') // Select third tab (0-indexed)
```

##Navbar
Navbars are responsive meta components that serve as navigation headers for your application or site. They begin collapsed (and are toggleable) in mobile views and become horizontal as the available viewport width increases.

###Alignment - .navbar-left / .navbar-right

###Brand Image - add .navbar-brand as parent of <img>

###Form - .navbar-form / alignment - 

```
<form class="navbar-form navbar-left">
  <div class="form-group">
    <input type="text" class="form-control" >
  </div>
  <button type="submit" class="btn btn-default">Submit</button>
</form>
```

###Button outside a form - .navbar-btn in <button>

```
<button type="button" class="btn btn-default navbar-btn">Sign in</button>
```

###Static Text - .navbar-text in <p>
```
<p class="navbar-text">Signed in as Mark Otto</p>
```

###Inverted navbar dark theme - .navbar-inverse

```
<nav class="navbar navbar-inverse">
  ...
</nav>
```

###Complete Example

```
<nav class="navbar navbar-default">
  <div class="container-fluid">

    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#">Brand</a>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <!-- Left align(default) Links with one 'Active' -->
      <ul class="nav navbar-nav">
        <li class="active"><a href="#">Link</a></li>
        <li><a href="#">Link</a></li>
        <!-- Dropdown -->
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown">
          Dropdown <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="#">A</a></li>
            <li><a href="#">B</a></li>
          </ul>
        </li>
      </ul>
      <!-- Form -->
      <form class="navbar-form navbar-left">
        <div class="form-group">
          <input type="text" class="form-control">
        </div>
        <button type="submit" class="btn btn-default">Submit</button>
      </form>
      <!-- Right Align Link & Dropdown -->
      <ul class="nav navbar-nav navbar-right">
        <li><a href="#">Link</a></li>
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown">
          Dropdown <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="#">A</a></li>
            <li><a href="#">B</a></li>
          </ul>
        </li>
      </ul>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>
```

##Collapse - .data-toggle="collapse" on <a>. href="#someId", data-target="#someId"
You can use a link with the href attribute, or a button with the data-target attribute. In both cases, the data-toggle="collapse" is required.
```
<a class="btn btn-primary" data-toggle="collapse" href="#collapseExample">
  Link with href
</a>
<button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collapseExample">
  Button with data-target
</button>
<div class="collapse" id="collapseExample">
  <div class="well">
    ... some content here ...
  </div>
</div>
```

###Accordion
[http://getbootstrap.com/javascript/#collapse-example-accordion](http://getbootstrap.com/javascript/#collapse-example-accordion)

##Button

###A Loading Disabled Button - .data-loading-text="Loading..."
```
<button type="button" id="myButton" data-loading-text="Loading..." class="btn btn-primary" autocomplete="off">
  Loading state
</button>

<script>
  $('#myButton').on('click', function () {
    var $btn = $(this).button('loading')
    // business logic...
    setTimeout(function () {
        $btn.button('reset');
    }, 3000);
    
  })
</script>
```

##Modal - 
[http://getbootstrap.com/javascript/#modals](http://getbootstrap.com/javascript/#modals)

* Trigger: data-toggle="modal" data-target="#someId"
* Modal Dialog: .modal .modal-dialog .modal-content .modal-header .modal-title .modal-body .modal-footer
* Dismiss Close 'x' Button: .close data-dismiss="modal"
* Dismiss Regular Button: data-miss="modal"

```
<!-- Button trigger modal -->
<button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
  Launch demo modal
</button>

<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">
          <span >&times;</span>
        </button>
        <h4 class="modal-title" id="myModalLabel">Modal title</h4>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>
```

###Size - .modal-dialog .modal-sm/lg
```
...
<div class="modal-dialog modal-sm">
    <div class="modal-content">
```

###Fade - .fade
For modals that simply appear rather than fade in to view, remove the .fade class from your modal markup.

###Using Grid within Modal
[http://getbootstrap.com/javascript/#modals-grid-system](http://getbootstrap.com/javascript/#modals-grid-system)
Just nest .container-fluid within the .modal-body and then use the normal grid system classes within this container.



##Tooltip - data-toggle="tooltip" data-placement="left/right/top/bottom"
[http://getbootstrap.com/javascript/#tooltips](http://getbootstrap.com/javascript/#tooltips)
###Init: For performance reasons, the Tooltip and Popover data-apis are opt-in, meaning you must initialize them yourself.
```
$(function () {
  $('[data-toggle="tooltip"]').tooltip()
})
```

###Usage
```
<button type="button" class="btn btn-default" data-toggle="tooltip" data-placement="left/right/top/bottom" title="Tooltip on x">Tooltip on x</button>
```


##Popover - .data-toggle="popover" (too complicated especially dismissible)
[http://getbootstrap.com/javascript/#popovers](http://getbootstrap.com/javascript/#popovers)

##Carousel - 
[http://getbootstrap.com/javascript/#carousel](http://getbootstrap.com/javascript/#carousel)

* .carousel .slide, data-ride="carousel" on <div>
* .carousel-indicators on <ol>
* data-slide-to="0/1/2" on <li>

Wrapper for slide
* .carousel-inner on <div>
* .item on <div>
* .carousel-caption on <div>

Control
* .left/right .carousel-control on <a>
* data-slide="next/prev" on <a>
```
<div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="..." alt="...">
      <div class="carousel-caption">
        ...
      </div>
    </div>
    <div class="item">
      <img src="..." alt="...">
      <div class="carousel-caption">
        ...
      </div>
    </div>
    ...
  </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
```

###Caption - .carousel-caption element within any .item
```
<div class="item">
  <img src="..." alt="...">
  <div class="carousel-caption">
    <h3>...</h3>
    <p>...</p>
  </div>
</div>
```


##Scrollspy

