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
     class Iq_BbtCommand : CommandBase
    {
        private CalViewModel calViewModel;
        private ICalDataRepository _calDataRepository;

        public Iq_BbtCommand(CalViewModel calViewModel, ICalDataRepository _calDataRepository)
        {
            this.calViewModel = calViewModel;
            this._calDataRepository = _calDataRepository;
        }

        private void bbt(string param)
        {

            chageChart(param);

        }



        private void chageChart(string param)
        {
            string buttonState = param;
            List<Data> datas = ChangeData.ConverterIQ(ref _calDataRepository, buttonState);
            PlotModelImp.GetPlotModelImp().ChageCharMethod(ref datas);
        }

        public override bool CanExecute(object parameter)
        {
            //return ButtonOnOff();
            return true;

        }

        public override void Execute(object parameter)
        {
            bbt(parameter.ToString());
        }
    }
}
