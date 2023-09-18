﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public interface IRepository
    {
         void SaveDataBox(ref List<Data> data);
        List<List<Data>> GetDataBox();
        void ClearDatas();

    }
}