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
    /// PageSearchPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FreqSearchPage : Page
    {
        private static FreqSearchPage freqSearchPage;
        private FreqSearchPage()
        {
            this.Width =488;
            this.Height = 97.34;
            InitializeComponent();

            //뷰모델 연결
            var vm = MainViewModel.GetMainViewModel();
            this.DataContext = vm;
        }

        public static FreqSearchPage GetFreqSearchPage()
        {
            if (freqSearchPage == null)
            {
                freqSearchPage = new FreqSearchPage();
            }
            return freqSearchPage;

        }
    }
}
