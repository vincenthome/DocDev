# Bootstrap.CSS
Everything other than froms and controls

[http://plnkr.co/edit/0ZCFUtXDjt1a3sZ7RyVM?p=preview](http://plnkr.co/edit/0ZCFUtXDjt1a3sZ7RyVM?p=preview)

##Tool

* [http://www.layoutit.com/](http://www.layoutit.com/)

##HTML5 doctype

```
<!DOCTYPE html>
<html>
...
```

##Mobile first
```
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
```

##Global Typography and link style in scaffolding.less

* Set background-color: #fff; on the body
* Use the @font-family-base, @font-size-base, and @line-height-base attributes as our typographic base
* Set the global link color via @link-color and apply link underlines only on :hover

##Normalize.css - A precisely targeted CSS Reset

[http://necolas.github.io/normalize.css/](http://necolas.github.io/normalize.css/)

##Containers - not nestable

* container (fixed width base on browser size)
* container-fluid (full width based on viewport)


##Grid

* must within .container
* device size: xs - < 768px, sm - >=768px, md - >=992px, lg - >=1200px
* Row: .row
* Col: .col-xs/sm/md/lg-#cols
* If **> 12 columns** are placed within a single row, each group of extra columns will, as one unit, **wrap onto a new line**.
* Grid classes apply to devices with screen widths greater than or equal to the breakpoint sizes, and override grid classes targeted at smaller devices. Therefore, e.g. applying any .col-md-* class to an element will not only affect its styling on medium devices but also on large devices if a .col-lg-* class is not present.

```
<div class="container">
  <div class="row">
    <div class="col-md-8">.col-md-8</div>
    <div class="col-md-4">.col-md-4</div>
  </div>
</div>
```

###Example1: Responsive design for Mobile(Stacked) & Desktop(Fullwidth). 

[http://getbootstrap.com/css/#grid-example-mixed](http://getbootstrap.com/css/#grid-example-mixed)

```
<!-- Stack the columns on mobile by making one full-width and the other half-width -->
<div class="row">
  <div class="col-xs-12 col-md-8">.col-xs-12 .col-md-8</div>
  <div class="col-xs-6 col-md-4">.col-xs-6 .col-md-4</div>
</div>

<!-- Columns start at 50% wide on mobile and bump up to 33.3% wide on desktop -->
<div class="row">
  <div class="col-xs-6 col-md-4">.col-xs-6 .col-md-4</div>
  <div class="col-xs-6 col-md-4">.col-xs-6 .col-md-4</div>
  <div class="col-xs-6 col-md-4">.col-xs-6 .col-md-4</div>
</div>

<!-- Columns are always 50% wide, on mobile and desktop -->
<div class="row">
  <div class="col-xs-6">.col-xs-6</div>
  <div class="col-xs-6">.col-xs-6</div>
</div>
```

###Example2: Reponsive design for Mobile, Tablet & Desktop

[http://getbootstrap.com/css/#grid-example-mixed-complete](http://getbootstrap.com/css/#grid-example-mixed-complete)

```
<div class="row">
  <div class="col-xs-12 col-sm-6 col-md-8">.col-xs-12 .col-sm-6 .col-md-8</div>
  <div class="col-xs-6 col-md-4">.col-xs-6 .col-md-4</div>
</div>
<div class="row">
  <div class="col-xs-6 col-sm-4">.col-xs-6 .col-sm-4</div>
  <div class="col-xs-6 col-sm-4">.col-xs-6 .col-sm-4</div>
  <!-- Optional: clear the XS cols if their content doesn't match in height -->
  <div class="clearfix visible-xs-block"></div>
  <div class="col-xs-6 col-sm-4">.col-xs-6 .col-sm-4</div>
</div>
```


###Move Column to the Right by .col-x-offset-#ofColumns

[http://getbootstrap.com/css/#grid-offsetting](http://getbootstrap.com/css/#grid-offsetting)

###Nesting Columns by adding a new .row

[http://getbootstrap.com/css/#grid-nesting](http://getbootstrap.com/css/#grid-nesting)

```
<div class="row">
  <div class="col-sm-6">
    Outer
    <div class="row">
      <div class="col-xs-6">Inner1</div>
      <div class="col-xs-6">Inner2</div>
    </div>
  </div>
  <div class="col-sm-6">
    xxx
  </div>
</div>
```

###Column Ordering (Useful???)
[http://getbootstrap.com/css/#grid-column-ordering](http://getbootstrap.com/css/#grid-column-ordering)

###Columns flow issues - .clearfix:

Add the extra clearfix for only the required viewport.

* Column reset: [http://getbootstrap.com/css/#grid-responsive-resets](http://getbootstrap.com/css/#grid-responsive-resets)

###Variables & Mixins for Grid
[http://getbootstrap.com/css/#grid-less](http://getbootstrap.com/css/#grid-less)

##Text Formatting

###Headings 
* h1 to h6 tag and use .h1 to .h6 for non-block
* Secondary text INSIDE Headings: small tag or .small

###Global default font-size, line-height applied to <body>

* variables.less: @font-size-base, @line-height-base
* default value: 14px, 1.428

###Inline text formatting

* Highlighted: mark tag
* Strikethrough: s, del tag
* Underlined: u tag
* Bold: strong, b tag
* Italics: em, i tag
* Smaller: small tag - 85% of the parent container.
* Inserted: ins tag

###Alignment .text-left/center/right/justify/nowrap

[http://getbootstrap.com/css/#type-alignment](http://getbootstrap.com/css/#type-alignment)

```
<p class="text-center">Center aligned text.</p>
```
*p.s. text-justify: changes spacing between words, only effect when line longer than page width.**

###Text Capitalization .text-lowercase/uppercase/capitalize
[http://getbootstrap.com/css/#type-transformation](http://getbootstrap.com/css/#type-transformation)

###Blockquotes for any HTML - <blockquote>

[http://getbootstrap.com/css/#type-blockquotes](http://getbootstrap.com/css/#type-blockquotes)

```
<blockquote>
  <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.</p>
</blockquote>
```

Override color: style="border-color: green"

##List

[http://getbootstrap.com/css/#type-lists](http://getbootstrap.com/css/#type-lists)

###Unordered

```
<ul>
  <li>...</li>
</ul>
```

###Ordered

```
<ol>
  <li>...</li>
</ol>
```

###Unstyled .list-unstyled

[http://getbootstrap.com/css/#unstyled](http://getbootstrap.com/css/#unstyled)

Remove the default list-style and left margin on list items (immediate children only).

```
<ul class="list-unstyled">
  <li>...</li>
</ul>
```

###Horizontal List - .list-inline all list items on a single line with light padding

[http://getbootstrap.com/css/#inline](http://getbootstrap.com/css/#inline)

```
<ul class="list-inline">
  <li>...</li>
</ul>
```

###Code - be sure to escape any angle brackets

* Inline - code tag

[http://getbootstrap.com/css/#code-inline](http://getbootstrap.com/css/#code-inline)

```
For example, <code>&lt;section&gt;</code> should be wrapped as inline.
```

* Block - pre tag

[http://getbootstrap.com/css/#code-block](http://getbootstrap.com/css/#code-block)

```
<pre>&lt;p&gt;Sample text here...&lt;/p&gt;</pre>
```

###Keyboard Input <kbd>
[http://getbootstrap.com/css/#code-user-input](http://getbootstrap.com/css/#code-user-input)

##Tables default .table

[http://getbootstrap.com/css/#tables](http://getbootstrap.com/css/#tables)

[http://plnkr.co/edit/jlb5uZzLLzkKRbImBQaa?p=preview](http://plnkr.co/edit/jlb5uZzLLzkKRbImBQaa?p=preview)

* Bordered (4 sides) Table: 
```
<table class="table table-bordered">
```
* Condensed Table: 
```
<table class="table table-condensed">
```
* Striped Rows: 
```
<table class="table table-striped">
```
* Hover Rows: 
```
<table class="table table-hover">
```
* Color Contextual Rows(tr)/Cells(td): .active/success/info/warning/danger (in order of importance)
[http://getbootstrap.com/css/#tables-contextual-classes](http://getbootstrap.com/css/#tables-contextual-classes)

###Responsive tables 

[http://getbootstrap.com/css/#tables-responsive](http://getbootstrap.com/css/#tables-responsive)

```
<div class="table-responsive"> 
  <table class="table"> ...
```

Create responsive tables by **wrapping** any .table in .table-responsive to make them scroll horizontally on xs devices.

###Image Shape
[http://getbootstrap.com/css/#images-shapes](http://getbootstrap.com/css/#images-shapes)

```
<img src="..." alt="..." class="img-rounded">
<img src="..." alt="..." class="img-circle">
<img src="..." alt="..." class="img-thumbnail">
```

###Other Image Layout Library

* [Masonry](http://masonry.desandro.com/)
* [Isotope](http://isotope.metafizzy.co/)
* [Salvattore](http://salvattore.com/) 
* [Compare](http://blog.fusioncharts.com/2014/09/comparing-jquery-grid-plugins-masonry-vs-isotope-vs-packery-vs-gridster-vs-shapeshift-vs-shuffle-js/)

##Colored Contextual Text/Background

Text:
[http://getbootstrap.com/css/#helper-classes-colors](http://getbootstrap.com/css/#helper-classes-colors)

Background
[http://getbootstrap.com/css/#helper-classes-backgrounds](http://getbootstrap.com/css/#helper-classes-backgrounds)

* .**text-muted**/primary/success/info/warning/danger
* .bg-primary/success/info/warning/danger

```
<p class="text-muted">...</p>
<p class="text-primary">...</p>
<p class="text-success">...</p>
<p class="text-info">...</p>
<p class="text-warning">...</p>
<p class="text-danger">...</p>

<p class="bg-primary">...</p>
<p class="bg-success">...</p>
<p class="bg-info">...</p>
<p class="bg-warning">...</p>
<p class="bg-danger">...</p>
```

##Showing and Hiding Content
.show 

.hidden

[http://getbootstrap.com/css/#helper-classes-show-hide](http://getbootstrap.com/css/#helper-classes-show-hide)

```html
<div class="show">...</div>
<div class="hidden">...</div>
```

##Responsive Utilities

###Show/Hide Utility Class
.visible-xs/sm/md/lg-block/inline/inline-block

.hidden-xs/sm/md/lg

[http://getbootstrap.com/css/#responsive-utilities-classes](http://getbootstrap.com/css/#responsive-utilities-classes)

###Testing Reponsive Visibility
Resize your browser or load on different devices to test the responsive utility classes.

* Visible: [http://getbootstrap.com/css/#visible-on...](http://getbootstrap.com/css/#visible-on...)
* Hidden: [http://getbootstrap.com/css/#hidden-on...](http://getbootstrap.com/css/#hidden-on...)

###Print Class
.visible-print-block/inline/inline-block

.hidden-print

[http://getbootstrap.com/css/#responsive-utilities-print](http://getbootstrap.com/css/#responsive-utilities-print)


##Close Icon - .close and &times; Useful???
[http://getbootstrap.com/css/#helper-classes-close](http://getbootstrap.com/css/#helper-classes-close)

Use the generic close icon for dismissing content like modals and alerts.

```
<button type="button" class="close">&times;</button>
```

##Carets - .caret Useful???
[http://getbootstrap.com/css/#helper-classes-carets](http://getbootstrap.com/css/#helper-classes-carets)

##Quick floats - .pull-left/right
[http://getbootstrap.com/css/#helper-classes-floats](http://getbootstrap.com/css/#helper-classes-floats)

##Center Content Blocks - .center-block
[http://getbootstrap.com/css/#helper-classes-center](http://getbootstrap.com/css/#helper-classes-center)

##Clearfix - .clearfix
[http://getbootstrap.com/css/#helper-classes-clearfix](http://getbootstrap.com/css/#helper-classes-clearfix)


##Using Less
[http://getbootstrap.com/css/#less](http://getbootstrap.com/css/#less)
