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
using WpfApp2.Commands.CalViewModelCommand;

namespace WpfApp2.viewmodel
{
    class CalViewModel : ViewModelBase
    {
        private ICalDataRepository _calDataRepository;
        private static CalViewModel calViewModel;
        private MainViewModel mainViewModel;
        public CalViewModel(ICalDataRepository _calDataRepository, MainViewModel mainViewModel)
        {
            this._calDataRepository = _calDataRepository;
            this.mainViewModel = mainViewModel;
            Iq_Abt = new Iq_AbtCommand(this, _calDataRepository);
            Iq_Bbt = new Iq_BbtCommand(this, _calDataRepository);
            Iq_Cbt = new Iq_CbtCommand(this, _calDataRepository);
            Iq_Dbt = new Iq_DbtCommand(this, _calDataRepository);
            Iq_Ebt = new Iq_EbtCommand(this, _calDataRepository);
            Iq_Fbt = new Iq_FbtCommand(this, _calDataRepository);
            Atten = new AttenCommad(this, _calDataRepository);

        }

        //객체 인스턴스
        public static CalViewModel GetMainViewModel()
        {
            if (calViewModel == null)
            {
                calViewModel = new CalViewModel(CalDataRepository.GetCalDataRepository(), MainViewModel.GetMainViewModel());
            }
            return calViewModel;

        }

        public static void ClearProp()
        {
            CalViewModel.GetMainViewModel().AttenTxt = "";
        }

        //IQ command
        public ICommand Iq_Abt { get; set; }
        public ICommand Iq_Bbt { get; set; }
        public ICommand Iq_Cbt { get; set; }
        public ICommand Iq_Dbt { get; set; }
        public ICommand Iq_Ebt { get; set; }
        public ICommand Iq_Fbt { get; set; }

        //Atten command
        public ICommand Atten {  get; set; }



        //IQ_Button Onoff
        public IQ_ButtonEnum ButtonOnOff { get; set; } = IQ_ButtonEnum.NULL;

        //--abt
        private Brush abtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private Brush abtFG = Brushes.Black;

        //--bbt
        private Brush bbtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private Brush bbtFG = Brushes.Black;

        //--cbt
        private Brush cbtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private Brush cbtFG = Brushes.Black;

        //--cbt
        private Brush dbtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private Brush dbtFG = Brushes.Black;
        //--cbt
        private Brush ebtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private Brush ebtFG = Brushes.Black;
        //--cbt
        private Brush fbtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private Brush fbtFG = Brushes.Black;

        //Atten
        private string attenTxt;

        public string AttenTxt {
            get { return attenTxt; }
            set
            {
                if (attenTxt != value)
                {
                    attenTxt = value;
                    OnPropertyChanged("AttenTxt");//속성값이 들어가야함
                }
            }
        }




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

        //--bbt
        public Brush BbtFG
        {
            get { return bbtFG; }
            set
            {
                if (bbtFG != value)
                {
                    bbtFG = value;
                    OnPropertyChanged("BbtFG");//속성값이 들어가야함
                }
            }
        }
        public Brush BbtBG
        {
            get { return bbtBG; }
            set
            {
                if (bbtBG != value)
                {
                    bbtBG = value;
                    OnPropertyChanged("BbtBG");//속성값이 들어가야함
                }
            }
        }
        
        //--cbt
        public Brush CbtFG
        {
            get { return cbtFG; }
            set
            {
                if (cbtFG != value)
                {
                    cbtFG = value;
                    OnPropertyChanged("CbtFG");//속성값이 들어가야함
                }
            }
        }
        public Brush CbtBG
        {
            get { return cbtBG; }
            set
            {
                if (cbtBG != value)
                {
                    cbtBG = value;
                    OnPropertyChanged("CbtBG");//속성값이 들어가야함
                }
            }
        }
        //--dbt
        public Brush DbtFG
        {
            get { return dbtFG; }
            set
            {
                if (dbtFG != value)
                {
                    dbtFG = value;
                    OnPropertyChanged("DbtFG");//속성값이 들어가야함
                }
            }
        }
        public Brush DbtBG
        {
            get { return dbtBG; }
            set
            {
                if (dbtBG != value)
                {
                    dbtBG = value;
                    OnPropertyChanged("DbtBG");//속성값이 들어가야함
                }
            }
        }
        //--ebt
        public Brush EbtFG
        {
            get { return ebtFG; }
            set
            {
                if (ebtFG != value)
                {
                    ebtFG = value;
                    OnPropertyChanged("EbtFG");//속성값이 들어가야함
                }
            }
        }
        public Brush EbtBG
        {
            get { return ebtBG; }
            set
            {
                if (ebtBG != value)
                {
                    ebtBG = value;
                    OnPropertyChanged("EbtBG");//속성값이 들어가야함
                }
            }
        }
        //--fbt
        public Brush FbtFG
        {
            get { return fbtFG; }
            set
            {
                if (fbtFG != value)
                {
                    fbtFG = value;
                    OnPropertyChanged("FbtFG");//속성값이 들어가야함
                }
            }
        }
        public Brush FbtBG
        {
            get { return fbtBG; }
            set
            {
                if (fbtBG != value)
                {
                    fbtBG = value;
                    OnPropertyChanged("FbtBG");//속성값이 들어가야함
                }
            }
        }
    }
}
