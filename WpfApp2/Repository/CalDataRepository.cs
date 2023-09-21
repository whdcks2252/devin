using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using WpfApp2.viewmodel;

namespace WpfApp2
{
    class CalDataRepository : ICalDataRepository
    {
        private IRepository _repository;
        private static CalDataRepository calDataRepository;
        private static List<Data> datasDTO = new List<Data>();

        private CalDataRepository(DataRepository dataRepository) { this._repository = dataRepository; }

        //객체 인스턴스
        public static CalDataRepository GetCalDataRepository()
        {
            if (calDataRepository == null)
            {
                calDataRepository = new CalDataRepository(DataRepository.GetDataRepository());
            }
            return calDataRepository;

        }

        public List<Data> GetDataDTO()
        {
            return _repository.GetDatasDTO();
        }

        public List<Data> SingAttenCal(int targetAtten)
        {
            datasDTO.Clear();

            List<Data> datas = _repository.GetDatasDTO();

            foreach (Data data in datas)
            {
                if (data.Attenuator == targetAtten)
                    datasDTO.Add(data);
            }

            return datasDTO;
        }
        public List<Data> DoubleAttenCal(int minAtten, int maxAtten)
        {
            datasDTO.Clear();

            List<Data> datas = _repository.GetDatasDTO();
            var filteredData = datas.Where(data => data.Attenuator >= minAtten && data.Attenuator <= maxAtten);
            double avgAtc = filteredData.Any() ? filteredData.Average(data => data.AttenAccuracy) : 0.0;

            foreach (Data data in datas)
            {
                // Atten 범위에 포함되는 경우에만 Atten Accuracy를 계산
                data.AttenAccuracy = (int)avgAtc;
                datasDTO.Add(data);
            }

            return datasDTO;    

        }

    }
}
