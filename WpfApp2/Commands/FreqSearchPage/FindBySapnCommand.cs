using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using WpfApp2.viewmodel;

namespace WpfApp2.Commands.FreqSearchPage
{
    class FindBySapnCommand : CommandBase
    {
        private MainViewModel mainViewModel;
        private IRepository _dataRepository;

        public FindBySapnCommand(MainViewModel mainViewModel, IRepository _dataRepository)
        {
            this.mainViewModel = mainViewModel;
            this._dataRepository = _dataRepository;
        }

        private void FindBySapn()
        {
            try
            {
                int pageNumber = Int32.Parse(mainViewModel.PageNumber);
                List<Data> datas = _dataRepository.GetDataBox()[pageNumber - 1];
                ResultSpan(ref datas);
            }
            catch (Exception ex) { MessageBox.Show("없는 페이지 입니다"); }

        }

        //범위 탐색
        private void ResultSpan(ref List<Data>datas)
        {
            
            List<Data>ResultDatas= new List<Data>();
            int selecteFre = Int32.Parse(mainViewModel.FreTxt);
            int span =Int32.Parse(mainViewModel.SpanTxt)/2;


            foreach(Data data in datas)
            {
                if (data.Frequency >= (selecteFre - span) && data.Frequency <= (selecteFre + span))
                {
                    ResultDatas.Add(data);
                }
            }


            ChageChar(ref ResultDatas);


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
            FindBySapn();
        }
    }
}
