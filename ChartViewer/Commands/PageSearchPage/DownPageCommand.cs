﻿using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartViewer.viewmodel;
using System.Windows;
using ChartViewer.util;
using System.Data;

namespace ChartViewer.Commands
{
    class DownPageCommand : CommandBase
    {
        private MainViewModel mainViewModel;
        private IRepository _dataRepository;
        public DownPageCommand(MainViewModel mainViewModel,IRepository _dataRepository) {
            this.mainViewModel = mainViewModel;
            this._dataRepository = _dataRepository;

        }

        private void DownPage()
        {
            try
            {
                List<List<Data>> dataBox = _dataRepository.GetDataBox();
                int currentPage = Int32.Parse(mainViewModel.CurrentPage);

                //현재 페이지 -1
                List<Data> datas = _dataRepository.GetDataBox()[currentPage - 2];

                mainViewModel.PlotModelmp.ChageCharMethod(ref datas);

                mainViewModel.CurrentPage = "" + (currentPage - 1);
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
            DownPage();

        }
    }
}
