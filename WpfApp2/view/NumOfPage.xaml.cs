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
using WpfApp2.viewmodel;

namespace WpfApp2.view
{
    /// <summary>
    /// NumOfPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NumOfPage : Page
    {
        private static NumOfPage numOfPage;
        private  NumOfPage()
        {
            this.Height = 389.36;
            this.Width = 219.75;
            InitializeComponent();

            var vm = MainViewModel.GetMainViewModel();

            this.DataContext = vm;
        }

        public static NumOfPage GetNumOfPage()
        {
            if (numOfPage == null)
            {
                numOfPage = new NumOfPage();
            }
            return numOfPage;

        }
    }
}
