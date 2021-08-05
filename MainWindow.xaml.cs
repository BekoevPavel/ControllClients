using ControllClients.Models;
using ControllClients.Servises;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ControllClients
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 




    public partial class MainWindow : Window
    {


        private BindingList<ToDoModel> _toDoDataList;
        private BindingList<ToDoModel> _toDoDataList1;
        private FileIOService _fileIOService;
        // private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private DBController db_Controller;
        private EditWindow editWindow;
        private AddWindow addWindow;



        public BindingList<ToDoModel> GetDataList()
        {
            return _toDoDataList;
        }

       
     
        public MainWindow()
        {
            _toDoDataList1 = new BindingList<ToDoModel>();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db_Controller = new DBController();

            _toDoDataList = new BindingList<ToDoModel>();
            _toDoDataList = db_Controller.GetClients();

            


            dgTodoList.ItemsSource = _toDoDataList;
            _toDoDataList.ListChanged += _toDoDataList_ListChanged;
            _toDoDataList1 = CopyList(_toDoDataList);

            // MessageBox.Show(_toDoDataList[0].CreationData.ToString());

        }
        private BindingList<ToDoModel> CopyList(BindingList<ToDoModel> toCoppyList)
        {
            BindingList<ToDoModel> _resultList = new BindingList<ToDoModel>();

            foreach (var i in toCoppyList)
            {
                _resultList.Add(i);
            }
            return _resultList;
        }

        private void _toDoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {

            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                // db_Controller.RemoveClient(_toDoDataList1[e.NewIndex].Name);
                //MessageBox.Show("Удален " + _toDoDataList1[e.NewIndex].Name);
                //_toDoDataList1 = CopyList(_toDoDataList);



            }
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                if (_toDoDataList[e.NewIndex].Name != null )
                {
                    // && e.NewIndex+1  == _toDoDataList.Count
                    // db_Controller.AddClient(_toDoDataList[e.NewIndex].Name, _toDoDataList[e.NewIndex].Buy, _toDoDataList[e.NewIndex].OrderNumber);
                    //MessageBox.Show("Добавлен " + _toDoDataList[e.NewIndex].Name + "lenght " + _toDoDataList.Count + " index " + Convert.ToInt32(e.NewIndex + 1));
                    _toDoDataList1 = CopyList(_toDoDataList);

                }
                else if (_toDoDataList[e.NewIndex].Name != null)
                {
                    //MessageBox.Show("редакт ");
                    //db_Controller.EditClient(_toDoDataList[e.NewIndex].Name, _toDoDataList[e.NewIndex].Buy);
                    //MessageBox.Show("Изменено " + "lenght " + _toDoDataList.Count + " index " + Convert.ToInt32(e.NewIndex+1));
                    // _toDoDataList1 = CopyList(_toDoDataList);
                }




            }


        }


        ToDoModel td = new ToDoModel();
       

        private void dgTodoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int index = dgTodoList.SelectedIndex + 1;
                int lenghtList = _toDoDataList.Count;
                //MessageBox.Show("index "+index+" Lenght "+lenghtList);

                editWindow = new EditWindow(this, dgTodoList.SelectedIndex);

            }
            catch (Exception)
            {

                throw;
            }


        }

        private void AddClient_click(object sender, RoutedEventArgs e)
        {
            addWindow = new AddWindow(this);
            addWindow.Show();


        }
        private void RemoveClient_click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Deleted " + dgTodoList.SelectedIndex + "  erder " + _toDoDataList1[dgTodoList.SelectedIndex].OrderNumber);

            db_Controller.RemoveClient(_toDoDataList[dgTodoList.SelectedIndex].OrderNumber);
            _toDoDataList.RemoveAt(dgTodoList.SelectedIndex);


        }
       
    }
}
