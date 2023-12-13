using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartViewer
{
    public  class Data
    {
        private Double frequency;
        private Double values;

        public Double Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }


        public Double Values
        {
            get { return values; }
            set { values = value; }
        }


        public float Header { get; set; }
        public float Version { get; set; }
        public ulong Freq { get; set; }
        //IQ_lmb
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int E { get; set; }
        public int F { get; set; }
        //pwrOffset
        public float Temperature { get; set; }
        public int PowerAccuracy { get; set; }
        //AttenOffset
        public int Attenuator { get; set; }
        public int AttenAccuracy { get; set; }
        
    }
}
