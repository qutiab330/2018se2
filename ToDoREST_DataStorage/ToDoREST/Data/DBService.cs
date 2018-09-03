
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ToDoREST
{
    public class DBService : IDataService
    {
        readonly SQLiteAsyncConnection database;

        public DBService(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
        }

        public Task DeleteTodoItemAsync(string id)
        {
            return database.ExecuteScalarAsync<int>("DELETE FROM TodoItem WHERE ID=?", id); // using SQL statements

            // Alternative using Linq, but which requires the entire item:
            //return database.DeleteAsync(item);
        }

        public Task<List<TodoItem>> RefreshDataAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }

        public Task<TodoItem> RefreshItemAsync(string id)
        {
            return database.Table<TodoItem>().Where(i => i.Id == id).FirstOrDefaultAsync(); // using Linq
        }

        public Task SaveTodoItemAsync(TodoItem item)
        {
            if (item.Id != null)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                item.Id = DateTime.Now.GetHashCode().ToString();
                return database.InsertAsync(item);

            }
        }

    }
}
