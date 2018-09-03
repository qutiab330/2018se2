using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoREST
{
	public class TodoItemManager
	{
		IDataService restService;
        public List<TodoItem> CurrentItems { get; set; }

		public TodoItemManager (IDataService service)
		{
			restService = service;
		}

		public Task<List<TodoItem>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}

        public Task SaveTaskAsync(TodoItem item)
        {
            return restService.SaveTodoItemAsync(item);
        }

        public Task DeleteTaskAsync (TodoItem item)
		{
            return restService.DeleteTodoItemAsync (item.Id);
		}
	}
}
