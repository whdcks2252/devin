using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp2.util;
using WpfApp2.viewmodel;

namespace WpfApp2.Commands.CalViewModelCommand
{
     class Iq_FbtCommand : CommandBase
    {
        private CalViewModel calViewModel;
        private ICalDataRepository _calDataRepository;

        public Iq_FbtCommand(CalViewModel calViewModel, ICalDataRepository _calDataRepository)
        {
            this.calViewModel = calViewModel;
            this._calDataRepository = _calDataRepository;
        }

        private void fbt()
        {
            if (!(calViewModel.FbtBG == Brushes.Black))
            {
                calViewModel.ButtonOnOff = IQ_ButtonEnum.F;
                calViewModel.FbtBG = Brushes.Black;
                calViewModel.FbtFG = Brushes.White;

                chageChart();
            }
            else
            {
                calViewModel.ButtonOnOff = IQ_ButtonEnum.NULL;
                calViewModel.FbtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                calViewModel.FbtFG = Brushes.Black;
                PlotModelImp.GetPlotModelImp().ClearChartMethod();

            }
        }

        private bool ButtonOnOff()
        {
            if (calViewModel.ButtonOnOff == IQ_ButtonEnum.NULL || calViewModel.ButtonOnOff == IQ_ButtonEnum.F)
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
            fbt();
        }
    }
}
