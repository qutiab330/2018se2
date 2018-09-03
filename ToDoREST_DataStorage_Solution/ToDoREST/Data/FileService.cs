using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToDoREST
{
    public class FileService : IDataService
    {
        bool hasBeenUpdated = false;
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "items.json");

        public FileService()
        {
        }

        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoItem>> RefreshDataAsync()
        {
            return Task.Run(() => {
                TodoItem[] items = {};
                string json;

                if (hasBeenUpdated == false) {
                    // Debbuging help to identofy names of files and if they have been correctly packaged
                    string[] res = this.GetType().Assembly.GetManifestResourceNames();
                    Debug.WriteLine("              {0}", res);

                    var assembly = IntrospectionExtensions.GetTypeInfo(this.GetType()).Assembly;

                    Stream stream = assembly.GetManifestResourceStream("ToDoREST.items.json");

                    using (var reader = new System.IO.StreamReader(stream))
                    {

                        json = reader.ReadToEnd();

                    }
                } else {
                    json = File.ReadAllText(fileName);
                }

                if (json != null)
                {
                    var rootobject = JsonConvert.DeserializeObject<Rootobject>(json);
                    items = rootobject.items;
                }
                return items.ToList();
            });
        }

        public Task<TodoItem> RefreshItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(TodoItem item)
        {
            return Task.Run(() =>
            {
                List<TodoItem> items = App.TodoManager.CurrentItems;

                TodoItem[] itemsArr = items.ToArray<TodoItem>();
                Rootobject rootobject = new Rootobject();
                rootobject.items = itemsArr;
                var json = JsonConvert.SerializeObject(rootobject);

                File.WriteAllText(fileName, json);
                hasBeenUpdated = true;
            });
        }

    }
}
