using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvorakTrainer.Entities;
using NUnit.Framework;

namespace DvorakTrainer.Test
{
    [TestFixture]
    class FocusTest
    {// This test enters test results, processes them in the Focus class then compares the results (in a dictionary) to the prebuilt answer dictionary 

        [Test]
        public void sortList_intoNewList_returnDictionary()
        {//Arrange Act Assert

            Dictionary<int, int> answerDictionary = new Dictionary<int, int>();
            answerDictionary.Add(4, 5);
            answerDictionary.Add(5, 10);
            answerDictionary.Add(6, 15);
            answerDictionary.Add(7, 20);


            Dictionary<int, int> testDictionary = new Dictionary<int, int>();

            Focus testFocus = new Focus();

            testFocus.recordUserResults(4, 1);
            testFocus.recordUserResults(5, 1);
            testFocus.recordUserResults(6, 1);
            testFocus.recordUserResults(7, 1);

            testFocus.recordUserResults(4, 1);
            testFocus.recordUserResults(5, 1);
            testFocus.recordUserResults(6, 1);
            testFocus.recordUserResults(7, 1);

            testFocus.recordUserResults(4, 1);
            testFocus.recordUserResults(5, 1);
            testFocus.recordUserResults(6, 1);
            testFocus.recordUserResults(7, 0);

            testFocus.recordUserResults(4, 1);
            testFocus.recordUserResults(5, 1);
            testFocus.recordUserResults(6, 0);
            testFocus.recordUserResults(7, 0);

            testFocus.recordUserResults(4, 1);
            testFocus.recordUserResults(5, 0);
            testFocus.recordUserResults(6, 0);
            testFocus.recordUserResults(7, 0);

            testFocus.createFocusList();

            var g = testFocus.FocusList.GroupBy(i => i);

            foreach (var grp in g)
            {
                testDictionary.Add(grp.Key, grp.Count());
            }

            if (testDictionary.SequenceEqual(answerDictionary))
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
