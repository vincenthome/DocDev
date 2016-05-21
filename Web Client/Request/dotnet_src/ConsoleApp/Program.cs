using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => await GetAllRequestAsync()).Wait();
            Task.Run(async () => await GetIdRequestAsync()).Wait();
            Task.Run(async () => await PostRequestAsync()).Wait();
            Task.Run(async () => await PutRequestAsync()).Wait();
            Task.Run(async () => await DeleteRequestAsync()).Wait();
            
            // Are the running i parallel or not?????
            //Task[] ta = new Task[5];
            //ta[0] = GetAllRequestAsync();
            //ta[1] = GetIdRequestAsync();
            //ta[2] = PostRequestAsync();
            //ta[3] = PutRequestAsync();
            //ta[4] = DeleteRequestAsync();
            //Task.WaitAll(ta);
        }

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


    }
}
