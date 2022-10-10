using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherYates
{
    public class Shuffle
    {
        public List<int> ShuffleList(List<int> Original)
        {
            List<int> New = Original;

            for (int i = New.Count - 1; i >= 0; i--)
            {
                int j = GetRandomNumber(i);
                int temporary = New[j];
                New[j] = Original[i];
                New[i] = temporary;
            }

            return New;
        }

        int GetRandomNumber(int i)
        {
            Random rand = new Random();
            return rand.Next(i + 1);
        }
    }
}
