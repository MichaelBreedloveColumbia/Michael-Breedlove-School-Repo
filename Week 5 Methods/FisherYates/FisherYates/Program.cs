using FisherYates;

List<int> Numbers = new List<int>();
Shuffle shuffler = new Shuffle();

for (int i = 1; i <= 10; i++)
{
    Numbers.Add(i);
}

PrintNumbers();
Console.WriteLine("\n\nShuffling the list.\n");
Numbers = shuffler.ShuffleList(Numbers);
PrintNumbers();
Console.WriteLine("\n\nPress any key to exit.");
Console.ReadKey();

void PrintNumbers()
{
    Console.WriteLine("The list is currently: ");
    for(int i = 0; i < Numbers.Count; i++)
    {
        Console.Write(Numbers[i] + " ");
        if (i == Numbers.Count)
        {
            Console.WriteLine("\n");
        }
    }
}