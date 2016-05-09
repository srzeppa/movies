using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies.ViewModel
{
    class DatabaseHandler
    {

        string path;
        SQLite.Net.SQLiteConnection conn;

        public void createDB()
        {
            //AppData\Local\Packages\6ed022d9-e2e8-4be6-92e6-4d110cb7293e_gadjc3dd055ja
            if (!File.Exists(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "movies.sqlite")))
            {
                path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "movies.sqlite");
                conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
                conn.CreateTable<Model.UserMovie>();
            }
        }

        public void insert(string imdbId, int userVote, DateTime whereToWatch)
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "movies.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            var s = conn.Insert(new Model.UserMovie(){
            imdbId = imdbId, 
            userVote = userVote,
            whereToWatch = whereToWatch
         }); 
        }

        public List<Model.UserMovie> getMoviesFromDatabase()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "movies.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            List<Model.UserMovie> userMovies = new List<Model.UserMovie>();
            var query = conn.Table<Model.UserMovie>();

            foreach (var movie in query)
            {
                userMovies.Add(movie);
            }

            return userMovies;
        }
    }
}
