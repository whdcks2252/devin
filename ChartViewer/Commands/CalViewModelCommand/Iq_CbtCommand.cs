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
     class Iq_CbtCommand : CommandBase
    {
        private CalViewModel calViewModel;
        private ICalDataRepository _calDataRepository;

        public Iq_CbtCommand(CalViewModel calViewModel, ICalDataRepository _calDataRepository)
        {
            this.calViewModel = calViewModel;
            this._calDataRepository = _calDataRepository;
        }

        private void cbt()
        {
            if (!(calViewModel.CbtBG == Brushes.Black))
            {
                calViewModel.ButtonOnOff = IQ_ButtonEnum.C;
                calViewModel.CbtBG = Brushes.Black;
                calViewModel.CbtFG = Brushes.White;

                chageChart();
            }
            else
            {
                calViewModel.ButtonOnOff = IQ_ButtonEnum.NULL;
                calViewModel.CbtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                calViewModel.CbtFG = Brushes.Black;
                PlotModelImp.GetPlotModelImp().ClearChartMethod();

            }
        }

        private bool ButtonOnOff()
        {
            if (calViewModel.ButtonOnOff==IQ_ButtonEnum.NULL||calViewModel.ButtonOnOff==IQ_ButtonEnum.C)
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
            cbt();
        }
    }
}
