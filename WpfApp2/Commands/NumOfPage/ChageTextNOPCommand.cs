using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Xml.Linq;
using WpfApp2.util;
using WpfApp2.viewmodel;

namespace WpfApp2.Commands
{
    class ChageTextNOPCommand : CommandBase
    {

        private MainViewModel mainViewModel;
        private IRepository _dataRepository;

        public ChageTextNOPCommand(MainViewModel mainViewModel, IRepository _dataRepository)
        {
            this.mainViewModel = mainViewModel;
            this._dataRepository = _dataRepository;
        }

        private void chageText()
        { 

            List<Data> datas = _dataRepository.GetDatas();
            List<List<Data>> dataBox = _dataRepository.GetDataBox();
            try
            {
                int pageNumber = Int32.Parse(mainViewModel.PageNumber);
                int divisonNum =datas.Count / Int32.Parse(mainViewModel.PageNumber);
                

                //데이터갯수가 10 이하일때 처리하기위한 조건문
                if (datas.Count >= 10)
                {
                    //최대값 넘어가면 예외 발생
                    if (pageNumber > datas.Count / 10 || pageNumber <= 0)
                        throw new OverPageEx();

                    DivisionData(ref dataBox, ref datas, ref divisonNum);

                    mainViewModel.MaxAndCurPage = "1/" + dataBox.Count;
                    mainViewModel.CurrentPage = "1";
                }
                else
                { 
                    //음수면 예외 발생
                    if (pageNumber>1 || pageNumber <= 0)
                        throw new OverPageEx();

                    DivisionData(ref dataBox, ref datas, ref divisonNum);
                    mainViewModel.MaxAndCurPage = "1/" + dataBox.Count;
                    mainViewModel.CurrentPage = "1";
                }

            }
            catch(OverPageEx e) {MessageBox.Show("커스텀 잘못된 입력값 입니다. 현재 데이터 갯수: " + datas.Count()); }
            catch(FormatException e) { return; }
            catch(Exception e) { 
                MessageBox.Show("잘못된 입력값 입니다. 현재 데이터 갯수: " + datas.Count()); }
        }



        //데이터 나누기
        private void DivisionData(ref List<List<Data>>dataBox, ref List<Data>datas,ref int divisonNum)
        {
            //데이터 초기화
            _dataRepository.ClearDataBox();

            //PageNumber 갯수마다 데이터 저장 및 페이징
            //데이터 손실 때문에 안나눠 질 때 맨 마지막에 데이터 집어 넣음
            if(datas.Count% Int32.Parse(mainViewModel.PageNumber) == 0)
            {
                for (int i = 0; i < (datas.Count); i += divisonNum)
                {
                    List<Data> sublist = datas.Skip(i).Take(divisonNum).ToList();

                    dataBox.Add(sublist);
                }
            }
            else {
                Console.WriteLine(Int32.Parse(mainViewModel.PageNumber));
                int i = 0;
                for (int j = 0; j < Int32.Parse(mainViewModel.PageNumber) - 1; j ++) //
                {
                    List<Data> sublist = datas.Skip(i).Take(divisonNum).ToList();

                    dataBox.Add(sublist);
                    i += divisonNum;
                }
                List<Data> remainingObjects = datas.Skip(datas.Count - divisonNum).ToList();
                dataBox.Add(remainingObjects);
            }
            
            Console.WriteLine(dataBox.Count);
            //첫번째 데이터 차트 표시
            List<Data> firstData = dataBox[0];
            mainViewModel.PlotModelmp.ChageCharMethod(ref firstData);
        }



        public override bool CanExecute(object parameter)
        {
           
            return true;
        }

        public override void Execute(object parameter)
        {
            chageText();
        }
    }
}
