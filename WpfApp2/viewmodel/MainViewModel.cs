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
        private   IRepository _dataRepository;
        private  static MainViewModel mainViewModel;

        public MainViewModel(IRepository _dataRepository)
        {
            this._dataRepository = _dataRepository;
            SaveCommand = new SaveCommand(this, _dataRepository); //save 커맨드 이벤트
            FindPage = new FindPageCommand(this, _dataRepository); //FindPage 커맨드 이벤트
            UpPage = new UpPageCommand(this, _dataRepository);
            DownPage = new DownPageCommand(this, _dataRepository);
            FindBySapn = new FindBySapnCommand(this, _dataRepository);
            PageSearchBt=new PageSearchBtCommand(this, _dataRepository);
            AbtCommand=new AbtCommand(this, _dataRepository);
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
        public ICommand SaveCommand { get; set; }
            //PageCommand
        public ICommand FindPage { get; set; }
        public ICommand UpPage {  get; set; }
        public ICommand DownPage { get; set; }
        public ICommand PageSearchBt {  get; set; }
            //NumOfPage
        public ICommand AbtCommand {  get; set; }
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
            

            //태스트 코드
            var dataBox = _dataRepository.GetDataBox();

                var lineSeries = new LineSeries
                {
                    Color = OxyColors.Black,
                   
                };

            foreach (var datas in dataBox)
            {
                foreach (var data in datas)
                lineSeries.Points.Add(new DataPoint(data.Frequency, data.Values));
            }
                PlotModel.Series.Add(lineSeries);
            //테스트 코드 끝

        }


        ////Property
        //main
        private string txtBlock;
        //NumOfPage
        private string seachTextBoxTx;
            //--abt
        private Brush abtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private Brush abtFG = Brushes.Black;

        //PageSearchPage
        private string pageNumber;

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
