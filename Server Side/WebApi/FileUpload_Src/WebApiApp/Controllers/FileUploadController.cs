#define FILEIO

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiApp.Controllers
{


    [EnableCors(origins: "http://localhost:49213", headers: "*", methods: "*")]
    public class FileUploadController : ApiController
    {
        public async Task<IHttpActionResult> Post()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            
            try
            {
#if FILEIO
                // File I/O
                string root = HttpContext.Current.Server.MapPath("~/Upload");
                var provider = new MultipartFormDataStreamProvider(root);

                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Debug.WriteLine(file.Headers.ContentDisposition.FileName);
                    Debug.WriteLine("Server file path: " + file.LocalFileName);
                }

                // Show all the key-value pairs.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        Debug.WriteLine(string.Format("{0}: {1}", key, val));
                    }
                }

#else
                // Memory Stream
                // Need custom provider if you need to access the FormData
                // google 'multipartmemorystreamprovider formdata'
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (HttpContent ctnt in provider.Contents)
                {
                    //now read individual part into STREAM
                    var stream = await ctnt.ReadAsStreamAsync();
                    if (stream.Length != 0)
                    {
                        //handle the stream here
                    }
                }
#endif

                return Ok();
            }
            catch (System.Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e));
            }
        }
    }
}