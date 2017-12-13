using System;
using System.Collections.Generic;
using System.Linq;

namespace DvorakTrainer.Entities
{
    public class KeyRandomizer
    {
        // this class contains all functionality related to extracting a unique (non-duplicated) random value from a user created list 
        

        private List<int> userSelectedKeyList = new List<int>(); // main list curated by user
        private int LastRandomKey = -1;                          // to track the last key served to prevent duplicates - preventDuplicats() below)

        public List<int> UserSelectedKeyList { get { return userSelectedKeyList; } } 
        public int CurrentRandomKey { get; set; }                                    // this is the key the user will see and try to press the right key       


        public KeyRandomizer()
        {//empty default constructor          
        }

        public KeyRandomizer(List<int> populateUserSelectedKeyList) 
        {// constructor that first clears then populates userSelectedKeyList

            userSelectedKeyList.Clear();
            userSelectedKeyList = populateUserSelectedKeyList;            
        }

        public void extractUserRandomKeyToMember(List<int> userList)
        {//for any list, get a non-duplicate number and extract it's element to be the CurrentRandomKey

            int nonDuplicateInt = preventDuplicates(userList);

            int selectedKeyFromUserList = userList.ElementAt(nonDuplicateInt);
        
            CurrentRandomKey = selectedKeyFromUserList;

        }

        public int preventDuplicates(List<int> list)
        {// for any list, get a random int and check it's element, if unique to proceding assign to LastRandomKey and return it's int
         // if not unique from preceding element, select a new one until unique

            int randomIntFromUserList = 0;
            int elementAtRandomIntFromUserList = 0;

            do                                 // ensures there are no duplicate numbers in a row
            {
                randomIntFromUserList = getRandomIntFromAnyList(list);  // get random int from list

                elementAtRandomIntFromUserList = list.ElementAt(randomIntFromUserList);  // extract element at the int


            } while (elementAtRandomIntFromUserList == LastRandomKey);       // if new element NOT unique from preceding element, select again

            LastRandomKey = elementAtRandomIntFromUserList;               // if element was unique, assign to LastRandomKey for future comparisons

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
