using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartViewer.util
{
     class ChangeData
    {

        public static void ConverterData(ref IRepository repository, string fileName)
        {

            List<Data> datas = repository.GetDatas();

            if (fileName.Contains(CalFileNameEnum.PwrOffset.ToString()))
            {
                tempPwrOffset(ref datas);
            }
            else if (fileName.Contains(CalFileNameEnum.Atten.ToString()))
            {
                tempAtten(ref datas);
            }
            else
            {
                tempGrobal(ref datas);
            }


        }
        public static List<Data> ConverterIQ(ref ICalDataRepository _calDataRepository,string IQ_Button)
        {
            List<Data>datas=_calDataRepository.GetDataDTO();

            if (IQ_Button == IQ_ButtonEnum.A.ToString())
            {
                foreach(Data data in datas)
                {
                    data.Frequency = data.Freq;
                    data.Values = data.A;
                }
            }
            if (IQ_Button == IQ_ButtonEnum.B.ToString())
            {
                foreach (Data data in datas)
                {
                    data.Frequency = data.Freq;
                    data.Values = data.B;
                }
            }
            if (IQ_Button == IQ_ButtonEnum.C.ToString())
            {
                foreach (Data data in datas)
                {
                    data.Frequency = data.Freq;
                    data.Values = data.C;
                }
            }
            if (IQ_Button == IQ_ButtonEnum.D.ToString())
            {
                foreach (Data data in datas)
                {
                    data.Frequency = data.Freq;
                    data.Values = data.D;
                }
            }
            if (IQ_Button == IQ_ButtonEnum.E.ToString())
            {
                foreach (Data data in datas)
                {
                    data.Frequency = data.Freq;
                    data.Values = data.E;
                }
            }
            if (IQ_Button == IQ_ButtonEnum.F.ToString())
            {
                foreach (Data data in datas)
                {
                    data.Frequency = data.Freq;
                    data.Values = data.F;
                }
            }
            return datas;

        }

        private static void tempPwrOffset(ref List<Data> datas)
        {
            for(int i=0; i < datas.Count; i++)
            {
                datas[i].Frequency = datas[i].Freq;
                datas[i].Values = datas[i].PowerAccuracy;
            }
        }
        public static  void tempAtten(ref List<Data> datas)
        {
            for (int i = 0; i < datas.Count; i++)
            {
                datas[i].Frequency = datas[i].Freq;
                datas[i].Values = datas[i].AttenAccuracy;
            }
        }
        private static void tempGrobal(ref List<Data> datas)
        {
            for (int i = 0; i < datas.Count; i++)
            {
                datas[i].Frequency = datas[i].Freq;
            }
        }
       
    }
}
