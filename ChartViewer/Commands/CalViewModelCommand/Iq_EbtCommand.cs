using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ChartViewer.util;
using ChartViewer.viewmodel;

namespace ChartViewer.Commands.CalViewModelCommand
{
     class Iq_EbtCommand : CommandBase
    {
        private CalViewModel calViewModel;
        private ICalDataRepository _calDataRepository;

        public Iq_EbtCommand(CalViewModel calViewModel, ICalDataRepository _calDataRepository)
        {
            this.calViewModel = calViewModel;
            this._calDataRepository = _calDataRepository;
        }

        private void ebt()
        {
            if (!(calViewModel.EbtBG == Brushes.Black))
            {
                calViewModel.ButtonOnOff = IQ_ButtonEnum.E;
                calViewModel.EbtBG = Brushes.Black;
                calViewModel.EbtFG = Brushes.White;

                chageChart();
            }
            else
            {
                calViewModel.ButtonOnOff = IQ_ButtonEnum.NULL;
                calViewModel.EbtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                calViewModel.EbtFG = Brushes.Black;
                PlotModelImp.GetPlotModelImp().ClearChartMethod();

            }
        }

        private bool ButtonOnOff()
        {
            if (calViewModel.ButtonOnOff==IQ_ButtonEnum.NULL||calViewModel.ButtonOnOff==IQ_ButtonEnum.E)
            {
                return true;
            }
            
            else
                return false;
            
        }

        private void chageChart()
        {
            string buttonState = calViewModel.ButtonOnOff.ToString();
            List<Data> datas = ChangeData.ConverterIQ(ref _calDataRepository, buttonState);
            PlotModelImp.GetPlotModelImp().ChageCharMethod(ref datas);
        }
        public override bool CanExecute(object parameter)
        {
            return ButtonOnOff();
        }

        public override void Execute(object parameter)
        {
            ebt();
        }
    }
}
