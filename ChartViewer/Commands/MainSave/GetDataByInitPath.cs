using ChartViewer.view;
using ChartViewer.viewmodel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Runtime.InteropServices;

namespace ChartViewer.Commands.MainSave
{
    public class GetDataByInitPath 
    {

        private MainViewModel mainViewModel;
        private IRepository _dataRepository;
        public GetDataByInitPath (MainViewModel mainViewModel, IRepository _dataRepository)
        {
            this.mainViewModel = mainViewModel;
            this._dataRepository = _dataRepository;
        }

        #region ini 입력 메소드
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion


        //ini파일 데이터 불러오기 
        private string MqttInitData()
        {
            StringBuilder path = new StringBuilder(128);
            int bytesRead = GetPrivateProfileString("Path", "path", "", path, 128, Environment.CurrentDirectory + @"\CalFileWriter\ChartViewer\init.ini");

            string initpath= path.ToString(0, bytesRead-4);
            return initpath;
        }


        public void save()
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            OpenFileMenager openFileMenager = new OpenFileMenager();
           // openFileDialog.Filter = "TEXT files (*.txt)|*.txt|CAL files (*.cal)|*.cal|TEXT,CAL(*.txt,*.cal)|*.txt;*.cal";
            try
            {
                //if (openFileDialog.ShowDialog() == true)
                {

                    string filePath = MqttInitData();
                    string[] source = filePath.Split('\\');
                    string fileName = source[source.Length - 1];


                    if (fileName.Contains(".cal"))
                    {
                        openFileMenager.CalOpen(ref filePath, ref _dataRepository);
                        CalViewModel.ClearProp();
                    }
                    else
                    {
                        openFileMenager.TextOpen(ref filePath, ref _dataRepository);
                    }
                    //속성값 초기화
                    mainViewModel.ClearProp();

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
                Console.WriteLine("파일 로딩중 오류발생 :", ex.Message);
            }
        }
        private void ChangeFrameAndVisibleButton(ref MainViewModel mainViewModel, ref string fileName)
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
                mainViewModel.FreSearchPageBtBG = Brushes.White;
                mainViewModel.FreSearchPageBtFG = Brushes.Black;
                mainViewModel.PageSearchPageBtBG = Brushes.White;
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

 
    }
}
