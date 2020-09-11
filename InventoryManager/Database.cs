using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using InventoryManager;

namespace SQLiteDatabase
{
    public class Database
    {
        public SQLiteConnection myConnection;
        public Database(string databaseName)
        {
            var localPath = Directory.GetCurrentDirectory();
            var filePrefix = "URI = file:";

            myConnection = new SQLiteConnection(filePrefix + localPath + "\\" + databaseName);
            myConnection.Open();

        }

        public bool AddTable(string tableName)
        {
            int res = 0;
            var cmd = new SQLiteCommand(myConnection);

            cmd.CommandText = "CREATE TABLE " + tableName + @"(id INTEGER PRIMARY KEY,
                    name TEXT, price REAL, quantity INT)";

            try
            {
                res = cmd.ExecuteNonQuery();
            }
            catch(SQLiteException e)
            {
            }

            return (res != 0);
        }

        public bool AddRow(string tableName, ProductItem item)
        {
            var cmd = new SQLiteCommand(myConnection);
            cmd.CommandText = $"INSERT INTO {tableName}(name, price, quantity) VALUES('{item.GetName()}',{item.GetPrice()},{item.GetQuantity()})";

            return (cmd.ExecuteNonQuery() != 0);
        }

        public bool DeleteRowByName(string tableName, string name)
        {
            var cmd = new SQLiteCommand(myConnection);

            cmd.CommandText = "DELETE FROM {tableName} WHERE NAME = '{name}'";

            return (cmd.ExecuteNonQuery() != 0);
        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Clone();
            }
        }
    }
}
