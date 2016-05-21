# WebApi.FileUpload

##Todo: 'ajax ReadAsMultipartAsync'

[http://www.asp.net/web-api/overview/advanced/sending-html-form-data,-part-2](http://www.asp.net/web-api/overview/advanced/sending-html-form-data,-part-2)

##File Upload and Multipart MIME

This form contains a text input control and a file input control. When a form contains a file input control, the **enctype** attribute should always be "**multipart/form-data**", which specifies that the form will be sent as a multipart MIME message.

```html
<form name="form1" method="post" enctype="multipart/form-data" action="api/upload">
    <div>
        <label for="caption">Image Caption</label>
        <input name="caption" type="text" />
    </div>
    <div>
        <label for="image1">Image File</label>
        <input name="image1" type="file" />
    </div>
    <div>
        <input type="submit" value="Submit" />
    </div>
</form>
```

The MIME message is divided into two parts, one for each form control. Part boundaries are indicated by the lines that start with dashes.

Each message part contains one or more headers, followed by the part contents.

* The Content-Disposition header includes the name of the control. For files, it also contains the file name.
* The Content-Type header describes the data in the part. If this header is omitted, the default is text/plain.

Sample multipart MIME message
```
POST http://localhost:50460/api/values/1 HTTP/1.1
User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8
Accept-Language: en-us,en;q=0.5
Accept-Encoding: gzip, deflate
Content-Type: multipart/form-data; boundary=---------------------------41184676334
Content-Length: 29278

-----------------------------41184676334
Content-Disposition: form-data; name="caption"

Summer vacation
-----------------------------41184676334
Content-Disposition: form-data; name="image1"; filename="GrandCanyon.jpg"
Content-Type: image/jpeg

(Binary data not shown)
-----------------------------41184676334--
```


Notice that the controller action does not take any parameters. That's because we process the request body inside the action, without invoking a media-type formatter.

The MultipartFormDataStreamProvider class is a helper object that allocates file streams for uploaded files. To read the multipart MIME message, call the ReadAsMultipartAsync method. This method extracts all of the message parts and writes them into the streams provided by the MultipartFormDataStreamProvider.

When the method completes, you can get information about the files from the FileData property, which is a collection of MultipartFileData objects.

* MultipartFileData.FileName is the local file name on the server, where the file was saved.
* MultipartFileData.Headers contains the part header (not the request header). You can use this to access the Content_Disposition and Content-Type headers.

