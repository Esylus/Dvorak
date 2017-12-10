using System;
using System.Collections.Generic;
using System.Linq;

namespace DvorakTrainer.Entities
{
    public class KeyRandomizer
    {
        // this class contains all functionality related to extracting a unique (non-duplicated) random value from a user created list 
        

        private List<int> userSelectedKeyList = new List<int>();
        private int LastRandomKey = -1;

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
        {//randomize user list, pick a number that is not a duplicate of the last number, extract key value from randomized number

            int nonDuplicateInt = preventDuplicates(userSelectedKeyList);

            int selectedKeyFromUserList = userSelectedKeyList.ElementAt(nonDuplicateInt);
        
            CurrentRandomKey = selectedKeyFromUserList;

        }

        public int preventDuplicates(List<int> list)
        {
            int randomIntFromUserList = 0;

            do                                 // ensures there are no duplicate numbers in a row
            {
                randomIntFromUserList = getRandomIntFromAnyList(list);

            } while (randomIntFromUserList == LastRandomKey);

            LastRandomKey = randomIntFromUserList;

            return randomIntFromUserList;
        }

        public int getRandomIntFromAnyList(List<int> rawList)
        {//take any list and get one random value from it

            Random random = new Random();
            int randomIntFromAnyList = random.Next(0, rawList.Count);

            return randomIntFromAnyList;
        }
    }
}
