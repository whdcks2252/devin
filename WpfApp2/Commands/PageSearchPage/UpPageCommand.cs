using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.viewmodel;

namespace WpfApp2.Commands.PageSearchPage
{


     class UpPageCommand:CommandBase
    {
        private MainViewModel mainViewModel;
        private IRepository _dataRepository;

        public UpPageCommand(MainViewModel mainViewModel, IRepository _dataRepository)
        {
            this.mainViewModel = mainViewModel;
            this._dataRepository = _dataRepository;
        }

        private void UpPage()
        {
            try
            {
                int pageNumber = Int32.Parse(mainViewModel.PageNumber);
                //현재 페이지 +1
                List<Data> datas = _dataRepository.GetDataBox()[pageNumber];

                ChageChar(ref datas);
                //page번호 
                mainViewModel.PageNumber = (pageNumber + 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("없는 페이지 입니다");
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
            UpPage();
        }
    }
}
