using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ToDoREST
{
    public partial class App : Application
    {
        public static TodoItemManager TodoManager { get; private set; }


        public App()
        {
            InitializeComponent();

            //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3");
            //TodoManager = new TodoItemManager(new DBService(dbPath));
            TodoManager = new TodoItemManager(new FileService());

            MainPage = new NavigationPage(new TodoListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
