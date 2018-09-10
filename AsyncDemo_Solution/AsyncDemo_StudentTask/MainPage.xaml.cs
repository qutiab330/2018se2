using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Reflection;
using System.Net.Http;

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
                Task<string> webPageRead = DownLoadWebPage();

                txtStatus.Text += "Downloading web page..\n";


                //Calling async method for reading text file ..
                ReadTextFile();

                txtStatus.Text += "Reading text file..\n";


                string webPageContent = await webPageRead;

            };
        }


        #region DOWNLOAD WEB PAGE

        public async Task<string> DownLoadWebPage()
        {
            var httpClient = new HttpClient(); 

            Task<string> taskDownloadWebPage = httpClient.GetStringAsync("http://xamarin.com"); // async method!

            // await! control returns to the caller and the task continues to run on another thread
            string webContent = await taskDownloadWebPage;

            txtStatus.Text += "Download completed.. Total length: \n" + webContent.Length.ToString() + "\n";
            txtContent.Text += webContent;

            return webContent; // Task<TResult> returns an object of type TResult, in this case string
        }

        #endregion


        #region READ EMBEDDED TEXT FILE

        public async void ReadTextFile()
        {
            Char[] buffer;

            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("AsyncDemo_StudentTask.SampleTxtFile.txt");


            using (var reader = new System.IO.StreamReader(stream))
            {
                buffer = new Char[(int)reader.BaseStream.Length];

                await reader.ReadAsync(buffer, 0, (int)reader.BaseStream.Length);
                uint buffLengh = (uint)buffer.Length;
                await prgbarDownload.ProgressTo(1, buffLengh, Easing.Linear);
            }

            string textContent = (new String(buffer));

            txtStatus.Text += "Text read completed.. Total length: \n" + textContent.Length.ToString() + "\n";
            txtContent.Text += textContent;
        }

        #endregion

    }
}
