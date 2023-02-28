using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDBCalc_Domain.Entities
{
    public class BasicParms
    {
        public decimal FutureValue { get; set; }
        public decimal PresentValue { get; set; }
        public decimal NetValue { get; set; }
        public decimal CDI { get { return 0.009M; } }
        public decimal TB { get { return 1.08M; } }
        public int Period { get; set; }
    }
}
