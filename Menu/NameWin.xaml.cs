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
using System.Windows.Shapes;

namespace ContactBook
{
    public partial class NameWin : Window
    {
        private MainWindow mainWin;

        public NameWin(MainWindow mainWin)
        {
            InitializeComponent();
            this.mainWin = mainWin;
            mainWin.setButtons();
            textbox.Text = mainWin.newContact.Name;
            textbox.Focus();
            if (string.IsNullOrWhiteSpace(textbox.Text))
                nextBtn.IsEnabled = false;

        }

        private void NextWindow(object sender, RoutedEventArgs e)
        {
            mainWin.newContact.Name = textbox.Text;
            this.Close();
            new SurnameWin(mainWin).Show();
        }

        private void enableBtn(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text))
                nextBtn.IsEnabled = false;
            else
                nextBtn.IsEnabled = true;
        }

        private void OnClose(object sender, EventArgs e)
        {
            mainWin.setButtons(true);
        }
    }
}
