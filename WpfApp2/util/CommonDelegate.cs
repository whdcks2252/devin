using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.viewmodel;
using System.Windows.Media;

namespace WpfApp2.util
{
      class CommonDelegate
    {
        private static MainViewModel mainViewModel=MainViewModel.GetMainViewModel();
        private static IRepository _dataRepository = DataRepository.GetDataRepository();

        public delegate void ChageChart(ref List<Data> datas);
        public delegate void ChageChart2();

        public static ChageChart chageChart = ChageCharMethod;
        public static ChageChart chageChartCalNomal = ChageCharMethodCalNomal;
        public static ChageChart2 ClearChart= ClearChartMethod;
        // 저장후 차트 변경
        private static void ChageCharMethod(ref List<Data> datas)
        {
            //차트 초기화
            mainViewModel.PlotModel.Series.Clear();

            var lineSeries = new LineSeries
            {
                Color = OxyColors.Black,

            };
            foreach (var data in datas)
                lineSeries.Points.Add(new DataPoint(data.Frequency, data.Values));
            mainViewModel.PlotModel.Series.Add(lineSeries);

            mainViewModel.PlotModel.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거
        
        }
        // 저장후 차트 변경
        private static void ChageCharMethodCalNomal(ref List<Data> datas)
        {
            //차트 초기화
            mainViewModel.PlotModel.Series.Clear();

            var lineSeries = new LineSeries
            {
                Color = OxyColors.Black,

            };
            foreach (var data in datas)
                lineSeries.Points.Add(new DataPoint(data.Freq, data.PowerAccuracy));
            mainViewModel.PlotModel.Series.Add(lineSeries);

            mainViewModel.PlotModel.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거

        }
        private static void ClearChartMethod()
        {
            mainViewModel.PlotModel.Series.Clear();
            mainViewModel.PlotModel.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거


        }

    }
}
