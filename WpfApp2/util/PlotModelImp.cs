using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.viewmodel;

namespace WpfApp2
{
     class PlotModelImp : PlotModel
    {
        private static PlotModelImp plotModelImp;

        //객체 인스턴스
        public static PlotModelImp GetPlotModelImp()
        {
            if (plotModelImp == null)
            {
                plotModelImp = new PlotModelImp();
                plotModelImp.SetPlotModel();
            }
            return plotModelImp;

        }

        public void SetPlotModel()
        {
            //PlotModel 생성
            plotModelImp.Title = "Chart" ;

            //x축 생성
            plotModelImp.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "frequency(GHz)",
                IsZoomEnabled = false,
            });
            //y축 생성
            plotModelImp.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "value(dBm)",
                MajorGridlineStyle = LineStyle.Solid,
                IsZoomEnabled = false
            });

        }



        // 저장후 차트 변경
        public  void ChageCharMethod(ref List<Data> datas)
        {
            //차트 초기화
            plotModelImp.Series.Clear();

            var lineSeries = new LineSeries
            {
                Color = OxyColors.Black,

            };
            foreach (var data in datas)
                lineSeries.Points.Add(new DataPoint(data.Frequency, data.Values));
            plotModelImp.Series.Add(lineSeries);

            plotModelImp.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거

        }

        // 저장후 차트 변경
        public void ChageCharMethodCalNomal(ref List<Data> datas)
        {
            //차트 초기화
            plotModelImp.Series.Clear();

            var lineSeries = new LineSeries
            {
                Color = OxyColors.Black,

            };
            foreach (var data in datas)
                lineSeries.Points.Add(new DataPoint(data.Freq, data.PowerAccuracy));
            plotModelImp.Series.Add(lineSeries);

            plotModelImp.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거

        }

        // IQ_button 차트 변경
        public void ChageCharMethodIq_Button(ref List<Data> datas, ref string iQ_ButtonState)
        {
            if (iQ_ButtonState == IQ_ButtonEnum.A.ToString())
            {
                //차트 초기화
                plotModelImp.Series.Clear();

                var lineSeries = new LineSeries
                {
                    Color = OxyColors.Blue,

                };
                foreach (var data in datas)
                    lineSeries.Points.Add(new DataPoint(data.Freq, data.A));
                plotModelImp.Series.Add(lineSeries);

                plotModelImp.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거
            }

            if (iQ_ButtonState == IQ_ButtonEnum.B.ToString())
            {
                //차트 초기화
                plotModelImp.Series.Clear();

                var lineSeries = new LineSeries
                {
                    Color = OxyColors.Blue,

                };
                foreach (var data in datas)
                    lineSeries.Points.Add(new DataPoint(data.Freq, data.B));
                plotModelImp.Series.Add(lineSeries);

                plotModelImp.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거
            }

            if (iQ_ButtonState == IQ_ButtonEnum.C.ToString())
            {
                //차트 초기화
                plotModelImp.Series.Clear();

                var lineSeries = new LineSeries
                {
                    Color = OxyColors.Blue,

                };
                foreach (var data in datas)
                    lineSeries.Points.Add(new DataPoint(data.Freq, data.C));
                    plotModelImp.Series.Add(lineSeries);

                    plotModelImp.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거
            }

            if (iQ_ButtonState == IQ_ButtonEnum.D.ToString())
            {
                //차트 초기화
                plotModelImp.Series.Clear();

                var lineSeries = new LineSeries
                {
                    Color = OxyColors.Blue,

                };
                foreach (var data in datas)
                    lineSeries.Points.Add(new DataPoint(data.Freq, data.D));
                    plotModelImp.Series.Add(lineSeries);

                    plotModelImp.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거
            }

            if (iQ_ButtonState == IQ_ButtonEnum.E.ToString())
            {
                //차트 초기화
                plotModelImp.Series.Clear();

                var lineSeries = new LineSeries
                {
                    Color = OxyColors.Blue,

                };
                foreach (var data in datas)
                    lineSeries.Points.Add(new DataPoint(data.Freq, data.E));
                plotModelImp.Series.Add(lineSeries);

                plotModelImp.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거
            }

            if (iQ_ButtonState == IQ_ButtonEnum.F.ToString())
            {
                //차트 초기화
                plotModelImp.Series.Clear();

                var lineSeries = new LineSeries
                {
                    Color = OxyColors.Blue,

                };
                foreach (var data in datas)
                    lineSeries.Points.Add(new DataPoint(data.Freq, data.F));
                plotModelImp.Series.Add(lineSeries);

                plotModelImp.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거
            }

        }

        public void ClearChartMethod()
        {
            plotModelImp.Series.Clear();
            plotModelImp.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거

        }


    }
}
