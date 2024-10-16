struct Tekst
{
    public List<string> woorden;
    public string bestandPad;
    public string bestandNaam;
    public List<string> omgekeerd;

    public List<string> GetWoorden() {
        return woorden;
    }

    public void DraaiOm() {
        List<string> nieuw = new List<string>();
        
        for (int i = 0; i < woorden.Count; i++) {
            string achterstevoren = "";

            for (int j = (woorden[i].Length - 1); j >= 0; j--) {
                achterstevoren += woorden[i][j].ToString();
            }

            nieuw.Add(achterstevoren);
        }

        omgekeerd = nieuw;
    }

    public List<string> Palindromen() {
        List<string> palindromen = new List<string>();
        Console.WriteLine(string.Join(", ", woorden));
        Console.WriteLine(string.Join(", ", omgekeerd));

        for (int i = 0; i < woorden.Count; i++)
        {
            string woord = woorden[i].ToLower();
            string omgekeerd = this.omgekeerd[i].ToLower();

            if (woord == omgekeerd) {
                Console.WriteLine(woord + " is een palindroom!");
                palindromen.Add(woorden[i]);
            } else {
                Console.WriteLine(woord + " is geen palindroom.");
            }
        }

        return palindromen;
    }
}