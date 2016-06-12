using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        private string surname;
        private string address;
        private string number;

        // properties
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged("Surname"); }
        }
        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
        }
        public string Number
        {
            get { return number; }
            set { number = value; OnPropertyChanged("Number"); }
        }

        protected void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
