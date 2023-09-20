using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp2.viewmodel;

namespace WpfApp2.Commands
{
    class AbtCommand : CommandBase
    {
        private CalViewModel calViewModel;
        private IRepository _dataRepository;

        public AbtCommand(CalViewModel calViewModel, IRepository _dataRepository)
        {
            this.calViewModel = calViewModel;
            this._dataRepository = _dataRepository;
        }

        private void abt()
        {
            if (calViewModel.AbtBG != Brushes.Black)
            {
                calViewModel.AbtBG = Brushes.Black;
                calViewModel.AbtFG = Brushes.White;
            }
            else
            {
                calViewModel.AbtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                calViewModel.AbtFG = Brushes.Black;
            }
        }
        public override bool CanExecute(object parameter)
        {
            return true;
            
        }

        public override void Execute(object parameter)
        {
            abt();
        }
    }
}
