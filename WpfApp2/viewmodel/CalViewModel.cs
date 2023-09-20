using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp2.Commands;

namespace WpfApp2.viewmodel
{
    class CalViewModel : ViewModelBase
    {
        private IRepository _dataRepository;
        private static CalViewModel calViewModel;
        private MainViewModel mainViewModel;
        public CalViewModel(IRepository _dataRepository,MainViewModel mainViewModel)
        {
            this._dataRepository = _dataRepository;
            this.mainViewModel = mainViewModel;
            Abt = new AbtCommand(this, _dataRepository);

        }

        //객체 인스턴스
        public static CalViewModel GetMainViewModel()
        {
            if (calViewModel == null)
            {
                calViewModel = new CalViewModel(DataRepository.GetDataRepository(),MainViewModel.GetMainViewModel());
            }
            return calViewModel;

        }

        public ICommand Abt { get; set; }


        //--abt
        private Brush abtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private Brush abtFG = Brushes.Black;

        //--abt
        public Brush AbtFG
        {
            get { return abtFG; }
            set
            {
                if (abtFG != value)
                {
                    abtFG = value;
                    OnPropertyChanged("AbtFG");//속성값이 들어가야함
                }
            }
        }
        public Brush AbtBG
        {
            get { return abtBG; }
            set
            {
                if (abtBG != value)
                {
                    abtBG = value;
                    OnPropertyChanged("AbtBG");//속성값이 들어가야함
                }
            }
        }

    }
}
