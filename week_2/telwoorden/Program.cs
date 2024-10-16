class Program
{
    public static void VerwerkBestand(string filePath) {
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();
        KeyValuePair<string, int>[] mostCommonWords;

        try {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = "";
                int lineNumber = 0;

                while((line = reader.ReadLine()) != null)
                {
                    string[] wordsInLine = line.Split(' ');

                    foreach(string word in wordsInLine)
                    {
                        if (wordCounts.ContainsKey(word)) {
                            wordCounts[word] += 1;
                        } else {
                            wordCounts[word] = 1;
                        }
                    }

                    if (lineNumber % 100 == 0 && lineNumber != 0) {
                        mostCommonWords = wordCounts.OrderByDescending(w => w.Value).Take(3).ToArray();
                        Console.WriteLine("Most common word until line " + lineNumber + ": " + mostCommonWords[0].Key + " (" + mostCommonWords[0].Value + ")");
                    }

                    lineNumber++;
                }

                mostCommonWords = wordCounts.OrderByDescending(w => w.Value).ToArray();
                Console.WriteLine("\nFinal leaderboard of the most common words within this file:");
                for (int i = 0; i < mostCommonWords.Length; i++) {
                    Console.WriteLine((i+1) + ". " + mostCommonWords[i].Key + " (" + mostCommonWords[i].Value + ")");
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
    }

    static void Main()
    {
        VerwerkBestand(@"./txt/input.txt");
    }    
}