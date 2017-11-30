using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DvorakTrainer.Test
{
    [TestFixture]
    class StatisticsTest
    {
        [Test]
        public void calculatorScore_PositiveDecimals_ReturnPositiveDecimal()
        {//Arrange, Act, Assert 

            decimal total = 10.0m;
            decimal correct = 4.0m;
            decimal expected = 0.4m;
            decimal actual;

            Statistics testStatistics = new Statistics();

            actual = testStatistics.calculateScore(correct, total);

            Assert.AreEqual(expected, actual);
        }



}
}
