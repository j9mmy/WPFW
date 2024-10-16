class Program
{
    static void Main()
    {
        string filePath = @"./txt/input.txt";
        List<string> text = new List<string>();

        try{
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = "";
                int lineNumber = 0;

                while((line = reader.ReadLine()) != null)
                {
                    text.Add(line);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("The file was not found: " + ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("You do not have permission to access this file: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        Console.WriteLine(string.Join("\n", text));
    }
}