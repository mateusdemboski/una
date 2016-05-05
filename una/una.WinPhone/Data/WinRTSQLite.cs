using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using una.DataService;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using Windows.Storage;
using Xamarin.Forms;
using una.WinPhone.Data;

[assembly: Dependency(typeof(WinRTSQLite))]
namespace una.WinPhone.Data
{
    public class WinRTSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string databaseName = "DBPESSOA.db3";
            string documentsPath = ApplicationData.Current.LocalFolder.Path;
            string combinePath = Path.Combine(documentsPath, databaseName);

            SQLiteConnection connection = new SQLiteConnection(new SQLitePlatformWinRT(), combinePath);

            return connection;
        }
    }
}
