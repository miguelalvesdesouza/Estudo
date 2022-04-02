using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace AppRazor.DataBase
{
    public class Connection
    {
        public string File
        {
            get
            {
                return Environment.CurrentDirectory + "C:\\bd\\Produtos.sqlite";
            }
        }

        public SQLiteConnection Bd
        {
            get
            {
                return new SQLiteConnection($"Data Source=C:\\bd\\Produtos.sqlite;Version=3");
            }
        }
    }
}
