using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoREST
{
	public class TodoItemManager
	{
		IRestService restService;

		public TodoItemManager (IRestService service)
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

        //public Task UpdateTaskAsync(TodoItem item)
        //{
            //return restService.UpdateTodoItemAsync(item);
        //}

        public Task DeleteTaskAsync (TodoItem item)
		{
            return restService.DeleteTodoItemAsync (item.Id);
		}
	}
}
