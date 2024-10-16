class SomInt
{
    private int _waarde;
    public int waarde { 
        get
        {
            return _waarde;
        }
        private set
        {
            if (value > 2147483647)
            {
                throw new ArgumentOutOfRangeException("waarde", "Waarde is te groot");
            }

            _waarde = value;
        }
    }

    public SomInt(int waarde)
    {        
        this.waarde = waarde * 4;
    }

    public SomInt(int waarde1, int waarde2)
    {
        this.waarde = waarde1 + waarde2;
    }

    // Calc 2
    public static SomInt operator +(SomInt som1, SomInt som2)
    {
        return new SomInt(som1.waarde + som2.waarde);
    }
}

class Program
{
    static void Main()
    {
        SomInt som;
        int input1 = 0;
        int input2 = 0;
        string input;

        bool success = false;

        while(!success)
        {
            Console.WriteLine("Voer het eerste getal in: ");
            input = Console.ReadLine();
            success = int.TryParse(input, out input1);

            if (!success) Console.WriteLine("Geen (geldige) getal ingevoerd.");
        }

        Console.WriteLine("Voer een tweede getal (indien van toepassing): ");
        input = Console.ReadLine();
        success = int.TryParse(input, out input2);

        som = success ? new SomInt(input1) : new SomInt(input1, input2);

        Console.WriteLine("Resultaat: " + som.waarde);

        // SomInt som3 = som1 + som2;
        // Console.WriteLine(som3.waarde);
    }
}