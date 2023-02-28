using CDBCalc_Domain.Entities;
using CDBCalc_Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDBCalc_Services.Services
{
    public class MethodServices : IMethodServices
    {
        public decimal CalculateNetValue(decimal presentValue, int period)
        {
            BasicParms parms = new BasicParms();

            if (!ValueGreaterThan0(presentValue))
            {
                return 0;
            }

            if (!PeriodLongerThan1(period))
            {
                return 0;
            }

            parms.PresentValue = presentValue;
            for (int i = 0; i < period; i++)
            {
                parms.FutureValue = CalculateFutureValue(parms);
                parms.PresentValue = parms.FutureValue;
            }

            parms.NetValue = Math.Round(parms.FutureValue - (parms.FutureValue * (CalculatePercTaxes(period))), 2);

            return parms.NetValue;
        }

        /// <summary>
        /// The presentValue needs to be greater than 0
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public decimal CalculateFutureValue(BasicParms parms)
        {
            decimal fv = 0;
            fv = parms.PresentValue * (1 + (parms.CDI * parms.TB));
            return Math.Round(fv,2);
        }

        /// <summary>
        /// The period needs to be greater than 1
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public decimal CalculatePercTaxes(int period)
        {
            if (period <= 6) { return 0.225M; }
            else if (period > 6 && period <= 12) { return 0.2M; }
            else if (period > 12 && period <= 24) { return 0.175M; }
            else { return 0.15M; }
        }

        /// <summary>
        /// The period needs to be greater than 1
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>

        public bool PeriodLongerThan1(int period)
        {
            return period > 1;
        }

        /// <summary>
        /// The presentValue needs to be greater than 0
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public bool ValueGreaterThan0(decimal value)
        {
            return value > 0;
        }
    }
}
