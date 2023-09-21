using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WpfApp2.util;
using WpfApp2.viewmodel;

namespace WpfApp2.Commands.CalViewModelCommand
{
     class AttenCommad : CommandBase
    {
        private CalViewModel calViewModel;
        private ICalDataRepository _calDataRepository;

        public AttenCommad(CalViewModel calViewModel, ICalDataRepository _calDataRepository)
        {
            this.calViewModel = calViewModel;
            this._calDataRepository = _calDataRepository;
        }


        private void Atten()
        {
            string input = calViewModel.AttenTxt;
            if (IsValidAttenInput(ref input))
            {

                CalculateAttenAccuracy(calViewModel.AttenTxt);

            }
            else
            {
                MessageBox.Show("올바른 입력값을 입력하세요. (0~60 사이의 숫자와 '~' 또는 범위 형식만 입력 가능)");
            }
        }

        private  bool IsValidAttenInput(ref string input)
        {
            // 입력이 숫자 또는 숫자 범위 형식인지 확인하는 함수
            int number;
            if (int.TryParse(input, out number))
            {
                // 입력이 숫자인 경우, 범위 체크
                return number >= 0 && number <= 60;
            }
            else if (input.Contains("~"))
            {
                // 입력에 '~'가 있는 경우, 범위 형식 체크
                string[] parts = input.Split('~');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int min) &&
                    int.TryParse(parts[1], out int max))
                {
                    return min >= 0 && max <= 60 && min <= max;
                }
            }
            return false;
        }
    

        private  void  CalculateAttenAccuracy(string attenInput)
        {
            // 주어진 Frequency와 Atten 입력에 따라 Atten Accuracy를 계산
            // 이 함수는 입력이 단일 Atten 값 또는 Atten 범위 값에 따라 계산을 다르게 수행함.
            if (attenInput.Contains("~"))
            {
                // Atten 범위 값인 경우
                string[] rangeParts = attenInput.Split('~');
                if (rangeParts.Length == 2 && int.TryParse(rangeParts[0], out int minAtten) && int.TryParse(rangeParts[1], out int maxAtten))
                {
                    List<Data> resultData = _calDataRepository.DoubleAttenCal(minAtten, maxAtten);

                    ChangeData.tempAtten(ref resultData);

                    PlotModelImp.GetPlotModelImp().ChageCharMethod(ref resultData);

                }
            }
            else
            {
                // 단일 Atten 값인 경우
                if (int.TryParse(attenInput, out int targetAtten))
                {
                    List<Data> resultData = _calDataRepository.SingAttenCal(targetAtten);

                    ChangeData.tempAtten(ref resultData);

                    PlotModelImp.GetPlotModelImp().ChageCharMethod(ref resultData);
                   

                }
            }
            
        }


        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Atten();
        }
    }
}
