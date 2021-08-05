using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ControllClients.Models
{
    public class ToDoModel : INotifyPropertyChanged
    {
        private int _orderNumber;
        private int _buy;

        public int Buy
        {
            get { return _buy; }
            set { _buy = value; OnPropertyChanged("Buy"); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        } 


       
        private int _spent;

        public int Spent
        {
            get { return _spent; }
            set { _spent = value; OnPropertyChanged("Spent"); }
        }

        
        public int OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }
        

        private String _text;



        public String Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged("Text");

            }
        }
        public DateTime CreationData { get; set; } = DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
