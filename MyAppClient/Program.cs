using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MyAppService;
using lab_2_web_design;
using lab_2_web_design.Models;

namespace MyAppClient
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:10213/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var users = await GetUsersAsync("users");

            if (users != null)
            {
                foreach (var user in users)
                {
                    Console.WriteLine(string.Format("{0} {1}", user.FirstName, user.LastName));
                }
            }
            Console.ReadLine();
        }
        static async Task<IEnumerable<User>> GetUsersAsync(string path)
        {
            IEnumerable<User> users = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<List<User>>();
            }
            return users;
        }
    }

    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

