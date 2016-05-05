using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using una.DataService;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;
using una.Droid.Data;

[assembly: Dependency(typeof(AndroidSQLite))]
namespace una.Droid.Data
{
    public class AndroidSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string databaseName = "DBPESSOA.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string combinePath = Path.Combine(documentsPath, databaseName);

            SQLiteConnection connection = new SQLiteConnection(new SQLitePlatformAndroid(), combinePath);

            return connection;
        }
    }
}