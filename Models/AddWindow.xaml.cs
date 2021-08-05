using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private MainWindow mw;
        private DBController db_Controller;


        public AddWindow(MainWindow _mw)
        {
            InitializeComponent();
            db_Controller = new DBController();
            mw = _mw;
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int maxIndex = 0;
            var list = mw.GetDataList();

            if(input_Name.Text!="" && input_Buy.Text != "")
            {
                foreach (var i in list)
                {
                    if (i.OrderNumber > maxIndex)
                        maxIndex = i.OrderNumber;
                }
                maxIndex++;

                list.Add(new ToDoModel() { Name = input_Name.Text, Buy = Convert.ToInt32(input_Buy.Text), OrderNumber = maxIndex });
                db_Controller.AddClient(input_Name.Text, Convert.ToInt32(input_Buy.Text), maxIndex);
                Close();
            }
           
        }
    }
}
