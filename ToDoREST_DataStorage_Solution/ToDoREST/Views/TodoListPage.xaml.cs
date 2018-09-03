using System;
using Xamarin.Forms;

namespace ToDoREST
{
	public partial class TodoListPage : ContentPage
	{

		public TodoListPage ()
		{
			InitializeComponent ();
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();
            
			var items = await App.TodoManager.GetTasksAsync();
            listView.ItemsSource = items;
            App.TodoManager.CurrentItems = items;
		}

		void OnAddItemClicked (object sender, EventArgs e)
		{
            var todoItem = new TodoItem();
			var todoPage = new TodoItemPage (true);
			todoPage.BindingContext = todoItem;
			Navigation.PushAsync (todoPage);
		}

		void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var todoItem = e.SelectedItem as TodoItem;
			var todoPage = new TodoItemPage ();
			todoPage.BindingContext = todoItem;
			Navigation.PushAsync (todoPage);
		}
	}
}
