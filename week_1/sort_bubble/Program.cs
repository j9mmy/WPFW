class Sorter
{
    public string[] BubbleSort(string[] lijst) {
        bool gesorteerd = false;
        int teller = 0;
        
        while (!gesorteerd)
        {
            teller = 0;

            for (int i = 0; i < (lijst.Length - 1); i++)
            {
                string woord1 = lijst[i];
                string woord2 = lijst[i+1];

                if (string.Compare(woord1, woord2) > 0) {
                    lijst[i] = woord2;
                    lijst[i+1] = woord1;
                    teller++;
                }
            }

            if (teller == 0) gesorteerd = true;
        }

        return lijst;
    }

    public List<string> InsertionSort(List<string> lijst) {
        List<string> nieuw = new List<string>();

        for (int i = 0; i < lijst.Count; i++)
        {
            string woord1 = lijst[i];
            bool inserted = false;

            for (int j = 0; j < i; j++)
            {
                string woord2 = nieuw[j];

                if (string.Compare(woord1, woord2) < 0) {
                    nieuw.Insert(j, woord1);
                    inserted = true;
                }

                if (inserted) break;
            }

            if (!inserted) nieuw.Insert(nieuw.Count, woord1);
        }

        return nieuw;
    }
}

class Program
{
    static void Main()
    {
        string[] inputsArray = { "Johan", "Tenma", "Dieter", "Anna", "Wolfgang", "Lunge" };
        List<string> inputsList = new List<string>{"Johan", "Tenma", "Dieter", "Anna", "Wolfgang", "Lunge"};
        Sorter sorter = new Sorter();
        Console.WriteLine("Ongesorteerde lijst: " + string.Join(", ", inputsArray));
        Console.WriteLine("Gesorteerde lijst (Bubble sort): " + string.Join(", ", sorter.BubbleSort(inputsArray)));
        Console.WriteLine("Gesorteerde lijst (Insertion sort): " + string.Join(", ", sorter.InsertionSort(inputsList)));
    }
}