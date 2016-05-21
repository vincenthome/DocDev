(function () {

    ///////////////////////////////
    // Simple Type

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

    ///////////////////////////////
    // Complex Type

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

    $("#GetAllComplexRequest").click(function (e) {

        $.ajax({
            url: "/api/complextypevalues",
            type: "GET",
            dataType: "json" // aka Accept
        })
        .done(function (data, textStatus, jqXHR) {
            $('#GetAllComplexoutput').text(JSON.stringify(data));
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            $('#GetAllComplexoutput').html('Bummer: there was an error: ' + textStatus);
        });
    });

    $("#GetIdComplexRequest").click(function (e) {

        $.ajax({
            url: "/api/complextypevalues/42",
            type: "GET",
            dataType: "json" // aka Accept
        })
        .done(function (data, textStatus, jqXHR) {
            $('#GetIdComplexoutput').html(JSON.stringify(data));
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            $('#GetIdComplexoutput').html('Bummer: there was an error: ' + textStatus);
        });

    });

    $("#PostComplexRequest").click(function (e) {

        $.ajax({
            url: "/api/complextypevalues",
            type: "POST",
            dataType: "json", // aka Accept
            contentType: "application/json",
            data: JSON.stringify(postData)
        })
        .done(function (data, textStatus, jqXHR) {
            $('#PostComplexoutput').html(data);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            $('#PostComplexoutput').html('Bummer: there was an error: ' + textStatus);
        });
    });

    $("#PutComplexRequest").click(function (e) {

        $.ajax({
            url: "/api/complextypevalues/42",
            type: "PUT",
            dataType: "json", // aka Accept
            contentType: "application/json",
            data: JSON.stringify(putData)
        })
        .done(function (data, textStatus, jqXHR) {
            $('#PutComplexoutput').html(data);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            $('#PutComplexoutput').html('Bummer: there was an error: ' + textStatus);
        });

    });

    $("#DeleteComplexRequest").click(function (e) {

        $.ajax({
            url: "/api/complextypevalues/42",
            type: "DELETE",
            dataType: "json", // aka Accept
            contentType: "application/json"
        })
        .done(function (data, textStatus, jqXHR) {
            $('#DeleteComplexoutput').html(data);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            $('#DeleteComplexoutput').html('Bummer: there was an error: ' + textStatus);
        });
    });



}());
