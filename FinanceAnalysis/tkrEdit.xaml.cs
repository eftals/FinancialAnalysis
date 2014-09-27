using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinanceAnalysis
{
    /// <summary>
    /// Interaction logic for tkrEdit.xaml
    /// </summary>
    public partial class tkrEdit : Window
    {
        public tkrEdit()
        {
            InitializeComponent();
            Console.WriteLine(this.DataContext);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((!Char.IsLetter((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back) || e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("Ticker only contains characters.", "Field error");
            }
        }



       
    }
}
