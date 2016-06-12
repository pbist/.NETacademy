using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class NumberWin : Window
    {
        private MainWindow mainWin;
        private Regex numberPattern = new Regex(@"^(\d{9})|(\d{3}\s\d{3}\s\d{3})|(\d{3}-\d{3}-\d{3})$"); // 746124512, 746-124-512 lub 746 124 512

        public NumberWin(MainWindow mainWin)
        {
            InitializeComponent();
            this.mainWin = mainWin;
            mainWin.setButtons();
            textbox.Text = mainWin.newContact.Number;
            textbox.Focus();
            if (string.IsNullOrWhiteSpace(textbox.Text))
                nextBtn.IsEnabled = false;
        }

        private void NextWindow(object sender, RoutedEventArgs e)
        {
            Match result = numberPattern.Match(textbox.Text);
            if (result.Success)
            {
                mainWin.newContact.Number = textbox.Text;
                this.Close();
                mainWin.addContact();
            }
            else
            {
                MessageBox.Show("Wprowadź ciąg dziewięciu cyfr wg podanego formatu: \n746124512, 746-124-512 lub 746 124 512", "Wprowadzono błędne dane!");
            }
        }

        private void PreviousWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
            new AddressWin(mainWin).Show();
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
