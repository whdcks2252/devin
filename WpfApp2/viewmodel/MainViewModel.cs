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
using WpfApp2.util;

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
            ChageTextNOP=new ChageTextNOPCommand(this, _dataRepository);
            PlotModelmp = PlotModelImp.GetPlotModelImp();
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
            //FreqSearchPageCommand
       public ICommand FindBySapn {  get; set; }
        
        ////oxyPlot
        public PlotModelImp PlotModelmp { get; set; }


        ////Property
        //main
        private string txtBlock;
        private string yLable;
        private object fr1Content;
        private object fr2Content;

        //NumOfPage
        private string pageNumber;


        //PageSearchPage
        private string seachTextBoxTx;
        private string maxAndCurPage = "1/n";
        private string currentPage;
        private Brush pageSearchPageBtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private Brush pageSearchPageBtFG = Brushes.Black;
        private Visibility pageSearchPageBtVis;

        //FreSearchPage
        private string freTxt;
        private string spanTxt;
        private Brush freSearchPageBtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private Brush freSearchPageBtFG = Brushes.Black;
        private Visibility freSearchPageBtVis = Visibility.Visible;

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
        public string YLable
        {
            get { return yLable; }
            set
            {
                if (yLable != value)
                {
                    yLable = value;
                    OnPropertyChanged("YLable");//속성값이 들어가야함
                }
            }
        }

        public object Fr1Content
        {
            get { return fr1Content; }
            set
            {
                if (fr1Content != value)
                {
                    fr1Content = value;
                    OnPropertyChanged("Fr1Content");//속성값이 들어가야함
                }
            }
        }
        public object Fr2Content
        {
            get { return fr2Content; }
            set
            {
                if (fr2Content != value)
                {
                    fr2Content = value;
                    OnPropertyChanged("Fr2Content");//속성값이 들어가야함
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

        public Brush PageSearchPageBtFG
        {
            get { return pageSearchPageBtFG; }
            set
            {
                if (pageSearchPageBtFG != value)
                {
                    pageSearchPageBtFG = value;
                    OnPropertyChanged("PageSearchPageBtFG");//속성값이 들어가야함
                }
            }
        }
        public Brush PageSearchPageBtBG
        {
            get { return pageSearchPageBtBG; }
            set
            {
                if (pageSearchPageBtBG != value)
                {
                    pageSearchPageBtBG = value;
                    OnPropertyChanged("PageSearchPageBtBG");//속성값이 들어가야함
                }
            }
        }
        public Visibility PageSearchPageBtVis
        {
            get { return pageSearchPageBtVis; }
            set
            {
                if (pageSearchPageBtVis != value)
                {
                    pageSearchPageBtVis = value;
                    OnPropertyChanged("PageSearchPageBtVis");//속성값이 들어가야함
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
        public Brush FreSearchPageBtBG
        {
            get { return freSearchPageBtBG; }
            set
            {
                if (freSearchPageBtBG != value)
                {
                    freSearchPageBtBG = value;
                    OnPropertyChanged("FreSearchPageBtBG");//속성값이 들어가야함
                }
            }
        }
        public Brush FreSearchPageBtFG
        {
            get { return freSearchPageBtFG; }
            set
            {
                if (freSearchPageBtFG != value)
                {
                    freSearchPageBtFG = value;
                    OnPropertyChanged("FreSearchPageBtFG");//속성값이 들어가야함
                }
            }
        }
        public Visibility FreSearchPageBtVis
        {
            get { return freSearchPageBtVis; }
            set
            {
                if (freSearchPageBtVis != value)
                {
                    freSearchPageBtVis = value;
                    OnPropertyChanged("FreSearchPageBtVis");//속성값이 들어가야함
                }
            }
        }

    }
}
