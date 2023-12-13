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
using ChartViewer.viewmodel;

namespace ChartViewer.view
{
    /// <summary>
    /// NumOfPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoadedIQ_ImbPage : Page
    {
        private static LoadedIQ_ImbPage loadedIQ_ImbPage;
        private LoadedIQ_ImbPage()
        {
            this.Height = 389.36;
            this.Width = 219.75;
            InitializeComponent();

            var vm = CalViewModel.GetMainViewModel();

            this.DataContext = vm;
        }
        public static LoadedIQ_ImbPage GetLoadedIQ_ImbPage()
        {
            if (loadedIQ_ImbPage == null)
            {
                loadedIQ_ImbPage = new LoadedIQ_ImbPage();
            }
            return loadedIQ_ImbPage;

        }

    }
}
