using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.viewmodel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using WpfApp2.util;
using System.Windows.Media;
using WpfApp2.view;
namespace WpfApp2.Commands
{
    class FreqSearchBtCommand : CommandBase
    {
        private  MainViewModel mainViewModel;
        private  IRepository _dataRepository;

        public FreqSearchBtCommand(MainViewModel _mainViewModel, IRepository _dataRepository)
        {
           this.mainViewModel = _mainViewModel;
            this._dataRepository = _dataRepository;

        }


        private void FindPage()
        {
            try{

                List<Data>datas=_dataRepository.GetDatas();
                //1페이지 부터 시작해야 하므로 Int32.Parse(mainViewModel.SeachTextBoxTx)-1
                if ( datas.Count==0) return;
                ChangeFrameAndColor(ref mainViewModel);
                mainViewModel.PlotModelmp.ChageCharMethod(ref datas);
                mainViewModel.ClearProp();

            }
            catch (Exception ex) {
                MessageBox.Show("없는 페이지 입니다");
            }

        }
        private void ChangeFrameAndColor(ref MainViewModel mainViewModel)
        {
            if(!(mainViewModel.FreSearchPageBtBG == Brushes.Black))
            {
                mainViewModel.FreSearchPageBtBG = Brushes.Black;
                mainViewModel.FreSearchPageBtFG = Brushes.White;
                mainViewModel.PageSearchPageBtBG= new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                mainViewModel.PageSearchPageBtFG = Brushes.Black;
                mainViewModel.Fr1Content = FreqSearchPage.GetFreqSearchPage();
                mainViewModel.Fr2Content = null;
            }
            else
            {
                mainViewModel.FreSearchPageBtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                mainViewModel.FreSearchPageBtFG = Brushes.Black;
                mainViewModel.Fr1Content = null;

            }
        }

        public override bool CanExecute(object parameter)
        {
           return true;  
        }

        public override void Execute(object parameter)
        {
            FindPage();
            
        }
    }
}
