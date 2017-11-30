using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvorakTrainer
{
    public class KeyRandomizer
    {

        // this class will randomize the master list to return a single key
        // this class will ensure that a number can not be selected twice in a row

        private List<int> userSelectedKeyList = new List<int>();

        private int m_currentRandomKey;

        public int CurrentRandomKey
        {//private field getter setter
            get { return this.m_currentRandomKey; }
            set { this.m_currentRandomKey = value; }
        }

        public KeyRandomizer(List<int> populateUserSelectedKeyList) 
        {// default constructor that first clears then populates userSecectedKeyList

            userSelectedKeyList.Clear();
            userSelectedKeyList = populateUserSelectedKeyList;
        }

        public void extractUserRandomKeyToMember()
        {//randomize user list, extract value from randomized number

            int randomIntFromUserList =  getRandomIntFromAnyList(userSelectedKeyList);

            int selectedKeyFromUserList = userSelectedKeyList.ElementAt(randomIntFromUserList);

            m_currentRandomKey = selectedKeyFromUserList;         

        }

        public static int getRandomIntFromAnyList(List<int> rawList)
        {      
            Random random = new Random();
            int randomIntFromAnyList = random.Next(0, rawList.Count);
            
            return randomIntFromAnyList;
        }

    }
}
