using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherYates
{
    public class Shuffle
    {
        //Applies a Fisher-Yates shuffle to a given list of integers.
        public List<int> ShuffleList(List<int> Original)
        {
            //Create a copy of the original list.
            List<int> New = Original;

            //Cycle backwards through the copy.
            for (int i = New.Count - 1; i >= 0; i--)
            {
                //Grab a random number, up to i, to retrieve a position in the list which is earlier than i.
                int j = GetRandomNumber(i);
                
                //Temporarily store the value contained in our randomly chosen slot.
                int temporary = New[j];
                
                //Swap the positions of our values.
                New[j] = Original[i];
                New[i] = temporary;
            }

            //Return our copy, which should now be Fisher-Yates shuffled.
            return New;
        }

        //Retrieves a random number, with a limit of i + 1.
        int GetRandomNumber(int i)
        {
            Random rand = new Random();
            return rand.Next(i + 1);
        }
    }
}
