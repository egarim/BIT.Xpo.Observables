using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Demo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            //MSSqlServer

            //string connectionString = MSSqlConnectionProvider.GetConnectionString("YOUR_SERVER_NAME", "sa", "", "XamarinDemo");

            //SQLite

            var filePath = Path.Combine(documentsPath, "xpoXamarinDemo.db");
            string connectionString = SQLiteConnectionProvider.GetConnectionString(filePath) + ";Cache=Shared;";

            //In-memory data store with saving/loading from the xml file

            //var filePath = Path.Combine(documentsPath, "xpoXamarinDemo.xml");
            //string connectionString = InMemoryDataStore.GetConnectionString(filePath);

            XpoHelper.InitXpo(connectionString);
            var uoW = XpoHelper.CreateUnitOfWork();
            if (!uoW.Query<Item>().Any())
            {
                for (int i = 0; i < 1000; i++)
                {
                    Item Object = new Item(uoW);
                    Object.Description = "Item number:" + i.ToString();
                }
                if (uoW.InTransaction)
                    uoW.CommitChanges();
            }

             
           

            MainPage = new MainPage();
        }
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debug.WriteLine(e.ExceptionObject);
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
