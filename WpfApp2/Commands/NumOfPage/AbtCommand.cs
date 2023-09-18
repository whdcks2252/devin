using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp2.viewmodel;

namespace WpfApp2.Commands.NumOfPage
{
    class AbtCommand : CommandBase
    {
        private MainViewModel mainViewModel;
        private IRepository _dataRepository;

        public AbtCommand(MainViewModel mainViewModel, IRepository _dataRepository)
        {
            this.mainViewModel = mainViewModel;
            this._dataRepository = _dataRepository;
        }

        private void abt()
        {
            if (mainViewModel.AbtBG != Brushes.Black)
            {
                mainViewModel.AbtBG = Brushes.Black;
                mainViewModel.AbtFG = Brushes.White;
            }
            else
            {
                mainViewModel.AbtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                mainViewModel.AbtFG = Brushes.Black;
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
