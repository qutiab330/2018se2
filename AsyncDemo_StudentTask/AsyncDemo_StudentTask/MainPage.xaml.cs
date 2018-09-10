using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AsyncDemo_StudentTask
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnStart.Clicked += async (sender, e) =>
            {

                //Calling async method for downloading web page ..
                Task<string> webPageRead;
                // .. write code here....

                txtStatus.Text += "Downloading web page..\n";


                //Calling async method for reading text file ..
                // .. write code here

                txtStatus.Text += "Reading text file..\n";


                string webPageContent = await webPageRead;

            };
        }


        #region DOWNLOAD WEB PAGE

        public async Task<string> DownLoadWebPage()
        {
            String webContent;
            // ... write code here ...

            txtStatus.Text += "Download completed.. Total length: \n" + webContent.Length.ToString() + "\n";
            txtContent.Text += webContent;

            // .. write code here ..
        }

        #endregion


        #region READ EMBEDDED TEXT FILE

        public async void ReadTextFile()
        {
            String textContent;
            // .. write code here ..

            txtStatus.Text += "Text read completed.. Total length: \n" + textContent.Length.ToString() + "\n";
            txtContent.Text += textContent; 
        }

        #endregion

    }
}
