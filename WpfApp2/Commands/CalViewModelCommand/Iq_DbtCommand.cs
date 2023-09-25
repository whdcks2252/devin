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
     class Iq_DbtCommand : CommandBase
    {
        private CalViewModel calViewModel;
        private ICalDataRepository _calDataRepository;

        public Iq_DbtCommand(CalViewModel calViewModel, ICalDataRepository _calDataRepository)
        {
            this.calViewModel = calViewModel;
            this._calDataRepository = _calDataRepository;
        }

        private void dbt()
        {
            if (!(calViewModel.DbtBG == Brushes.Black))
            {
                calViewModel.ButtonOnOff = IQ_ButtonEnum.D;
                calViewModel.DbtBG = Brushes.Black;
                calViewModel.DbtFG = Brushes.White;

                chageChart();
            }
            else
            {
                calViewModel.ButtonOnOff = IQ_ButtonEnum.NULL;
                calViewModel.DbtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                calViewModel.DbtFG = Brushes.Black;
                PlotModelImp.GetPlotModelImp().ClearChartMethod();

            }
        }

        private bool ButtonOnOff()
        {
            if (calViewModel.ButtonOnOff==IQ_ButtonEnum.NULL||calViewModel.ButtonOnOff==IQ_ButtonEnum.D)
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
            dbt();
        }
    }
}
