﻿using System;
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

namespace WpfAppReactiveProperty
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            _vm.PropertyChanged += PropertyChangedEventHandler;
        }

        private void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.SelectedMode = 2;
        }
    }
}
