using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mousegame
{
    class DatabaseAccessObject
    {
        private static string connectionString
        {
            get { return "Server=localhost;Port=3306;Database=mousegame;Uid=root;password=<PASSWORD>;"; }

        }

        private static MySqlConnection _mySqlConnection = null;
        protected MySqlConnection mySqlConnection
        {
            get
            {
                if (_mySqlConnection == null)
                {
                    _mySqlConnection = new MySqlConnection(connectionString);
                }

                return _mySqlConnection;

            }
        }

    }

}