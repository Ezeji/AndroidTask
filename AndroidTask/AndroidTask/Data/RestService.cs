using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AndroidTask.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AndroidTask.Data
{
    public class RestService : IRestService
    {

        private readonly HttpClient client;

        public List<GithubJavaGeeks.Item> Items { get; private set; }

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<List<GithubJavaGeeks.Item>> RefreshDataAsync()
        {
            Items = new List<GithubJavaGeeks.Item>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    GithubJavaGeeks.Root root = JsonConvert.DeserializeObject<GithubJavaGeeks.Root>(content);
                    Items = root.Items;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}
