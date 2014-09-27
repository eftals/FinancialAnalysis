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

namespace FinanceAnalysis
{
    /// <summary>
    /// Interaction logic for tkrDetail.xaml
    /// </summary>
    public partial class tkrDetail : UserControl
    {
        public tkrDetail()
        {
            InitializeComponent();
        }

        private void Label_GotFocus(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.DataContext);
        }
    }
}
