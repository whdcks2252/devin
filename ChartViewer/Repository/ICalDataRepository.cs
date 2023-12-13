using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartViewer
{
    public interface ICalDataRepository
    {
        List<Data> GetDataDTO();
        List<Data> SingAttenCal(int targetAtten);
        List<Data> DoubleAttenCal(int minAtten, int maxAtten);

    }
}
