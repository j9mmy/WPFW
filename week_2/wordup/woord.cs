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