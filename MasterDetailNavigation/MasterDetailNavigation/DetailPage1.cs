using System;

using Xamarin.Forms;

namespace MasterDetailNavigation
{
    public class DetailPage1 : ContentPage
    {
        public DetailPage1()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

