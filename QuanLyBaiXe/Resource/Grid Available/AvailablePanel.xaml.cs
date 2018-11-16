﻿using System;
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

namespace QuanLyBaiXe.Resource.Grid_Available
{
    /// <summary>
    /// Interaction logic for AvailablePanel.xaml
    /// </summary>
    public partial class AvailablePanel : Window
    {
        public AvailablePanel(string s)
        {
            InitializeComponent();
            AvailablePanelViewModel vm = new AvailablePanelViewModel();
            this.DataContext = vm;
            vm.posID = s;
        }
    }
}
