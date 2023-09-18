﻿using Microsoft.Win32;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp2.viewmodel;
using System.Windows.Markup;
using System.Data;

namespace WpfApp2.Commands
{
    class SaveCommand : CommandBase
    {
        private  MainViewModel mainViewModel;
        private  IRepository _dataRepository;

        public SaveCommand(MainViewModel mainViewModel, IRepository _dataRepository)
        {
            this.mainViewModel = mainViewModel;
            this._dataRepository = _dataRepository;
        }

        private void save()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TEXT files (*.txt)|*.txt|CAL files (*.cal)|*.cal|TEXT,CAL(*.txt,*.cal)|*.txt;*.cal";

            if (openFileDialog.ShowDialog() == true)
            {
                //반복문이 많을시 StreamReader로 파일 입출력을 하는게 File 클래스 보다 좋음 
                using (StreamReader rd = new StreamReader(openFileDialog.FileName))
                {
                    List<string> textVale = new List<string>();
                    string[] splitData = new string[2];

                    while (!rd.EndOfStream)
                    {
                        textVale.Add(rd.ReadLine());
                    }

                    try
                    {
                        if (textVale.Count > 0)
                        {   //데이터파일생성
                            List<Data> datas = new List<Data>();
                            for (int i = 0; i < textVale.Count; i++)
                            {
                                if (!CheckFileForm(textVale[i], ref splitData))
                                    return;

                                // 데이터 생성 후 저장소에 저장
                                CreateData(ref splitData,ref datas);

                                //Console.WriteLine("TextFile" + (i + 1).ToString() + "번째 줄.");
                                //Console.WriteLine(_dataRepository.GetDatas()[i].Frequency + " " + _dataRepository.GetDatas()[i].Values);
                            }

                            //데이터 저장소에 데이터 저장
                            _dataRepository.SaveDataBox(ref datas);

                            //Block에 파일 경로 표시
                            ChageBlock(ref openFileDialog);

                            //차트 변경
                            ChageChar(ref datas);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("잘못된 형식의 파일 입니다");}
                }


            }
        }
        //Bock에 파일 경로 표시 바인딩
        private void ChageBlock(ref OpenFileDialog openFileDialog)
        {
            string[] source = openFileDialog.FileNames[0].Split('\\');
            mainViewModel.TxtBlock = source[source.Length - 1];
            Console.WriteLine(mainViewModel.TxtBlock);
        }

        // 저장후 차트 변경
        private void ChageChar(ref List<Data> datas)
        {  
            //차트 초기화
            mainViewModel.PlotModel.Series.Clear();

            var dataBox = _dataRepository.GetDataBox();

            var lineSeries = new LineSeries
            {
                Color = OxyColors.Black,

            };
            foreach (var data in datas)
              lineSeries.Points.Add(new DataPoint(data.Frequency, data.Values));

            mainViewModel.PlotModel.Series.Add(lineSeries);

            mainViewModel.PlotModel.InvalidatePlot(true);// 바인딩 즉시업데이트 트리거

            //pageNumber 변경
            if (mainViewModel.PageNumber == null)
            {
                mainViewModel.PageNumber = 1.ToString();
            }
            else
                mainViewModel.PageNumber = (Int32.Parse(mainViewModel.PageNumber) + 1).ToString();
        }
    

        // 데이터 생성 후 저장소에 저장
        private void CreateData(ref string[] splitData,ref List<Data> datas)
        {
            //데이터 키:쌍 값으로 생성
            Data data = new Data() {
            Frequency= (Double.Parse(splitData[0])),
            Values= (Double.Parse(splitData[1]))
            };
           
            datas.Add(data);
            

        }


        //Delimiter 검증 함수
        private bool CheckFileForm(string str, ref string[] splitData)
        {
            try
            {

                if (str.IndexOf(',') != -1)
                {
                    splitData = str.Split(',');
                    return true;
                }
                else if (str.IndexOf(' ') != -1)
                {
                    splitData = str.Split(' ');
                    return true;
                }
                else if (str.IndexOf('\t') != -1)
                {
                    splitData = str.Split('\t');
                    return true;
                }
                else
                    MessageBox.Show("잘못된 형식의 파일 입니다");
                return false;

            }
            catch (Exception ex) { MessageBox.Show("잘못된 형식의 파일 입니다");}
            return false;
        }



        //comand 구현체
        public event EventHandler CanExecuteChanged; //canExecute에 변화에 따라 ui에 알려주는 이벤트

        public override bool CanExecute(object parameter)//excute가 실행되냐 안되냐 함수
        {
            return true;
        }

        public override void Execute(object parameter) //버튼 실행시 실행되는 함수
        {
            save();

        }
       

    }
}
