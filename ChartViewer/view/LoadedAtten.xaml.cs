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
using ChartViewer.viewmodel;

namespace ChartViewer.view
{
    /// <summary>
    /// LoadedAtten.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoadedAtten : Page
    {
        private static LoadedAtten loadedAtten;
        public LoadedAtten()
        {
           
            InitializeComponent();

            var vm = CalViewModel.GetMainViewModel();

            this.DataContext = vm;
        }

        public static LoadedAtten GetLoadedAtten()
        {
            if (loadedAtten == null)
            {
                loadedAtten = new LoadedAtten();
            }
            return loadedAtten;

        }
    }
}
