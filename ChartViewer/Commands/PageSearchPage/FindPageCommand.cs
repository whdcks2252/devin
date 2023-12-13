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
using System.Data;

namespace ChartViewer.Commands
{
    class FindPageCommand : CommandBase
    {
        private  MainViewModel mainViewModel;
        private  IRepository _dataRepository;

        public FindPageCommand(MainViewModel _mainViewModel, IRepository _dataRepository)
        {
           this.mainViewModel = _mainViewModel;
            this._dataRepository = _dataRepository;

        }


        private void FindPage()
        {
            try{
                List<List<Data>>dataBox=_dataRepository.GetDataBox();
                List<Data> datas = _dataRepository.GetDataBox()[Int32.Parse(mainViewModel.SeachTextBoxTx)-1];
                mainViewModel.PlotModelmp.ChageCharMethod(ref datas);
                mainViewModel.MaxAndCurPage = mainViewModel.SeachTextBoxTx +"/"+dataBox.Count;
                mainViewModel.CurrentPage= mainViewModel.SeachTextBoxTx;
                mainViewModel.SeachTextBoxTx = null;
            }catch(Exception ex) {
                MessageBox.Show("없는 페이지 입니다");
                mainViewModel.SeachTextBoxTx = null;
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
