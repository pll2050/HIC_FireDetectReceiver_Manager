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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HIC_FireDetectReceiver_Manager.Pages
{
    /// <summary>
    /// Tab_OutGroup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Tab_OutGroup : Page
    {
        public Tab_OutGroup()
        {
            InitializeComponent();
            DataGrid_OutGroup.ItemsSource = Global_Variable.oOutGroup_Table;
        }
    }
}
