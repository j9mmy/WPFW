using System.Text.RegularExpressions;

class Woord
{
    public string Tekst { get; set; }

    public Woord(string tekst) {
        Tekst = Regex.Replace(tekst, @"[^a-zA-Z]+", String.Empty); // tekst mag geen speciale tekens bevatten
    }

    public int aantalMedeklinkers() {
        string tekst = Tekst.ToLower();
        int aantal = 0;
        List<char> medeklinkers = new List<char>{'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'};

        for (int i = 0; i < Tekst.Length; i++)
        {
            Console.WriteLine("\nKarakter '" + tekst[i] + "' checken voor medeklinkers in: " + tekst);
            
            for (int j = 0; j < medeklinkers.Count; j++) 
            {
                if (tekst[i] == medeklinkers[j]) {
                    Console.WriteLine("+1 | '" + tekst[i] + "' is een medeklinker.");
                    aantal++;
                    break;
                } else {
                    if (j == (medeklinkers.Count - 1)) Console.WriteLine("Geen medeklinker.");
                }
            }     
        }

        return aantal;
    }

    public int aantalKlinkers() {
        string tekst = Tekst.ToLower();
        int aantal = 0;
        List<char> medeklinkers = new List<char>{'a', 'e', 'i', 'o', 'u'};

        for (int i = 0; i < Tekst.Length; i++)
        {
            Console.WriteLine("\nKarakter '" + tekst[i] + "' checken voor klinkers in: " + tekst);

            for (int j = 0; j < medeklinkers.Count; j++) 
            {
                if (tekst[i] == medeklinkers[j]) {
                    Console.WriteLine("+1 | '" + tekst[i] + "' is een klinker.");
                    aantal++;
                    break;
                } else {
                    if (j == (medeklinkers.Count - 1)) Console.WriteLine("Geen klinker.");
                }
            }     
        }

        return aantal;
    }
}

class Program
{
    static void Main()
    {
        string txtPath = @".\txt\tekst.txt";
        string text = string.Join(" ", File.ReadAllLines(txtPath));
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

        Console.WriteLine("\nAantal klinkers:");
        foreach ( Woord woord in WoordList)
        {
            Console.WriteLine(woord.Tekst + ": " + aantalKlinkers[i]);
            i++;
        }

        i = 0;
        
        Console.WriteLine("\nAantal medeklinkers:");
        foreach ( Woord woord in WoordList)
        {
            Console.WriteLine(woord.Tekst + ": " + aantalMedeklinkers[i]);
            i++;
        }
    }
}