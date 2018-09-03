using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoREST
{
	public interface IDataService
	{
		Task<List<TodoItem>> RefreshDataAsync ();

        Task SaveTodoItemAsync (TodoItem item);

        Task DeleteTodoItemAsync (string id);


	}
}
