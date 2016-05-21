# HttpClient.NET
Use HttpClient to send GET POST PUT and Delete to WebApi.
[http://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client](http://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client)

Install-Package Microsoft.AspNet.WebApi.Client

```csharp

// Using it
Task.Run(async () => await GetAllRequestAsync()).Wait();

static async Task GetAllRequestAsync()
{
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:51578/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync("api/values");
        if (response.IsSuccessStatusCode)
        {
            List<string> body = await response.Content.ReadAsAsync<List<string>>();
            Console.WriteLine(body.Aggregate((c,n) => c + ", " + n));
        }
    }
}

static async Task GetIdRequestAsync()
{
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:51578/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync("api/values/42");
        if (response.IsSuccessStatusCode)
        {
            string body = await response.Content.ReadAsAsync<string>();
            Console.WriteLine(body);
        }
    }
}

static async Task PostRequestAsync()
{
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:51578/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.PostAsJsonAsync<string>("api/values","postme please");
        if (response.IsSuccessStatusCode)
        {
            string body = await response.Content.ReadAsAsync<string>();
            Console.WriteLine(body);
        }
    }
}

static async Task PutRequestAsync()
{
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:51578/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.PutAsJsonAsync<string>("api/values/42", "putme please");
        if (response.IsSuccessStatusCode)
        {
            string body = await response.Content.ReadAsAsync<string>();
            Console.WriteLine(body);
        }
    }
}

static async Task DeleteRequestAsync()
{
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:51578/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.DeleteAsync("api/values/42");
        if (response.IsSuccessStatusCode)
        {
            string body = await response.Content.ReadAsAsync<string>();
            Console.WriteLine(body);
        }
    }
}
```