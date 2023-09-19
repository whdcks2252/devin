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
using WpfApp2.Commands.FreqSearchPage;
using WpfApp2.Commands.NumOfPage;
using WpfApp2.Commands.PageSearchPage;

namespace WpfApp2.viewmodel
{
    class MainViewModel:ViewModelBase
    {
        private  IRepository _dataRepository;
        private  static MainViewModel mainViewModel;

        public MainViewModel(IRepository _dataRepository)
        {
            this._dataRepository = _dataRepository;
            SaveData = new SaveCommand(this, _dataRepository); //save 커맨드 이벤트
            PageSearchBt=new PageSearchBtCommand(this, _dataRepository);
            FreSearchBt = new FreqSearchBtCommand(this, _dataRepository);
            FindPage = new FindPageCommand(this, _dataRepository); //FindPage 커맨드 이벤트
            UpPage = new UpPageCommand(this, _dataRepository);
            DownPage = new DownPageCommand(this, _dataRepository);
            FindBySapn = new FindBySapnCommand(this, _dataRepository);
            Abt=new AbtCommand(this, _dataRepository);
            ChageTextNOP=new ChageTextNOPCommand(this, _dataRepository);

            SetPlotModel();
        }

        //객체 인스턴스
        public static MainViewModel GetMainViewModel()
        {
            if (mainViewModel == null)
            {
                mainViewModel = new MainViewModel(DataRepository.GetDataRepository());
            }
            return mainViewModel;

        }


       ////Command
            //MainComand
        public ICommand SaveData { get; set; }
        public ICommand FreSearchBt { get; set; }
        public ICommand PageSearchBt {  get; set; }

        //PageCommand
        public ICommand FindPage { get; set; }
        public ICommand UpPage {  get; set; }
        public ICommand DownPage { get; set; }
            //NumOfPage
        public ICommand ChageTextNOP { get; set; }
        public ICommand Abt {  get; set; }
            //FreqSearchPageCommand
       public ICommand FindBySapn {  get; set; }
        
        ////oxyPlot
        public PlotModel PlotModel { get; set; }

        private void SetPlotModel()
        {
            //PlotModel 생성
            PlotModel = new PlotModel() { Title = "Chart" };

            //x축 생성
           PlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "frequency(GHz)",
                IsZoomEnabled = false,
            });
            //y축 생성
           PlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "value(dBm)",
                MajorGridlineStyle = LineStyle.Solid,
                IsZoomEnabled=false
            });
            
        }


        ////Property
        //main
        private string txtBlock;

        //NumOfPage
        private string pageNumber;

        //--abt
        private Brush abtBG= new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private Brush abtFG = Brushes.Black;

        //PageSearchPage
        private string seachTextBoxTx;
        private string maxAndCurPage = "1/n";
        private string currentPage;

        //FreSearchPage
        private string freTxt;
        private string spanTxt;


        //main
        public string TxtBlock {
            get { return txtBlock; }
            set
            {
                if (txtBlock != value)
                {
                    txtBlock = value;
                    OnPropertyChanged("TxtBlock");//속성값이 들어가야함
                }
            }
        }

        //NumOfPage
        public string SeachTextBoxTx {
            get { return seachTextBoxTx; }
            set
            {
                if (seachTextBoxTx != value)
                {
                    seachTextBoxTx = value;
                    OnPropertyChanged("SeachTextBoxTx");//속성값이 들어가야함
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

        //PageSearchPage
        public string PageNumber {
            get { return pageNumber; }
            set
            {
                if (pageNumber != value)
                {
                    pageNumber = value;
                    OnPropertyChanged("PageNumber");//속성값이 들어가야함
                }
            }
        }
        public string MaxAndCurPage {
            get { return maxAndCurPage; }
            set
            {
                if (maxAndCurPage != value)
                {
                    maxAndCurPage = value;
                    OnPropertyChanged("MaxAndCurPage");//속성값이 들어가야함
                }
            }
        }
        public string CurrentPage { get; set; }

        //FreSearchPage
        public string FreTxt
        {
            get { return freTxt; }
            set
            {
                if (freTxt != value)
                {
                    freTxt = value;
                    OnPropertyChanged("FreTxt");//속성값이 들어가야함
                }
            }
        }
        public string SpanTxt
        {
            get { return spanTxt; }
            set
            {
                if (spanTxt != value)
                {
                    spanTxt = value;
                    OnPropertyChanged("SpanTxt");//속성값이 들어가야함
                }
            }
        }
    }
}
