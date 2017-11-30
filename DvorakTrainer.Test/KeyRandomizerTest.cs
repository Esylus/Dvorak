﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DvorakTrainer.Test
{
    [TestFixture]
    class KeyRandomizerTest
    {




        [Test]
        public void Randomize_IntegerList_ReturnPositiveInteger()
        {  // Arrange, Act, Assert

            List<int> testList = new List<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);
            testList.Add(5);
            testList.Add(6);
            testList.Add(7);

            int actual;

            actual = DvorakTrainer.KeyRandomizer.getRandomIntFromAnyList(testList);

            if ((actual > 0) && (actual < testList.Count()))
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
