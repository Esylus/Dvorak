using System.Collections.Generic;
using System.Linq;
using DvorakTrainer.Entities;
using NUnit.Framework;

namespace DvorakTrainer.Test
{
    [TestFixture]
    class KeyRandomizerTest
    {
        [Test]
        public void getRandomIntFromAnyList_IntegerList_ReturnPositiveInteger()
        {   // test Randomizer functionality, input numbers and return number in same range 
            // Arrange, Act, Assert

            List<int> testList = new List<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);
            testList.Add(5);
            testList.Add(6);
            testList.Add(7);

            int actual;

            KeyRandomizer testRandomizer = new KeyRandomizer();

            actual = testRandomizer.getRandomIntFromAnyList(testList);

            if ((actual >= 0) && (actual <= testList.Count()))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        


    }
}
