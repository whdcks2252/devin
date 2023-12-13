using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ChartViewer.viewmodel;
using ChartViewer.util;

namespace ChartViewer.Commands
{


     class UpPageCommand:CommandBase
    {
        private MainViewModel mainViewModel;
        private IRepository _dataRepository;

        public UpPageCommand(MainViewModel mainViewModel, IRepository _dataRepository)
        {
            this.mainViewModel = mainViewModel;
            this._dataRepository = _dataRepository;
        }

        private void UpPage()
        {
            try
            {
                List<List<Data>> dataBox = _dataRepository.GetDataBox();
                int currentPage = Int32.Parse(mainViewModel.CurrentPage);

                //현재 페이지 +1
                List<Data> datas = _dataRepository.GetDataBox()[currentPage];

                mainViewModel.PlotModelmp.ChageCharMethod(ref datas);

              
                mainViewModel.CurrentPage = "" + (currentPage + 1);
                mainViewModel.MaxAndCurPage = mainViewModel.CurrentPage + "/" + dataBox.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("없는 페이지 입니다");
            }
        }


        public override bool CanExecute(object parameter)
        {
            return true;

        }

        public override void Execute(object parameter)
        {
            UpPage();
        }
    }
}
