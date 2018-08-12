using System;
using Xamarin.Forms;

namespace PageNavSingleton
{
    public class PageNavigationManager
    {
        private static PageNavigationManager instance;
        private INavigation navigation;

        private PageNavigationManager() { }

        public static PageNavigationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PageNavigationManager();
                }
                return instance;
            }
        }

        public INavigation Navigation
        {
            set { navigation = value; }
        }


        // Methods for page switching
        public void showDetailPage()
        {
            navigation.PushAsync(new DetailPage());
        }

    }
}
