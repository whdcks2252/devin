using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartViewer
{
    public interface IRepository
    {
         void SaveDataBox(ref List<Data> data);
        List<List<Data>> GetDataBox();
        void ClearDataBox();

        void SaveDatas(ref Data data);

        List<Data> GetDatas();

        void ClearDatas();

        //DTO데이터 데이터 영속성
         List<Data> GetDatasDTO();

    }
}
