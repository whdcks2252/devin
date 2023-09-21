using Microsoft.Win32;
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
using WpfApp2.util;
using System.Windows.Shapes;
using WpfApp2.Commands.MainSave;
using WpfApp2.view;
using System.Windows.Media;

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
            OpenFileMenager openFileMenager = new OpenFileMenager();
            openFileDialog.Filter = "TEXT files (*.txt)|*.txt|CAL files (*.cal)|*.cal|TEXT,CAL(*.txt,*.cal)|*.txt;*.cal";
            try{
                if (openFileDialog.ShowDialog() == true)
                {

                    string[] source = openFileDialog.FileNames[0].Split('\\');
                    string fileName = source[source.Length - 1];


                    if (fileName.Contains(".cal"))
                    {
                        openFileMenager.CalOpen(ref openFileDialog, ref _dataRepository);
                        
                    }
                    else
                    {
                        openFileMenager.TextOpen(ref openFileDialog, ref _dataRepository);
                    }

                    //Block에 파일 경로 표시
                    ChageBlock(ref fileName);
                    //y축 라벨 변경
                    changeYLabel(ref fileName);
                    //프레임 변경
                    ChangeFrameAndVisibleButton(ref mainViewModel, ref fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일을 읽는 중 오류 발생");
                Console.WriteLine("파일 로딩중 오류발생 :",ex.Message);
            }
        }
        private void ChangeFrameAndVisibleButton(ref MainViewModel mainViewModel,ref string fileName)
        {
            if (fileName.Contains(CalFileNameEnum.IQ_Imb.ToString()))
            {
                mainViewModel.Fr1Content = null;
                mainViewModel.Fr2Content = LoadedIQ_ImbPage.GetLoadedIQ_ImbPage();
                mainViewModel.PageSearchPageBtVis = Visibility.Hidden;
                mainViewModel.FreSearchPageBtVis = Visibility.Hidden;

            }
            else if (fileName.Contains(CalFileNameEnum.Atten.ToString()))
            {
                mainViewModel.Fr1Content = null;
                mainViewModel.Fr2Content = LoadedAtten.GetLoadedAtten();
                mainViewModel.PageSearchPageBtVis = Visibility.Hidden;
                mainViewModel.FreSearchPageBtVis = Visibility.Hidden;
            }
            else 
            {
                mainViewModel.Fr1Content = null;
                mainViewModel.Fr2Content = null;
                mainViewModel.FreSearchPageBtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                mainViewModel.FreSearchPageBtFG = Brushes.Black;
                mainViewModel.PageSearchPageBtBG = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                mainViewModel.PageSearchPageBtFG = Brushes.Black;
                mainViewModel.PageSearchPageBtVis = Visibility.Visible;
                mainViewModel.FreSearchPageBtVis = Visibility.Visible;
            }
        }

        //Bock에 파일 경로 표시 바인딩
        private void ChageBlock(ref string fileName)
        {
            mainViewModel.TxtBlock = fileName;

        }

        //Y축 라벨 변경
        private void changeYLabel(ref string fileName)
        {

            if (fileName.Contains(CalFileNameEnum.PwrOffset.ToString()))
            {
                mainViewModel.YLable = "PowerAccuracy";
            }
            else if (fileName.Contains(CalFileNameEnum.Atten.ToString()))
            {
                mainViewModel.YLable = "Atten Accuracy";
            }
            else
                mainViewModel.YLable = "value";


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
