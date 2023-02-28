using CDBCalc_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDBCalc_Domain.Interfaces.Services
{
    public interface IMethodServices
    {
        bool ValueGreaterThan0(decimal value);
        bool PeriodLongerThan1(int month);
        decimal CalculateFutureValue(BasicParms parms);
        decimal CalculatePercTaxes(int period);
        decimal CalculateNetValue(decimal presentValue, int period);

    }
}
