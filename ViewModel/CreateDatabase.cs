using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies.ViewModel
{
    class CreateDatabase
    {

        public void createDB()
        {
            //AppData\Local\Packages\6ed022d9-e2e8-4be6-92e6-4d110cb7293e_gadjc3dd055ja
            if (!File.Exists(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "movies.sqlite")))
            {
                string path;
                SQLite.Net.SQLiteConnection conn;
                path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "movies.sqlite");
                conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
                conn.CreateTable<Model.UserMovie>();
            }
        }

    }
}
