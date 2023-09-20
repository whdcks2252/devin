using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.util
{
     class ChangeData
    {

        public static void ConverterData(ref IRepository repository,string fileName) {

            List<Data> datas=repository.GetDatas();

            if (fileName.Contains(CalFileNameEnum.IQ_Imb.ToString()))
            {
                tempIQ_Imb(ref datas);
            }
            else if (fileName.Contains(CalFileNameEnum.PwrOffset.ToString()))
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
        private static void tempIQ_Imb(ref List<Data> datas)
        {

        }
        private static void tempPwrOffset(ref List<Data> datas)
        {
            for(int i=0; i < datas.Count; i++)
            {
                datas[i].Frequency = datas[i].Freq;
                datas[i].Values = datas[i].PowerAccuracy;
            }
        }
        private static  void tempAtten(ref List<Data> datas)
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
