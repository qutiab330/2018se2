using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PageNavSingleton
{
    public class ViewModel
    {
        private PageNavigationManager navManager;

        public ICommand ButtonClickedCommand { protected set; get; }

        public ViewModel()
        {
            navManager = PageNavigationManager.Instance;

            ButtonClickedCommand = new Command(() =>
            {
                navManager.showDetailPage();
            });
        }
    }
}
