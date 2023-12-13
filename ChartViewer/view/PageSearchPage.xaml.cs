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
    /// FreqSearchPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageSearchPage : Page
    {
        private static PageSearchPage pageSearchPage;
        public PageSearchPage()
        {
            this.Width = 488;
            this.Height = 97.34;
            InitializeComponent();
       
            //뷰모델 연결
            var vm = MainViewModel.GetMainViewModel();

            this.DataContext = vm;

            
        }

        public static PageSearchPage GetPageSearchPage()
        {
            if (pageSearchPage == null)
            {
                pageSearchPage = new PageSearchPage();
            }
            return pageSearchPage;

        }
    }
}
