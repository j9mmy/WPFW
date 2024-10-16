/* Hexa 1
class HexaDec
{
    private char _waarde;
    public char waarde { 
        get { return _waarde; } 
        set { _waarde = value; } 
    }

    public HexaDec(int waarde) {
        this.waarde = waarde.ToString("X")[0];
    }
}
*/

// Hexa 2
class HexaDec
{
    private string _waarde;
    public string waarde {
        get { return _waarde; }
        set { _waarde = value; }
    }

    public HexaDec(int waarde) {
        this.waarde = waarde.ToString("X");
    }

    public HexaDec(int[] getallen) {
        string waarde = "";

        foreach (int getal in getallen) {
            waarde += getal.ToString("X");
        }

        this.waarde = waarde;
    }

    public static HexaDec operator +(HexaDec hex1, HexaDec hex2) {
        int geconverteerd1 = Convert.ToInt32(hex1.waarde, 16);
        int geconverteerd2 = Convert.ToInt32(hex2.waarde, 16);

        int opgeteld = geconverteerd1 + geconverteerd2;

        return new HexaDec(opgeteld);
    }

    public decimal ToDecimal() {
        int naarInteger = Convert.ToInt32(waarde, 16);
        decimal naarDecimaal = Convert.ToDecimal(naarInteger);

        return naarDecimaal;
    }

    public string ToBinary() {
        decimal naarDecimaal = ToDecimal();
        int geheelGetal = Convert.ToInt32(naarDecimaal);
        string naarBinair = Convert.ToString(geheelGetal, 2);

        return naarBinair;
    }
}

class Program
{
    static void Main()
    {
        /* Hexa 1
        int input = 0;
        bool success = false;

        while (!success)
        { 
            Console.WriteLine("\nVoer een getal tussen 0-15 in:");
            success = int.TryParse(Console.ReadLine(), out input);

            if (!success) Console.WriteLine("Geen geldig getal ingevoerd.");
            if (input > 15 || input < 0) {
                Console.WriteLine("Getal moet tussen 0-15 zijn.");
                success = false;
            }
        }

        HexaDec hex = new HexaDec(input);
        */

        // Hexa 2
        int[] inputs = { 14, 12, 9, 3 };
        bool valid = true;

        foreach (int input in inputs) {
            if (input > 15 || input < 0) valid = false;
        }

        if (!valid) Console.WriteLine("Elk getal moet tussen 0-15 zijn.");
        else 
        {
            if (inputs.Length > 4) Console.WriteLine("Maximaal 4 getallen mogelijk.");
            else 
            {
                HexaDec hex1 = new HexaDec(inputs);
                HexaDec hex2 = new HexaDec(inputs);
                HexaDec hex3 = hex1 + hex2;

                Console.WriteLine("Geconverteerd naar Hexadecimaal: " + hex3.waarde);
                Console.WriteLine("Decimaalgetal: " + hex3.ToDecimal());
                Console.WriteLine("Binairgetal: " + hex3.ToBinary());
            }
        }
    }
}