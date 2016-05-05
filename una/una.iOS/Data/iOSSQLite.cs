using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using una.DataService;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;
using una.iOS.Data;

[assembly: Dependency(typeof(iOSSQLite))]
namespace una.iOS.Data
{
    public class iOSSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string databaseName = "DBPESSOA.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string combinePath = Path.Combine(documentsPath, "..", "Library");
            string resultPath = Path.Combine(combinePath, databaseName);

            SQLiteConnection connection = new SQLiteConnection(new SQLitePlatformIOS(), resultPath);

            return connection;
        }
    }
}
