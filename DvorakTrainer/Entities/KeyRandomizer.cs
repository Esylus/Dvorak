using System;
using System.Collections.Generic;
using System.Linq;

namespace DvorakTrainer.Entities
{
    public class KeyRandomizer
    {
        // this class contains all functionality related to extracting a random value from a user created list 
        // this class will evenutally ensure that a number can not be selected twice in a row

        private List<int> userSelectedKeyList = new List<int>();

        public int CurrentRandomKey { get; set; }

        public KeyRandomizer()
        {//empty default constructor          
        }

        public KeyRandomizer(List<int> populateUserSelectedKeyList) 
        {// constructor that first clears then populates userSelectedKeyList

            userSelectedKeyList.Clear();
            userSelectedKeyList = populateUserSelectedKeyList;
        }

        public void extractUserRandomKeyToMember()
        {//randomize user list, extract key value from randomized number

            int randomIntFromUserList =  getRandomIntFromAnyList(userSelectedKeyList);

                int selectedKeyFromUserList = userSelectedKeyList.ElementAt(randomIntFromUserList);
              //  m_currentRandomKey = selectedKeyFromUserList;
            CurrentRandomKey = selectedKeyFromUserList;

        }

        public int getRandomIntFromAnyList(List<int> rawList)
        {//take any list and get one random value from it
         //add alogrithm to ensure two numbers in a row can not be selected 

            Random random = new Random();
            int randomIntFromAnyList = random.Next(0, rawList.Count);
            
            return randomIntFromAnyList;
        }
        
       

    }
}
