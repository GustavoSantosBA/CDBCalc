using CDBCalc_Domain.Entities;
using CDBCalc_Domain.Interfaces.Services;
using CDBCalc_Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CDBCalc_UnitTest
{
    [TestClass]
    public class BasicTests
    {
        private IServiceScopeFactory _serviceScopeFactory;
        private IMethodServices _methodServices;

        [TestInitialize]

        public void TestInitialize()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IMethodServices, MethodServices>();
            _serviceScopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                _methodServices = scope.ServiceProvider.GetService<IMethodServices>();
            }
        }

        [TestMethod]
        public void TestCalculateNetValueWithValidInputs()
        {
            decimal presentValue = 100;
            int period = 2;
            decimal expectedValue = 79.01M;

            decimal netValueFound = _methodServices.CalculateNetValue(presentValue, period);

            Assert.AreEqual(expectedValue, netValueFound);

        }

        [TestMethod]
        public void TestCalculateNetValueWithZeroPresentValue()
        {
            decimal presentValue = 0;
            int period = 2;
            decimal expectedValue = 0;

            decimal netValueFound = _methodServices.CalculateNetValue(presentValue, period);

            Assert.AreEqual(expectedValue, netValueFound);

        }

        [TestMethod]
        public void TestCalculateNetValueWithNegativePresentValue()
        {
            decimal presentValue = -1000;
            int period = 2;
            decimal expectedValue = 0;

            decimal netValueFound = _methodServices.CalculateNetValue(presentValue, period);

            Assert.AreEqual(expectedValue, netValueFound);
        }

        [TestMethod]
        public void TestCalculateNetValueWithPeriodLessThan2()
        {
            decimal presentValue = 100;
            int period = 1;
            decimal expectedValue = 0;

            decimal netValueFound = _methodServices.CalculateNetValue(presentValue, period);

            Assert.AreEqual(expectedValue, netValueFound);
        }

        [TestMethod]
        public void TestCalculateFutureValue()
        {
            BasicParms parms = new BasicParms { PresentValue = 100 };

            decimal expectedValue = 100.97M;

            decimal result = _methodServices.CalculateFutureValue(parms);

            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]

        public void TestCalculatePercTaxes()
        {
            int[] period = new int[] { 3, 8, 15, 30 };
            decimal[] expectedValues = new decimal[] { 0.225M, 0.2M, 0.175M, 0.15M };

            Assert.AreEqual(expectedValues[0], _methodServices.CalculatePercTaxes(period[0]));
            Assert.AreEqual(expectedValues[1], _methodServices.CalculatePercTaxes(period[1]));
            Assert.AreEqual(expectedValues[2], _methodServices.CalculatePercTaxes(period[2]));
            Assert.AreEqual(expectedValues[3], _methodServices.CalculatePercTaxes(period[3]));

        }

        [TestMethod]
        [DataRow(5)]
        [DataRow(2)]
        [DataRow(10)]
        public void TestPeriodLongerThan1(int period)
        {
            Assert.IsTrue(_methodServices.PeriodLongerThan1(period));
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(-5)]
        public void TestPeriodLessThan1(int period)
        {
            Assert.IsFalse(_methodServices.PeriodLongerThan1(period));
        }

        [TestMethod]
        public void TestValueGreaterThan0()
        {
            decimal value1 = 0;
            decimal value2 = 10;
            decimal value3 = -5;
            decimal value4 = 0.01M;

            bool result1 = _methodServices.ValueGreaterThan0(value1);
            bool result2 = _methodServices.ValueGreaterThan0(value2);
            bool result3 = _methodServices.ValueGreaterThan0(value3);
            bool result4 = _methodServices.ValueGreaterThan0(value4);

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
            Assert.IsTrue(result4);
        }
    }
}
