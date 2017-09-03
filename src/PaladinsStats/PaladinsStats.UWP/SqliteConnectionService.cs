using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using PaladinsStats.Business.Interfaces;
using PaladinsStats.UWP;
using SQLite.Net;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteConnectionService))]
namespace PaladinsStats.UWP
{
    public class SqliteConnectionService : ISqliteConnectionService
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "paladinsStats.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}
