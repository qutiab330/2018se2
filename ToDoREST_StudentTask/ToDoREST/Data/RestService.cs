using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToDoREST
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<TodoItem> Items { get; private set; }

        public RestService()
        {
            #region forbasicauthentication
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
            #endregion
        }

        public async Task <List<TodoItem>> RefreshDataAsync()
        {
            Items = new List<TodoItem>();
            #region use_RESTAPI_to_get_data
            var uri = new Uri(string.Format(Constants.RestUrl + "/tables/TodoItem", string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                    Debug.WriteLine(@"              SUCCESS fetching items");

                } else {
                    Debug.WriteLine(@"               ERROR while fetching items: {0}", response.StatusCode); 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR Exception Caught while fetching items: {0}", ex.Message);
            }
            #endregion
            return Items;
        }

        public async Task SaveTodoItemAsync(TodoItem item)
        {
            #region use_RESTAPI_to_save_data_in_database

            #endregion
        }



        public async Task DeleteTodoItemAsync(string id)
        {
            #region use_RESTAPI_to_delete_data

            #endregion
        }


    }
}
