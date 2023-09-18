using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    public class DataRepository :IRepository
    {   
        // 싱글톤 적용
        private static  DataRepository dataRepository;
        private static List<List<Data>> dataBox = new List<List<Data>>();

        //객체 인스턴스
        public static DataRepository GetDataRepository() {

            if (dataRepository == null)
            {
                dataRepository = new DataRepository();
            }    
            return dataRepository;
        
        }
       

        //데이터 저장소에 데이터 저장
        public void SaveDataBox(ref List<Data> datas)
        {   
            dataBox.Add(datas);
        }

        public List<List<Data>> GetDataBox()
        {
            return dataBox;
        }

        public void ClearDatas()
        {
            dataBox.Clear();
        }

       
    }
}
