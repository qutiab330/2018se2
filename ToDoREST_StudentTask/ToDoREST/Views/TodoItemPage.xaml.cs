using System;
using Xamarin.Forms;

namespace ToDoREST
{
	public partial class TodoItemPage : ContentPage
	{
		public TodoItemPage (bool isNew = false)
		{
			InitializeComponent ();
		}

        async void OnSaveUpdateActivated(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;

            if (todoItem.Text == null)
            {
                await DisplayAlert("Alert", "Task name cannot be empty!", "OK");
            }
            else if (todoItem.Text.Trim() == "")
            {
                await DisplayAlert("Alert", "Task name cannot be empty!", "OK");
            }
            else
            {
                if (todoItem.Id == null) //save mode
                {
                    await App.TodoManager.SaveTaskAsync(todoItem);
                }
                await Navigation.PopAsync();

            }
        }

		async void OnDeleteActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.DeleteTaskAsync (todoItem);
			await Navigation.PopAsync ();
        }

		void OnCancelActivated (object sender, EventArgs e)
		{
			Navigation.PopAsync ();
		}

		void OnSpeakActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			App.Speech.Speak (todoItem.Text + " " + todoItem.Text);
		}
	}
}
