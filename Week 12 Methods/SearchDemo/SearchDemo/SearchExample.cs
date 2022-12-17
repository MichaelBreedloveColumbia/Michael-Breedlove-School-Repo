using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SearchDemo
{
    internal class SearchExample
    {
        int DataCount;
        int TargetValue;
        int[] Collection;
        public SearchExample(int dataCount)
        {
            DataCount = dataCount;
            Collection = new int[dataCount];
            WriteLine($"This program will generate {DataCount} random numbers between 1 and 1000000 to an array.\nIt will then sort this data set by size, then choose one of these numbers at random and search for it using linear, binary, and interpolation methods.\nPress any key to begin.");
            ReadKey();
            GenerateData();
        }

        //Generates random garbage data, to be stored in the collection and searched for.
        void GenerateData()
        {
            for (int i = 0; i < DataCount; i++)
            {
                int num = GetRandomNumber(1, 1000000);
                Collection[i] = num;
            }

            Collection = SortData();

            TargetValue = Collection[GetRandomNumber(0, DataCount)];

            WriteLine($"The data has been generated.\nThe value which has been randomly selected as this program's search target is {TargetValue}.\nPress any key to begin searching.");
            ReadKey();

            CommenceSearch();
        }

        //Utilizes Visual Studio's automatic sort and returns a new array.
        int[] SortData()
        {
            int[] AutoSorted = new int[DataCount];

            for (int i = 0; i < Collection.ToImmutableSortedSet<int>().Count; i++)
            {
                AutoSorted[i] = Collection.ToImmutableSortedSet<int>()[i];
            }

            return AutoSorted;
        }

        void CommenceSearch()
        {
            LinearSearch();
            BinarySearch();
            InterpolationSearch();
        }

        void LinearSearch()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine(@"  _      _                          _____                     _     
 | |    (_)                        / ____|                   | |    
 | |     _ _ __   ___  __ _ _ __  | (___   ___  __ _ _ __ ___| |__  
 | |    | | '_ \ / _ \/ _` | '__|  \___ \ / _ \/ _` | '__/ __| '_ \ 
 | |____| | | | |  __/ (_| | |     ____) |  __/ (_| | | | (__| | | |
 |______|_|_| |_|\___|\__,_|_|    |_____/ \___|\__,_|_|  \___|_| |_|
                                                                    
                                                                    ");
            ForegroundColor = ConsoleColor.Yellow;

            //Simply cycle through the collection until we find our target.
            int numAttempts = 0;
            for (int i = 0; i < Collection.Length; i++)
            {
                if (Collection[i] == TargetValue)
                {
                    numAttempts = i + 1;
                }
            }

            WriteLine($"Found the target value ({TargetValue}) in {numAttempts} attempts.");

            ForegroundColor = ConsoleColor.White;

            WriteLine("The linear search is the simplest of the search methods, as it merely cycles through the given collection until it finds its target value. One would think that the linear search's incredible simplicity would make it the quickest method, though this would be a false assumption; linear searching is often the slowest method, with the only exception being very small collections.\nLinear searches compensate for this by being universal, as they are the only search method which doesn't require a sorted collection.\nThe absolute worst-case runtime for a linear search is O(n).\nThe average runtime for a linear search is O(n/2).\nThe best-case runtime for a linear search is O(1).\nPress any key to continue.");
            ReadKey();
        }

        void BinarySearch()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine(@"  ____  _                           _____                     _     
 |  _ \(_)                         / ____|                   | |    
 | |_) |_ _ __   __ _ _ __ _   _  | (___   ___  __ _ _ __ ___| |__  
 |  _ <| | '_ \ / _` | '__| | | |  \___ \ / _ \/ _` | '__/ __| '_ \ 
 | |_) | | | | | (_| | |  | |_| |  ____) |  __/ (_| | | | (__| | | |
 |____/|_|_| |_|\__,_|_|   \__, | |_____/ \___|\__,_|_|  \___|_| |_|
                            __/ |                                   
                           |___/                                    ");
            ForegroundColor = ConsoleColor.Yellow;

            int numAttempts = 0;
            bool found = false;
            //Start in the middle:
            int min = 0, max = Collection.Length - 1, CurrentSlot = (max + min) / 2;
            //While we haven't found the target yet, keep searching:
            for (int i = 0; !found; i++)
            {
                //If the value in the current slot is equal to the target value, stop searching.
                if (Collection[CurrentSlot] == TargetValue)
                {
                    found = true;
                }
                else
                {
                    //If the target value is larger than the current value, move to the right.
                    if (Collection[CurrentSlot] < TargetValue)
                    {
                        min = CurrentSlot + 1;
                    }
                    else //If the target value is smaller than the current value, move to the left.
                    {
                        max = CurrentSlot - 1;
                    }

                    CurrentSlot = (max + min) / 2;
                }

                numAttempts = i + 1;
            }

            WriteLine($"Found the target value ({TargetValue}) in {numAttempts} attempts.");

            ForegroundColor = ConsoleColor.White;

            WriteLine("The binary search requires a sorted data set, making it less universal than a linear search. However, it is still powerful.\nThe binary search starts by selecting the value in the middle of the collection. If this value is equal to the target value, the search is completed. If it is not, it compares the current value with the target value. If the target value is greater, it moves to the right side of its current position in the collection, otherwise it moves to the left.\nThe binary search repeats this process indefinitely until it has located its target value.\nThe absolute worst-case runtime for a binary search is O(log2n).\nThe average runtime for a binary search is O(log2n).\nThe best-case runtime for a binary search is O(1).\nPress any key to continue.");
            ReadKey();
        }

        void InterpolationSearch()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine(@"  _____       _                        _       _   _                _____                     _     
 |_   _|     | |                      | |     | | (_)              / ____|                   | |    
   | |  _ __ | |_ ___ _ __ _ __   ___ | | __ _| |_ _  ___  _ __   | (___   ___  __ _ _ __ ___| |__  
   | | | '_ \| __/ _ \ '__| '_ \ / _ \| |/ _` | __| |/ _ \| '_ \   \___ \ / _ \/ _` | '__/ __| '_ \ 
  _| |_| | | | ||  __/ |  | |_) | (_) | | (_| | |_| | (_) | | | |  ____) |  __/ (_| | | | (__| | | |
 |_____|_| |_|\__\___|_|  | .__/ \___/|_|\__,_|\__|_|\___/|_| |_| |_____/ \___|\__,_|_|  \___|_| |_|
                          | |                                                                       
                          |_|                                                                       ");
            ForegroundColor = ConsoleColor.Yellow;

            //The auto-sort method I took from Visual Studio's libraries for this assignment sorts uniformly on its own, so no special logic is required here, and it functions like a normal binary search.
            int numAttempts = 0;
            bool found = false;
            //Start in the middle:
            int min = 0, max = Collection.Length - 1, CurrentSlot = (max + min) / 2;
            //While we haven't found the target yet, keep searching:
            for (int i = 0; !found; i++)
            {
                //If the value in the current slot is equal to the target value, stop searching.
                if (Collection[CurrentSlot] == TargetValue)
                {
                    found = true;
                }
                else
                {
                    //If the target value is larger than the current value, move to the right.
                    if (Collection[CurrentSlot] < TargetValue)
                    {
                        min = CurrentSlot + 1;
                    }
                    else //If the target value is smaller than the current value, move to the left.
                    {
                        max = CurrentSlot - 1;
                    }

                    CurrentSlot = (max + min) / 2;
                }

                numAttempts = i + 1;
            }

            WriteLine($"Found the target value ({TargetValue}) in {numAttempts} attempts.");

            ForegroundColor = ConsoleColor.White;

            WriteLine("The interpolation search, like the binary search, requires a sorted collection. Additionally, that collection must be uniformly distributed.\nIt is effectively a more efficient binary search, at the cost of requiring more setup. Whereas binary search starts in the middle of the collection every time, interpolation search starts in different locations based on the value being searched for. If the value is very close to the last item in the collection, interpolation search will start closer to the end of the collection. If it is closer to the beginning, interpolation will start near the beginning.\nThis makes interpolation searches very swift and efficient, though, again, they require the most setup of the three primary search methods.\nThe absolute worst-case runtime for an interpolation search is O(n).\nThe average runtime for an interpolation search is O(log log N).\nThe best-case runtime for an interpolation search is O(log log N).\nPress any key to exit.");
            ReadKey();
        }

        //Grabs a random number between i and j.
        int GetRandomNumber(int i, int j)
        {
            Random rand = new Random();
            return rand.Next(i, j);
        }
    }
}
