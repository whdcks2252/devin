using Microsoft.Win32;
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
using System.IO;
using System.Windows.Media.TextFormatting;
using OxyPlot;
using System.Security.Authentication;
using ChartViewer.viewmodel;

namespace ChartViewer.view
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {


            InitializeComponent();
           

            var dataRepository = DataRepository.GetDataRepository();

            var vm = MainViewModel.GetMainViewModel();


            this.DataContext = vm;

            vm.SaveData2.save();
           
        }

    }
}
