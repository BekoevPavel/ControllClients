using ControllClients.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows;

namespace ControllClients
{
    class DBController
    {
        private readonly string serverName = "remotemysql.com"; // Адрес сервера (для локальной базы пишите "localhost")
        private readonly string userName = "oKdbgObt7j"; // Имя пользователя
        private readonly string dbName = "oKdbgObt7j"; //Имя базы данных
        private readonly string port = "3306"; // Порт для подключения
        private readonly string password = "6pf8LFEz1R"; // Пароль для подключения
        private string connectStr;
        private MySqlConnection connection;
   

        public DBController()
        {
            connectStr = $"server={serverName};port={port};username={userName};password={password};database={userName};";
            connection = new MySqlConnection(connectStr);
        }

        public void AddClient(string name, int buy, int order_num)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            openConnection();
           

            MySqlCommand commandAdd = new MySqlCommand($"INSERT INTO `Clients` (`id`, `name`, `buy`, `spent`, `order_num`) VALUES (NULL, '{name}', '{buy}', '0', '{order_num}');", getConnection());
            adapter.SelectCommand = commandAdd;

            adapter.Fill(table);

        }

        public void RemoveClient(int order)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            openConnection();

            MySqlCommand commandAdd = new MySqlCommand($"DELETE FROM `Clients` WHERE order_num = {order} ", getConnection());
            adapter.SelectCommand = commandAdd;

            adapter.Fill(table);

        }

        public BindingList<ToDoModel> GetClients()
        {
            BindingList<ToDoModel> clients = new BindingList<ToDoModel>();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            openConnection();

            MySqlCommand commandAdd = new MySqlCommand($"SELECT * FROM `Clients` WHERE 1", getConnection());
            adapter.SelectCommand = commandAdd;

            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                int tmp = 0;
                //MessageBox.Show("User Find! ");
                foreach (DataRow row in table.Rows)
                {
                    tmp = Convert.ToInt32(row.ItemArray[4]);




                    clients.Add(new ToDoModel() { Name = row.ItemArray[1].ToString(), Buy= Convert.ToInt32(row.ItemArray[2]), Spent = Convert.ToInt32(row.ItemArray[3]),OrderNumber = Convert.ToInt32(row.ItemArray[4])});
                    
                }

                //MessageBox.Show("User Find! "+lastOrder);
            }
            


            return clients;
        }
        public void EditClient(string name, int buy, int order)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            openConnection();
            

            string command = $"UPDATE `Clients` SET `buy` = {buy} WHERE `Clients`.`order_num` = {order};" +
                $"UPDATE `Clients` SET `name` = '{name}' WHERE `Clients`.`order_num` = {order};";

           
            MySqlCommand commandAdd = new MySqlCommand(command, getConnection());
            adapter.SelectCommand = commandAdd;

            adapter.Fill(table);
            
        }

        private void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {

                connection.Open();
            }
        }

        private void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {


                connection.Close();
            }
        }

        private MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
