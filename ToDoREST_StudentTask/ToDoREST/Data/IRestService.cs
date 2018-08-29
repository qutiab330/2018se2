using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoREST
{
	public interface IRestService
	{
		Task<List<TodoItem>> RefreshDataAsync ();

		Task SaveTodoItemAsync (TodoItem item);

        //Task UpdateTodoItemAsync(TodoItem item);

        Task DeleteTodoItemAsync (string id);
	}
}
