#Bootstrap.Plugins

[Demo](http://plnkr.co/edit/S4Uujof15vkrlANWO9sf?p=preview)

##Dropdown

Add dropdown menus to nearly anything e.g navbar, tabs, and pills

```
  <div class="dropdown">
    <button id="dLabel" type="button" class="btn btn-primary" data-toggle="dropdown">
      Dropdown
      <span class="caret"></span>
    </button>
    <ul class="dropdown-menu">
      <li><a href="#">HTML</a></li>
      <li><a href="#">CSS</a></li>
      <li class="divider"></li>
      <li><a href="#">JavaScript</a></li>
    </ul>    
  </div>

```

##Modal

Modal is just an element on the page which bootstrap toggle its visibility. All Modal elements (e.g. input) can be accessed directly without using the traditional 'parameter passing'

To take advantage of the Bootstrap grid system within a modal, just nest .rows within the .modal-body and then use the normal grid system classes.

```
  <!-- Button trigger modal -->
  <!--data-toggle="modal" data-target data-modalparams-->
  <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModalId" data-modalparams="myParams123" >
    Launch demo modal
  </button>

<div>
<b>Hidden Value:</b> 'Passing this param into Modal via Hidden Input'
<input type="hidden" id="myParam" value="Passing this param into Modal via Hidden Input">
</div>
<div>
  <b>Result from Modal:</b> <span id="modalResultId"></span>
</div>


  <!-- Modal fade + id -->
  <div class="modal fade" id="myModalId" tabindex="-1">
    <!--modal-dialog-->
    <div class="modal-dialog">
      <!--modal-content-->
      <div class="modal-content">
        <!--modal-header-->
        <div class="modal-header">
          <!--close: data-dismiss="modal"-->
          <button type="button" class="close" data-dismiss="modal"><span>&times;</span></button>
          <h4 class="modal-title">Modal title</h4>
        </div>
        <!--modal-body-->
        <div class="modal-body">
          Modal body
            <div class="form-group">
              <label for="recipient-name" class="control-label">Recipient:</label>
              <input type="text" class="form-control" id="recipient-name">
            </div>
        </div>
        <!--modal-footer-->
        <div class="modal-footer">
          <!--close: data-dismiss="modal"-->
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary" id="SaveId" data-dismiss="modal">Save changes</button>
        </div>
      </div>
    </div>
  </div>
```

Manually open a Modal with Javascript

[Documentation](http://getbootstrap.com/javascript/#via-javascript)

```
$('#myModal').modal('show')  
```

Passing Values in and out of the Modal **without** traditional **parameter** passing.

```
$(document).ready(function() {
  $('#myModalId').on('show.bs.modal', function(event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    //var recipient = button.data('modalparams') // Extract info from data-* attributes of Trigger button
    var recipient = $('#myParam').val();
      // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    var modal = $(this)
    modal.find('.modal-title').text('New Param: ' + recipient)
    modal.find('.modal-body input').val(recipient)
  })
  
  $('#SaveId').on('click', function(e){
    $('#modalResultId').text($('#recipient-name').val());
  })

});
```

##Collapse

Just add `data-toggle="collapse"` and a `data-target` for `button`  /  `href="#selector"` for `<a>`to the element to automatically assign control of a collapsible element. The data-target attribute accepts a CSS selector to apply the collapse to. Be sure to add the `class="collapse"` to the collapsible element. 

If you'd like it to default open, add the additional class `in`.

```
  // .in will keep the target opened
  <a class="btn btn-primary" data-toggle="collapse in" href="#collapseElementId">
  Link with data-toggle="collapse" & href
  </a>
  <div class="collapse" id="collapseElementId">
    <div class="well">
      Lorem ipsum dolor sit amet, consectetur adipiscing elit.
    </div>
  </div>
```

##Accordion

To add accordion-like group management to a collapsible control, add the data attribute `data-parent="#selector"`

```
    <!--panel-group + id-->
    <div class="panel-group" id="accordion"  >
        <!--panel-->
        <div class="panel panel-default">
            <!--panel-heading-->
            <div class="panel-heading">
                <!--panel-title-->
                <h4 class="panel-title">
                    <!--collapse plugin attributes + data-parent-->
                    <a data-toggle="collapse" href="#collapseOne" data-parent="#accordion"  >
                        Collapsible Group Item #1
                    </a>
                </h4>
            </div>
            <!--collapse plugin attributes + panel-collapse-->
            <div id="collapseOne" class="panel-collapse collapse in"  >
                <div class="panel-body">
                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute.
                </div>
            </div>
        </div>

```


##Tab

```
    <!-- Nav tabs -->
    <ul class="nav nav-tabs nav-justified">
      <li class="active"><a href="#home" data-toggle="tab">Home</a></li>
      <li><a href="#profile" data-toggle="tab">Profile</a></li>
      <li><a href="#messages" data-toggle="tab">Messages</a></li>
      <li><a href="#settings" data-toggle="tab">Settings</a></li>
    </ul>

    <!-- Tab panes -->
    <div class="tab-content">
      <div class="well tab-pane well fade in active" id="home">
        1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ligula enim, venenatis eget felis vitae
      </div>
      <div class="well tab-pane fade" id="profile">
        2 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ligula enim, venenatis eget felis vitae
      </div>
      <div class="well tab-pane fade" id="messages">
        3 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ligula enim, venenatis eget felis vitae
      </div>
      <div class="well tab-pane fade" id="settings">
        4 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ligula enim, venenatis eget felis vitae
      </div>
    </div>

```

You can activate individual tabs in several ways:

```
$('#myTabs a[href="#profile"]').tab('show') // Select tab by name
```

##Tooltip

```
<div class="tooltipEnable">
  <button type="button" class="btn btn-default" data-toggle="tooltip" title="Tooltip on top">Tooltip</button>  
</div>
<div class="tooltipEnable">
  <button type="button" class="btn btn-default" data-toggle="tooltip" title="Just Clicked" data-trigger="focus">Tooltip Triggered by Click</button>  
</div>
<div class="tooltipEnable">
  <button type="button" class="btn btn-default" data-toggle="tooltip" data-html="true"
    title="<img src='http://www.technobuffalo.com/wp-content/uploads/2015/04/star-wars-the-force-awakens-bb8-daisy-ridley.jpeg' class='img-responsive'>" >Tooltip with Html</button>  
</div>
<div class="tooltipNotEnable">
  <button type="button" class="btn btn-default" data-toggle="tooltip" title="Tooltip won't show">Tooltip on top</button>  
</div>
```

```
// To avoid performace issue, only opt-in the qualified .tooltipEnable 's tooltip plugin
  $('.tooltipEnable [data-toggle="tooltip"]').tooltip()
```

Use the `trigger="focus"` to dismiss popovers on the next click that the user makes anywhere on the page.


[How to close a Twitter Bootstrap popover/alert by clicking outside](https://jsfiddle.net/mattdlockyer/C5GBU/2/)

[Reference: Tooltip Options](http://getbootstrap.com/javascript/#tooltips-options)

##Popover

```
<div class="popoverEnable">
  <a tabindex="0" class="btn btn-primary" data-toggle="popover" data-trigger="focus" title="Popover Title" data-content="Popover Body">Dismissible popover</a>  
</div>
```

```
// To avoid performace issue, only enable the qualified .popoverEnable's popover plugin
$(function () {
  $('.popoverEnable [data-toggle="popover"]').popover()
})
```

Use the `trigger="focus"` to dismiss popovers on the next click that the user makes anywhere on the page.

[Reference: Popover Options](http://getbootstrap.com/javascript/#popovers-options)

##Alert

##Carousel

[Reference](http://getbootstrap.com/javascript/#carousel)

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
        <img src="http://ia.media-imdb.com/images/M/MV5BNTg1NDQ0MTI1NV5BMl5BanBnXkFtZTgwMTk0ODUzNTE@._V1__SX1617_SY873_.jpg"  class='img-responsive' alt="1">
        <div class="carousel-caption">
          carousel-caption 1
        </div>
      </div>
      <div class="item">
        <img src="http://ia.media-imdb.com/images/M/MV5BMjM3NDYxMDkwMl5BMl5BanBnXkFtZTgwNjQzMTY1MzE@._V1__SX1617_SY873_.jpg"  class='img-responsive' alt="2">
        <div class="carousel-caption">
          carousel-caption 2
        </div>
      </div>
      <div class="item">
        <img src="http://ia.media-imdb.com/images/M/MV5BOTgwNTEwNDkwNV5BMl5BanBnXkFtZTgwMzQzMTY1MzE@._V1__SX1617_SY873_.jpg"  class='img-responsive' alt="3">
        <div class="carousel-caption">
          carousel-caption 3
        </div>
      </div>
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