using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartViewer.viewmodel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using ChartViewer.util;
using System.Windows.Media;
using ChartViewer.view;

namespace ChartViewer.Commands
{
    class PageSearchBtCommand : CommandBase
    {
        private  MainViewModel mainViewModel;
        private  IRepository _dataRepository;

        public PageSearchBtCommand(MainViewModel _mainViewModel, IRepository _dataRepository)
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

                //초기값 1
                mainViewModel.PageNumber = "1";
                mainViewModel.ChageTextNOP.Execute(null);

            }
            catch (Exception ex) {
                MessageBox.Show("없는 페이지 입니다");
            }

        }

        private void ChangeFrameAndColor(ref MainViewModel mainViewModel)
        {
            if (!(mainViewModel.PageSearchPageBtBG == Brushes.Gray))
            {
                mainViewModel.PageSearchPageBtBG = Brushes.Gray;
                mainViewModel.PageSearchPageBtFG = Brushes.White;
                mainViewModel.FreSearchPageBtBG = Brushes.White;
                mainViewModel.FreSearchPageBtFG = Brushes.Black;
                mainViewModel.Fr1Content = PageSearchPage.GetPageSearchPage();
                mainViewModel.Fr2Content = NumOfPage.GetNumOfPage();
            }
            else
            {
                mainViewModel.PageSearchPageBtBG = Brushes.White;
                mainViewModel.PageSearchPageBtFG = Brushes.Black;
                mainViewModel.Fr1Content = null;
                mainViewModel.Fr2Content = null;


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
