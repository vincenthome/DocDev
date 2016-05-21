# Bootstrap.Form

##Controls
[http://plnkr.co/edit/lcZKycR5d7EiOq9YTIpC?p=preview](http://plnkr.co/edit/lcZKycR5d7EiOq9YTIpC?p=preview)

###div .form-group input .form-control
```html
<div class="form-group">
  <label for="inputText">Regular Text: type="text"</label>
  <input type="text" class="form-control" id="inputText" placeholder="...">
</div>
```

###Static Form Control: div .form-group p .form-control-static
```html
<div class="form-group">
  <label for="staticControl">Static Control Label</label>
  <p class="form-control-static" id="staticControl">p .form-control-static</p>
</div>
```

###Control Size - .input-lg .input-sm 

###Checkbox & Radio button

Since it doesn't need .form-group it uses div instead

* div .checkbox input type="checkbox"
* div .radio input type="radio"

```html
<div class="checkbox">
  <label>
    <input type="checkbox" id="inputCheckbox1" value="checkbox1">Option one is this and that&mdash;be sure to include why it's great
  </label>
</div>
<div class="checkbox disabled">
  <label>
    <input type="checkbox" id="inputCheckbox2" value="checkbox2" disabled>Option two is disabled
  </label>
</div>

<div class="radio">
  <label>
    <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked>Option one is this and that&mdash;be sure to include why it's great
  </label>
</div>
<div class="radio">
  <label>
    <input type="radio" name="optionsRadios" id="optionsRadios2" value="option2">Option two can be something else and selecting it will deselect option one
  </label>
</div>
<div class="radio disabled">
  <label>
    <input type="radio" name="optionsRadios" id="optionsRadios3" value="option3" disabled>Option three is disabled
  </label>
</div>
```

###Inline Form

form .form-inline

###Horizontal Form

from .form-horizontal

###Inline Checkboxes and Radio Buttons

* label .checkbox-inline
* label .radio-inline

```html
<div>
  <label class="checkbox-inline">
    <input type="checkbox" id="inlineCheckbox1" value="option1">inline check 1
  </label>
  <label class="checkbox-inline">
    <input type="checkbox" id="inlineCheckbox2" value="option2">inline check 2
  </label>
</div>
<div>
  <label class="radio-inline">
    <input type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1">inline radio 1
  </label>
  <label class="radio-inline">
    <input type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2">inline radio 2
  </label>
</div>
```

###Validation Feedback

* For textbox: .form-group .has-xContextual
* For checkbox/radio: which has NO form-group: div .has-xContextual

```html
<div class="form-group has-success">
  <label class="control-label" for="inputSuccess1">.form-group .has-success</label>
  <input type="text" class="form-control" id="inputSuccess1">
</div>

<div class="has-error">
  <div class="checkbox">
    <label>
      <input type="checkbox" id="checkboxError" value="option1">div .has-error
    </label>
  </div>
</div>
```

####Add feedback Icons(Ok,Warning,Error) on the right of a textbox

* .form-group .has-xContextual **.has-feedback**
* input span .glyphicon .glyphicon-* **.form-control-feedback**

```html
<div class="form-group has-warning has-feedback">
  <label class="control-label" for="inputWarning2">Warning</label>
  <input type="text" class="form-control" id="inputWarning2">
  <span class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
  <span id="inputWarning2Status">(warning)</span>
</div>
```

###A Responsive 2x3 Grid Form

A 2 columns by 3 rows gird with nested a row of 2 columns

[http://plnkr.co/edit/laxy7voPNMBz4hE0jCNr?p=preview](http://plnkr.co/edit/laxy7voPNMBz4hE0jCNr?p=preview) 

```html
<form class="form-horizontal">
  <div class="row">
    <div class="col-xs-12 col-sm-6">
      <div class="row">
        <div class="form-group">
          <label for="inputEmail3" class="col-xs-12 col-sm-3 control-label">Email1</label>
          <div class="col-xs-12 col-sm-9">
            <input type="email" class="form-control" id="inputEmail3" placeholder="Email1">
          </div>
        </div>
        <div class="form-group">
          <label for="inputPassword3" class="col-xs-12 col-sm-3 control-label">Password1</label>
          <div class="col-xs-12 col-sm-9">
            <input type="password" class="form-control" id="inputPassword3" placeholder="Password1">
          </div>
        </div>
      </div>
    </div>

    <div class="col-xs-12 col-sm-6">
      <div class="row">
        <div class="form-group">
          <label for="inputEmail3" class="col-xs-12 col-sm-3 control-label">Email2</label>
          <div class="col-xs-12 col-sm-9">
            <input type="email" class="form-control" id="inputEmail3" placeholder="Email2">
          </div>
        </div>
        <div class="form-group">
          <label for="inputPassword3" class="col-xs-12 col-sm-3 control-label">Password2</label>
          <div class="col-xs-12 col-sm-9">
            <input type="password" class="form-control" id="inputPassword3" placeholder="Password2">
          </div>
        </div>
      </div>
    </div>

  </div>
  <div class="row">
    <div class="col-xs-12 col-sm-6">
      <div class="form-group">
        <div class="col-sm-offset-3">
          <div class="checkbox">
            <label>
              <input type="checkbox">Remember me
            </label>
          </div>
        </div>
      </div>

    </div>

  </div>
  <div class="row">
    <div class="col-xs-12 col-sm-6">
      <div class="form-group">
        <div class="col-sm-offset-3">
          <button type="submit" class="btn btn-default">Sign in</button>
        </div>
      </div>

    </div>
  </div>

</form>
```