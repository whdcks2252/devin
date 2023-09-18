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
using WpfApp2.viewmodel;

namespace WpfApp2.view
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Window
    {
        int pageSearchFlag= 0;
        int freqSearchFlag = 0;
        PageSearchPage PageSearchPage { get; set; }
        FreqSearchPage FreqSearchPage { get; set; }
        NumOfPage NumOfPage { get; set; }
        public Main()
        {
            

            InitializeComponent();
            this.Width = 880;
            this.Height = 600;
            this.ResizeMode = ResizeMode.NoResize;

            var dataRepository = DataRepository.GetDataRepository();
           
            var vm = MainViewModel.GetMainViewModel();
            this.DataContext = vm;

            createPage();
        }

        //페이지 생성
        private void createPage()
        {
            PageSearchPage = new PageSearchPage();
            FreqSearchPage = new FreqSearchPage();
            NumOfPage = new NumOfPage();
        }
    
        // 버튼 클릭시 페이지호출
        private void FreqSearch_Click(object sender, RoutedEventArgs e)
        {
            if (pageSearchFlag == 1)
            {
                changeBackgroundWhite(PageSearchBt);
                changeBackgroundBlack(FreqSearchBt);
                fr.Content = FreqSearchPage;
                NumOfPageFrame.Content = null;
                pageSearchFlag = 0;
                freqSearchFlag = 1;
            }
            else if (freqSearchFlag == 0)
            {
                fr.Content = FreqSearchPage;
                changeBackgroundBlack(sender);
                freqSearchFlag = 1;
            }
            else if(freqSearchFlag==1)
            {  
                fr.Content = null;
                changeBackgroundWhite(sender);
                freqSearchFlag = 0;
            }

        }
        private void PageSearch_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.GetMainViewModel().SpanTxt = null;
            MainViewModel.GetMainViewModel().FreTxt = null;

            if (freqSearchFlag == 1)
            {
                changeBackgroundWhite(FreqSearchBt);
                changeBackgroundBlack(PageSearchBt);
                fr.Content = PageSearchPage;
                NumOfPageFrame.Content = NumOfPage;

                freqSearchFlag = 0;
                pageSearchFlag = 1;
            }
            else if (pageSearchFlag == 0)
            {

                fr.Content = PageSearchPage;
                NumOfPageFrame.Content = NumOfPage;
                changeBackgroundBlack(sender);
                pageSearchFlag = 1;
            }
            else if(pageSearchFlag==1) 
            {
                fr.Content = null;
                NumOfPageFrame.Content = null;
                changeBackgroundWhite(sender);
                pageSearchFlag = 0;
            }

        }
        //버튼 백그라운드 변경
        private void changeBackgroundBlack(object sender)
        {
            var button = (Button)sender;
            button.Background=Brushes.Black; button.Foreground=Brushes.White;
            

        }
        private void changeBackgroundWhite(object sender)
        {
            var button = (Button)sender;
            button.Background = Brushes.White; button.Foreground = Brushes.Black;

        }
    }

}
