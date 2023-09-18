﻿using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using WpfApp2.viewmodel;
using WpfApp2.util;

namespace WpfApp2.Commands.FreqSearchPage
{
    class FindBySapnCommand : CommandBase
    {
        private MainViewModel mainViewModel;
        private IRepository _dataRepository;
        private delegate void ChangeChart(List<Data> datas);

        public FindBySapnCommand(MainViewModel mainViewModel, IRepository _dataRepository)
        {
            this.mainViewModel = mainViewModel;
            this._dataRepository = _dataRepository;
        }

        private void FindBySapn()
        {
            try
            {
                int pageNumber = Int32.Parse(mainViewModel.PageNumber);
                List<Data> datas = _dataRepository.GetDataBox()[pageNumber - 1];

                //만약 둘다 널값 초기화 span
                if(mainViewModel.SpanTxt == ""&&mainViewModel.FreTxt=="") {
                    CommonDelegate.chageChart(ref datas);
                    return;
                }


                ResultSpan(ref datas);
            }
            catch (Exception ex) { MessageBox.Show("없는 페이지 입니다"); }

        }

        //범위 탐색
        private void ResultSpan(ref List<Data>datas)
        {
            
            List<Data>ResultDatas= new List<Data>();
            int selecteFre = Int32.Parse(mainViewModel.FreTxt);
            int span =Int32.Parse(mainViewModel.SpanTxt)/2;


            foreach(Data data in datas)
            {
                if (data.Frequency >= (selecteFre - span) && data.Frequency <= (selecteFre + span))
                {
                    ResultDatas.Add(data);
                }
            }

            CommonDelegate.chageChart(ref ResultDatas);
            
        }
    
        public override bool CanExecute(object parameter)
        {
            return true;

        }

        public override void Execute(object parameter)
        {
            FindBySapn();
        }
    }
}
