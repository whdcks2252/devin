using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class OverPageEx : Exception
    {
        public OverPageEx()
        {
        }

        public OverPageEx(string message)
            : base(message)
        {
        }

        public OverPageEx(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
