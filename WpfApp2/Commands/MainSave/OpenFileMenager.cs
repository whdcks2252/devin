using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.util;
using WpfApp2.viewmodel;

namespace WpfApp2.Commands.MainSave
{
     class OpenFileMenager
    {
        //텍스트 파일 오픈
        public  void TextOpen(ref OpenFileDialog openFileDialog,ref IRepository _dataRepository)
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

                    if (textVale.Count > 0)
                    {
                        _dataRepository.ClearDatas();
                        //데이터파일생성
                        for (int i = 0; i < textVale.Count; i++)
                        {
                            if (!CheckFileForm(textVale[i], ref splitData))
                                return;

                            // 데이터 생성 후 저장소에 저장
                            CreateData(ref splitData,ref _dataRepository);

                            //Console.WriteLine("TextFile" + (i + 1).ToString() + "번째 줄.");
                            //Console.WriteLine(_dataRepository.GetDatas()[i].Frequency + " " + _dataRepository.GetDatas()[i].Values);
                        }

                        List<Data> datas = _dataRepository.GetDatas();
                    //차트 변경
                    PlotModelImp.GetPlotModelImp().ChageCharMethod(ref datas);
                    }
            }
        }

        //.cal 파일 오픈
        public void CalOpen(ref OpenFileDialog openFileDialog,ref IRepository _dataRepository)
        {
                string fileName = Path.GetFileName(openFileDialog.FileName);
            
                if (fileName.Contains(CalFileNameEnum.IQ_Imb.ToString()))
                {
                    FileNameIsIQ(ref openFileDialog, ref _dataRepository);
                }
                else if (fileName.Contains(CalFileNameEnum.PwrOffset.ToString()))
                {
                    FileNameIsPwr(ref openFileDialog, ref _dataRepository);
                }
                else if (fileName.Contains(CalFileNameEnum.Atten.ToString()))
                {
                    FileNameIsAtt(ref openFileDialog, ref _dataRepository);
                }
                else
                    GlobalCalFile(ref openFileDialog, ref _dataRepository);

        }

        //IQ_Imb 포함 파일
        private  void FileNameIsIQ(ref OpenFileDialog openFileDialog, ref IRepository _dataRepository)
        {
            List<Data> datas = _dataRepository.GetDatas();
            datas.Clear();

            using (FileStream fs = new FileStream(openFileDialog.FileName,
                FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096))
            {
                Console.WriteLine("=======Read File :: " + System.IO.Path.GetFileName(openFileDialog.FileName));
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int i = 0;

                    float Header = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    float version = BitConverter.ToSingle(reader.ReadBytes(4), 0);

                    Console.WriteLine("=======Heder : " + Header + " Version : " + version);

                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        ulong Freq = reader.ReadUInt64();
                        int A = reader.ReadInt32();
                        int B = reader.ReadInt32();
                        int C = reader.ReadInt32();
                        int D = reader.ReadInt32();
                        int E = reader.ReadInt32();
                        int F = reader.ReadInt32();


                        datas.Add(new Data()
                        {
                            Header = Header,
                            Version = version,
                            Freq = Freq/1000000,
                            A = A,
                            B = B,
                            C = C,
                            D = D,
                            E = E,
                            F = F,
                        });
                        
                    }

                    PlotModelImp.GetPlotModelImp().ClearChartMethod();//데이터 변경시 차트 초기화
                }

            }
        }

        //PwrOffset 포함 파일
        private  void FileNameIsPwr(ref OpenFileDialog openFileDialog, ref IRepository _dataRepository)
        {
            List<Data> datas = _dataRepository.GetDatas();
            datas.Clear();

            using (FileStream fs = new FileStream(openFileDialog.FileName,
                FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096))
            {
                Console.WriteLine("=======Read File :: " + System.IO.Path.GetFileName(openFileDialog.FileName));
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int i = 0;

                    float Header = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    float version = BitConverter.ToSingle(reader.ReadBytes(4), 0);

                    Console.WriteLine("=======Heder : " + Header + " Version : " + version);

                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        ulong Freq = reader.ReadUInt64();
                        float temperature = reader.ReadSingle();
                        int powerAccuracy = reader.ReadInt32();

                        datas.Add(new Data()
                        {
                            Header = Header,
                            Version = version,
                            Freq = Freq/1000000,
                            Temperature = temperature,
                            PowerAccuracy = powerAccuracy
                        });
         
                    }
                }
            }

            ChangeData.ConverterData(ref _dataRepository, Path.GetFileName(openFileDialog.FileName));//데이터 변환 Frequency와 value를 사용하기 위함 SeacchPageFre  사용하기 위함
            PlotModelImp.GetPlotModelImp().ChageCharMethod(ref datas);


        }
        //Atten 포함 파일
        private void FileNameIsAtt(ref OpenFileDialog openFileDialog, ref IRepository _dataRepository)
        {
            List<Data> datas = _dataRepository.GetDatas();
            datas.Clear();

            using (FileStream fs = new FileStream(openFileDialog.FileName,
                FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096))
            {
                Console.WriteLine("=======Read File :: " + System.IO.Path.GetFileName(openFileDialog.FileName));
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int i = 0;

                    float Header = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    float version = BitConverter.ToSingle(reader.ReadBytes(4), 0);

                    Console.WriteLine("=======Heder : " + Header + " Version : " + version);

                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        ulong Freq = reader.ReadUInt64();
                        int attenuator = reader.ReadInt32();
                        int attenAccuracy = reader.ReadInt32();

                        datas.Add(new Data()
                        {
                            Header = Header,
                            Version = version,
                            Freq = Freq / 1000000,
                            Attenuator = attenuator,
                            AttenAccuracy = attenAccuracy
                        });
                    }
                    PlotModelImp.GetPlotModelImp().ClearChartMethod(); //데이터 변경시 차트 초기화

                }
            }
        }

        //Global.Cal 파일
        private void GlobalCalFile(ref OpenFileDialog openFileDialog, ref IRepository _dataRepository)
        {
            List<Data> datas = _dataRepository.GetDatas();
            datas.Clear();

            using (FileStream fs = new FileStream(openFileDialog.FileName,
                FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096))
            {
                Console.WriteLine("=======Read File :: " + System.IO.Path.GetFileName(openFileDialog.FileName));
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    //카운트
                    int i = 0;

                    float Header = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    float version = BitConverter.ToSingle(reader.ReadBytes(4), 0);

                    Console.WriteLine("=======Heder : " + Header + " Version : " + version);

                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        ulong Freq = reader.ReadUInt64();
                        byte[] B = reader.ReadBytes(4); // offset

                        float value = BitConverter.ToSingle(B, 0);

                        datas.Add(new Data()
                        {
                            Header = Header,
                            Version = version,
                            Frequency = Freq / 1000000,
                            Values = value,
                           
                        });
                    }
                }
            }

            PlotModelImp.GetPlotModelImp().ChageCharMethod(ref datas);
            ChangeData.ConverterData(ref _dataRepository, Path.GetFileName(openFileDialog.FileName));//데이터 변환 Frequency와 value를 사용하기 위함

        }

        // 데이터 생성 후 저장소에 저장
        private  void CreateData(ref string[] splitData, ref IRepository _dataRepository)
        {
            //데이터 키:쌍 값으로 생성
            Data data = new Data()
            {
                Frequency = (Double.Parse(splitData[0])),
                Values = (Double.Parse(splitData[1]))
            };

            _dataRepository.GetDatas().Add(data);
        }

        //Delimiter 검증 함수
        private  bool CheckFileForm(string str, ref string[] splitData)
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
            catch (Exception ex) { MessageBox.Show("잘못된 형식의 파일 입니다"); }
            return false;
        }

    }
}
