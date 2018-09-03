using SQLite;

namespace ToDoREST
{
	public class TodoItem 
	{
        [PrimaryKey, Unique]
        public string Id { get; set; }
        public string Text { get; set; }

        public bool Complete { get; set; }
    }

    public class Rootobject
    {
        public TodoItem[] items { get; set; }
    }
}
