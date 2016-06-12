using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ContactBook
{
    public partial class MainWindow : Window
    {
        public Person newContact;

        private ObservableCollection<Person> contactList = new ObservableCollection<Person>();
        private int index;

        private Option option;
        enum Option
        {
            Add,
            Edit
        }

        public MainWindow()
        {
            InitializeComponent();
            listBox.DataContext = contactList;
        }

        public void setButtons(bool option = false)
        {
            newBtn.IsEnabled = option;
            editBtn.IsEnabled = option;
        }

        public void addContact()
        {
            if (option == Option.Add)
            {
                contactList.Add(newContact);
            }
            else if (option == Option.Edit)
            {
                contactList[index] = newContact;
            }
        }

        private void NewContact(object sender, RoutedEventArgs e)
        {
            option = Option.Add;
            newContact = new Person();
            setButtons();
            (new NameWin(this)).Show();
        }

        private void EditContact(object sender, RoutedEventArgs e)
        {
            index = listBox.SelectedIndex;
            if (index != -1)
            {
                option = Option.Edit;
                newContact = contactList[index];
                setButtons();
                (new NameWin(this)).Show();
            }
        }

        private void DeleteContact(object sender, RoutedEventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index != -1)
                contactList.RemoveAt(index);
        }

        private void OnClose(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
