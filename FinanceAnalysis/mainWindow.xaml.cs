﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinanceAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        yhooreader yahooReaderInst;
        public MainWindow()
        {

            InitializeComponent();

            yahooReaderInst = new yhooreader(Properties.Settings.Default.yhoosrequest);

            //yahooReaderInst.getStockHistory("IBM");

          /*  EftalDBViewModel ef = new EftalDBViewModel();

            DataContext = ef;
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           var val= this.DataContext;
            
        }
    }
}