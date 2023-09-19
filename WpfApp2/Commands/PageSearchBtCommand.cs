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

namespace WpfApp2.Commands
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

                CommonDelegate.chageChart(ref datas);


            }
            catch (Exception ex) {
                MessageBox.Show("없는 페이지 입니다");
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
