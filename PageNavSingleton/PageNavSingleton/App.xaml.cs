using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PageNavSingleton
{
    public partial class App : Application
    {
        private ContentPage mainPage;
        public App()
        {
            InitializeComponent();
            mainPage = new MainPage();
            MainPage = new NavigationPage(mainPage);

            PageNavigationManager.Instance.Navigation = MainPage.Navigation;
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
