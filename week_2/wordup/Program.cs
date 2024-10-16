class Program
{
    static void Main()
    {
        string inputPath = @".\txt\input.txt";
        // Console.Write("Voer pad naar het tekstbestand in: ");
        // string inputPath = Console.ReadLine();
        string text = string.Join(" ", File.ReadAllLines(inputPath));
        List<string> wordsList = new List<string>(text.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        List<Woord> WoordList = new List<Woord>();

        foreach (string word in wordsList)
        {
            WoordList.Add(new Woord(word));
        }

        List<int> aantalKlinkers = new List<int>();
        List<int> aantalMedeklinkers = new List<int>();

        foreach (Woord woord in WoordList)
        {
            aantalKlinkers.Add(woord.aantalKlinkers());
            aantalMedeklinkers.Add(woord.aantalMedeklinkers());
        }

        int totaalAantalKlinkers = 0;
        int totaalAantalMedeklinkers = 0;

        foreach (int klinkerAantal in aantalKlinkers)
        {
            totaalAantalKlinkers += klinkerAantal;
        }

        foreach (int medeklinkerAantal in aantalMedeklinkers)
        {
            totaalAantalMedeklinkers += medeklinkerAantal;
        }

        int i = 0;
        List<string> output = new List<string>();
        string outputPath = @"./txt/output.txt";

        Console.WriteLine("\nAantal klinkers:");
        output.Add("\nAantal klinkers:");
        foreach ( Woord woord in WoordList)
        {
            Console.WriteLine(woord.Tekst + ": " + aantalKlinkers[i]);
            output.Add(woord.Tekst + ": " + aantalKlinkers[i]);
            i++;
        }

        i = 0;
        
        Console.WriteLine("\nAantal medeklinkers:");
        output.Add("\nAantal medeklinkers:");
        foreach ( Woord woord in WoordList)
        {
            Console.WriteLine(woord.Tekst + ": " + aantalMedeklinkers[i]);
            output.Add(woord.Tekst + ": " + aantalMedeklinkers[i]);
            i++;
        }

        Tekst tekst = new Tekst();
        List<string> sanitizedWordsList = new List<string>();
        
        foreach (Woord woord in WoordList)
        {
            sanitizedWordsList.Add(woord.Tekst);
        }

        tekst.woorden = sanitizedWordsList;
        tekst.DraaiOm();
        Console.WriteLine("\nPalindromen: " + string.Join(", ", tekst.Palindromen()));
        output.Add("\nPalindromen: " + string.Join(", ", tekst.Palindromen()));

        File.WriteAllLines(outputPath, output);
    }
}