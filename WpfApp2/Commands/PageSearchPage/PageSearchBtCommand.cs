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
                //1페이지 부터 시작해야 하므로 Int32.Parse(mainViewModel.SeachTextBoxTx)-1
                if (mainViewModel.PageNumber == null) return;
                List<Data> datas = _dataRepository.GetDataBox()[Int32.Parse(mainViewModel.PageNumber)-1];
                ChageChar(ref datas);

            }catch(Exception ex) {
                MessageBox.Show("없는 페이지 입니다");
                mainViewModel.SeachTextBoxTx = null;
            }

        }

        // 저장후 차트 변경
        private void ChageChar(ref List<Data> datas)
        {
            //차트 초기화
            mainViewModel.PlotModel.Series.Clear();

            var dataBox = _dataRepository.GetDataBox();

            var lineSeries = new LineSeries
            {
                Color = OxyColors.Black,

            };
            foreach (var data in datas)
                lineSeries.Points.Add(new DataPoint(data.Frequency, data.Values));

            mainViewModel.PlotModel.Series.Add(lineSeries);

            mainViewModel.PlotModel.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거
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
