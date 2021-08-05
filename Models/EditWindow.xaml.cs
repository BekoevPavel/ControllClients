using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControllClients.Models
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private int index;
        private MainWindow mw;
        private DBController db_Controller;

        public EditWindow(MainWindow _mw, int _index)
        {


            InitializeComponent();
            db_Controller = new DBController();
            index = _index;
            mw = _mw;
            Show();




        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
                var toDoList = mw.GetDataList();
                int order = toDoList[index].OrderNumber;
                string name = toDoList[index].Name;
                int buy = toDoList[index].Buy;


                t_index.Text = "Заказ №" + order.ToString();


                input_Name.Text = name;
                input_Buy.Text = buy.ToString();
            
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            var toDoList = mw.GetDataList();
            var Client = toDoList[index];


            if (input_Name.Text != "" && input_Buy.Text != "")
            {
                Client.Name = input_Name.Text;
                Client.Buy = Convert.ToInt32(input_Buy.Text);




                db_Controller.EditClient(Client.Name, Client.Buy, Client.OrderNumber);
                Close();
            }
            
        }
    }
}
