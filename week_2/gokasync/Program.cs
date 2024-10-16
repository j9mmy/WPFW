public class WordCounter
{
    public Dictionary<string, int> wordCounts { get; set; } = new Dictionary<string, int>();
}

class Program
{
    public static async Task VerwerkBestand(string filePath, WordCounter wordCounter) {
        try {
            StreamReader reader = new StreamReader(filePath);
            string line = "";

            while((line = await reader.ReadLineAsync()) != null)
            {
                string[] wordsInLine = line.Split(' ');

                foreach(string word in wordsInLine)
                {
                    if (wordCounter.wordCounts.ContainsKey(word)) {
                        wordCounter.wordCounts[word] += 1;
                    } else {
                        wordCounter.wordCounts[word] = 1;
                    }
                }

                // Thread.Sleep(1);
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

    static async Task Main()
    {
        string input = "";
        string filePath = @"./txt/input.txt";
        WordCounter wordCounter = new WordCounter();

        var processingTask = Task.Run(() => VerwerkBestand(filePath, wordCounter));

        while (input != "-1") {
            Console.Write("\nGuess how many times the most common word comes up (or enter -1 to stop): ");
            input = Console.ReadLine();
            
            var mostCommonWords = wordCounter.wordCounts.OrderByDescending(w => w.Value).Take(3).ToArray();
            Console.WriteLine("Most common word (as of now): " + mostCommonWords[0].Key + " (" + mostCommonWords[0].Value + ")");
        }
        
        /*
        while (!processingTask.IsCompleted) {
            await Task.Run(() => {
                var mostCommonWords = wordCounter.wordCounts.OrderByDescending(w => w.Value).Take(3).ToArray();

                Console.WriteLine("\nMost common words as of now (refreshes every 10 seconds): ");
                for (int i = 0; i < mostCommonWords.Length; i++) {
                    Console.WriteLine((i+1) + ". " + mostCommonWords[i].Key + " (" + mostCommonWords[i].Value + ")");
                }
            });
            
            Thread.Sleep(10000);
        }
        */

        await processingTask;

        var mostCommonWord = wordCounter.wordCounts.OrderByDescending(w => w.Value).FirstOrDefault();
        Console.Write("\nThe most common word found is: " + mostCommonWord.Key + " (" + mostCommonWord.Value + ")");
    }    
}