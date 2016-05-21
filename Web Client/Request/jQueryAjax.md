#Using jQuery $.ajax to GET POST PUT and DELETE

##Html

```html

<div class="row">
    <a href="#" id="GetAllRequest" class="btn btn-primary" > Get All test </a>
    <div id="GetAlloutput">waiting for action</div>
</div>

<div class="row">
    <a href="#" id="GetIdRequest" class="btn btn-primary"> Get Id test </a>
    <div id="GetIdoutput">waiting for action</div>
</div>

<div class="row">
    <a href="#" id="PostRequest" class="btn btn-primary"> Post test </a>
    <div id="Postoutput">waiting for action</div>
</div>

<div class="row">
    <a href="#" id="PutRequest" class="btn btn-primary"> Put Id test </a>
    <div id="Putoutput">waiting for action</div>
</div>

<div class="row">
    <a href="#" id="DeleteRequest" class="btn btn-primary"> Delete Id test </a>
    <div id="Deleteoutput">waiting for action</div>
</div>

@*Include this AFTER jquery.js
<script src="~/Scripts/app.js"></script>*@

```

##jQuery Ajax

```javascript

(function() {
    $("#GetAllRequest").click(function (e) {

        $.ajax({
            url: "/api/values",
            type: "GET",
            dataType: "json" // aka Accept
        })
        .done(function (data, textStatus, jqXHR) {
            $('#GetAlloutput').html(data);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            $('#GetAlloutput').html('Bummer: there was an error: ' + textStatus);
        });
    });

    $("#GetIdRequest").click(function (e) {

        $.ajax({
            url: "/api/values/42",
            type: "GET",
            dataType: "json" // aka Accept
        })
        .done(function (data, textStatus, jqXHR) {
            $('#GetIdoutput').html(data);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            $('#GetIdoutput').html('Bummer: there was an error: ' + textStatus);
        });

    });

    $("#PostRequest").click(function (e) {

        $.ajax({
            url: "/api/values",
            type: "POST",
            dataType: "json", // aka Accept
            contentType: "application/json",
            data: "\"myData\""
        })
        .done(function (data, textStatus, jqXHR) {
            $('#Postoutput').html(data);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            $('#Postoutput').html('Bummer: there was an error: ' + textStatus);
        });
    });

    $("#PutRequest").click(function (e) {

        $.ajax({
            url: "/api/values/42",
            type: "PUT",
            dataType: "json", // aka Accept
            contentType: "application/json",
            data: "\"myData\""
        })
        .done(function (data, textStatus, jqXHR) {
            $('#Putoutput').html(data);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            $('#Putoutput').html('Bummer: there was an error: ' + textStatus);
        });

    });

    $("#DeleteRequest").click(function (e) {

        $.ajax({
            url: "/api/values/42",
            type: "DELETE",
            dataType: "json", // aka Accept
            contentType: "application/json"
        })
        .done(function (data, textStatus, jqXHR) {
            $('#Deleteoutput').html(data);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            $('#Deleteoutput').html('Bummer: there was an error: ' + textStatus);
        });
    });


}());

```
