using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DataStructures
{
    public class DataExample
    {
        int DataCount;

        int[] ArrayExample;
        Stack<int> StackExample = new Stack<int>();
        Queue<int> QueueExample = new Queue<int>();
        Dictionary<int, int> DictionaryExample = new Dictionary<int, int>();

        public DataExample(int dataCount)
        {
            DataCount = dataCount;
            ArrayExample = new int[dataCount];
            WriteLine($"This program will generate {DataCount} random numbers between 1 and 1000000 to an array, a stack, a queue, and a dictionary.\nIt will then print the data stored in these collections to the console.\nPress any key to begin.");
            ReadKey();
        }

        public void GenerateData()
        {
            for (int i = 0; i < DataCount; i++)
            {
                int num = GetRandomNumber();
                ArrayExample[i] = num;
                StackExample.Push(num);
                QueueExample.Enqueue(num);
                DictionaryExample.Add(i, num);
            }
        }

        public void PrintData()
        {
            PrintArray();
            PrintStack();
            PrintQueue();
            PrintDictionary();
        }

        public void PrintArray()
        {
            WriteLine("\nPress any key to print the data stored in the array.");
            ReadKey();

            WriteLine(@"  ____  ____   ____    ____  __ __     
 /    ||    \ |    \  /    ||  |  | __ 
|  o  ||  D  )|  D  )|  o  ||  |  ||  |
|     ||    / |    / |     ||  ~  ||__|
|  _  ||    \ |    \ |  _  ||___, | __ 
|  |  ||  .  \|  .  \|  |  ||     ||  |
|__|__||__|\_||__|\_||__|__||____/ |__|
                                       ");

            for (int i = 0; i < DataCount; i++)
            {
                WriteLine($"ArrayExample[{i}] = {ArrayExample[i]}.");
            }

            //Understanding is demonstrated here:
            WriteLine("\nAn array is a collection of data stored in ''slots'', identified by a given numeric value.\nThey start at 0, and can have a defined size or an undefined size, the latter of which is treated as infinite.\nArrays are incredibly versatile, and can be used practically anywhere to great effect.\nThey are by far the most common type of data structure, excelling in simplicity and swift look-ups, but there are rare circumstances in which other structures may be preferred.\nIn situatons where you will always need to access the newest or oldest item in the collection, or where two objects of different types must be directly linked to each other, it is best to use a different data structure.\nHowever, in practically every other situation, an array is the best choice.");
        }

        public void PrintStack()
        {
            WriteLine("\nPress any key to print the data stored in the stack.");
            ReadKey();

            WriteLine(@"  _____ ______   ____    __  __  _     
 / ___/|      | /    |  /  ]|  |/ ] __ 
(   \_ |      ||  o  | /  / |  ' / |  |
 \__  ||_|  |_||     |/  /  |    \ |__|
 /  \ |  |  |  |  _  /   \_ |     | __ 
 \    |  |  |  |  |  \     ||  .  ||  |
  \___|  |__|  |__|__|\____||__|\_||__|
                                       ");

            for (int i = 0; i < DataCount; i++)
            {
                WriteLine($"The newest item in the stack is currently {StackExample.Pop()}.");
            }

            //Understanding is demonstrated here:
            WriteLine("\nA stack is a collection of data which operates under LIFO logic, or last-in-first-out.\nThis is precisely what it sounds like: the most recent object added to a stack is the first object it will be able to access.\nObjects can be added to a stack by calling StackName.Push(object), or read and removed from the stack by calling StackName.Pop(). To read the next item in the stack without removing it, you may call StackName.Peek().\nBy their nature, stacks are incredibly specialized, having only one real situation in which they are the most effective choice, being situations in which you will always need to access the newest item in the collection. They more than make up for this, however, by being incredibly fast.\n");
        }

        public void PrintQueue()
        {
            WriteLine("\nPress any key to print the data stored in the queue.");
            ReadKey();

            WriteLine(@"  ___   __ __    ___  __ __    ___     
 /   \ |  |  |  /  _]|  |  |  /  _] __ 
|     ||  |  | /  [_ |  |  | /  [_ |  |
|  Q  ||  |  ||    _]|  |  ||    _]|__|
|     ||  :  ||   [_ |  :  ||   [_  __ 
|     ||     ||     ||     ||     ||  |
 \__,_| \__,_||_____| \__,_||_____||__|
                                       ");

            for (int i = 0; i < DataCount; i++)
            {
                WriteLine($"The oldest item in the queue is currently {QueueExample.Dequeue()}.");
            }

            //Understanding is demonstrated here:
            WriteLine("\nA queue is the inverse of a stack, operating exactly the same, but backwards.\nThey utilize FIFO logic, or first-in-first-out. Instead of always accessing the newest item added, a queue will always access its oldest item.\nTo add an item to a queue, you may call QueueName.Queue(object). To read an item in a queue and remove it from said queue, you may call QueueName.Dequeue(). To read the next item in a queue without removing it, simply use QueueName.Peek().\nJust like stacks, queues only really have one situation in which they are the best choice, which is to say situations when you will always need to access the oldest item in the collection. In return for this restriction, queues are extremely fast.\n");
        }

        public void PrintDictionary()
        {
            WriteLine("\nPress any key to print the data stored in the dictionary.");
            ReadKey();

            WriteLine(@" ___    ____   __ ______  ____  ___   ____    ____  ____   __ __     
|   \  |    | /  ]      ||    |/   \ |    \  /    ||    \ |  |  | __ 
|    \  |  | /  /|      | |  ||     ||  _  ||  o  ||  D  )|  |  ||  |
|  D  | |  |/  / |_|  |_| |  ||  O  ||  |  ||     ||    / |  ~  ||__|
|     | |  /   \_  |  |   |  ||     ||  |  ||  _  ||    \ |___, | __ 
|     | |  \     | |  |   |  ||     ||  |  ||  |  ||  .  \|     ||  |
|_____||____\____| |__|  |____|\___/ |__|__||__|__||__|\_||____/ |__|
                                                                     ");

            for (int i = 0; i < DataCount; i++)
            {
                WriteLine($"Key: {i} | Value: {DictionaryExample[i]}");
            }

            //Understanding is demonstrated here:
            WriteLine("\nDictionaries, which are very similar to hash tables and maps, are a very specialized type of data structure.\nThey exist as a collection of key-value pairs, in which one data type, the key, is directly connected to another data type, the value.\nOne may picture a dictionary as a two-dimensional array, in which both dimensions can be their own type, rather than both needing to be the same.\nThey excel in terms of swift look-ups, and because nearly any hashable type may be used as a key or value, they are very flexible.\nHowever, they suffer in terms of organization, lacking a particular order.\nIf you need to find a value stored in a dictionary base on a specific quality,\nbe it age, size, within a range, you will need to search through the entire dictionary.\nThey are also one-directional; it is very easy to find the value which is tied to a given key, provided you already have the key, but the reverse - which is, to say, finding the key which is tied to a given value - requires the author to manually search the entire dictionary.\nA dictionary is best used under circumstances in which two objects of different types are directly linked to each other, as this allows us to make the most of the dictionary's unique strengths, while mitigating its weaknesses.");
        }

        int GetRandomNumber()
        {
            Random rand = new Random();
            return rand.Next(1, 1000000);
        }
    }
}
