using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

public class Movie
{
    public string Title { get; set; }
    public int Year { get; set; }
    public string Director { get; set; }
    public string Genre { get; set; }
}

public class Program
{
    public static IList<Movie> Movies = new List<Movie>
    {
        new Movie {Title = "2001 A Space Odyssey", Year = 1968, Director = "Stanley Kubrick", Genre = "Sci-Fi"},
        new Movie {Title = "The Shining", Year = 1980, Director = "Stanley Kubrick", Genre = "Horror"},
        new Movie {Title = "Dead Poets Society", Year = 1989, Director = "Peter Weir", Genre = "Drama"},
        new Movie {Title = "The Truman Show", Year = 1998, Director = "Peter Weir", Genre = "Sci-Fi"},
        new Movie {Title = "Blade Runner", Year = 1982, Director = "Ridley Scott", Genre = "Sci-Fi"},
        new Movie {Title = "Easy Rider", Year = 1969, Director = "Dennis Hopper", Genre = "Adventure"},
        new Movie {Title = "Once Upon a Time in the West", Year = 1968, Director = "Sergio Leone", Genre = "Western"},
        new Movie {Title = "12 Angry Men", Year = 1957, Director = "Sidney Lumet", Genre = "Drama"},
        new Movie {Title = "A Clockwork Orange", Year = 1971, Director = "Stanley Kubrick", Genre = "Drama"},
        new Movie {Title = "One Flew Over the Cuckoo's Nest", Year = 1975, Director = "Milos Forman", Genre = "Drama"},
        new Movie {Title = "Brazil", Year = 1985, Director = "Terry Gilliam", Genre = "Sci-Fi"},
        new Movie {Title = "Rain Man", Year = 1988, Director = "Barry Levinson", Genre = "Drama"},
        new Movie {Title = "The Good, the Bad and the Ugly", Year = 1968, Director = "Sergio Leone", Genre = "Western"},
        new Movie {Title = "The Perks of Being a Wallflower", Year = 2012, Director = "Stephen Chbosky", Genre = "Drama"},
        new Movie {Title = "Wag The Dog", Year = 1997, Director = "Barry Levinson", Genre = "Drama"},
        new Movie {Title = "For A Few Dollars More", Year = 1965, Director = "Sergio Leone", Genre = "Western"},
        new Movie {Title = "Thelma & Louise", Year = 1991, Director = "Ridley Scott", Genre = "Drama"},
        new Movie {Title = "Ali G IndaHouse", Year = 2002, Director = "Mark Mylod", Genre = "Comedy"}
    };

    static IEnumerable<BigInteger> Fibonacci()
    {
        BigInteger number1 = 1;
        BigInteger number2 = 1;
        yield return number1;
        while (true)
        {
            yield return number2;
            BigInteger temp = number1 + number2;
            number1 = number2;
            number2 = temp;
        }
    }

    static void Main(string[] args)
    {
        Opdracht1();
        Opdracht2();
        Opdracht3();
        Opdracht4();
        Opdracht5();
        Opdracht6();
        Opdracht7();
    }

    static void Opdracht1()
    {
        // Toon van alle films de titel en het jaartal, gesorteerd op jaartal.
        Movies
            .OrderBy(column => column.Year) // OrderByDescending voor omgekeerd
            .Select(row => "(" + row.Year + ") " + row.Title)
            .ToList()
            .ForEach(row => Console.WriteLine(row));
    }

    static void Opdracht2()
    {
        // In welk jaar bracht 'Sergio Leone' zijn eerste film uit?
        var waarde = Movies
            .OrderBy(column => column.Year)
            .Where(column => column.Director == "Sergio Leone")
            .Select(column => column.Year)
            .FirstOrDefault();
        
        Console.WriteLine($"Sergio Leone bracht zijn eerste film uit in: {waarde}.");
    }

    static void Opdracht3()
    {
        // Hoeveel films zijn er van 'Peter Weir' van het genre 'Sci-Fi'?
        var waarde = Movies
            .Where(column => column.Director == "Peter Weir" && column.Genre == "Sci-Fi")
            .Count();
        
        Console.WriteLine($"Peter Weir heeft {waarde} Sci-Fi film(s) gemaakt.");
    }

    static void Opdracht4()
    {
        // Toon de 6e t/m 10e film uit de lijst.
        Movies
            .Skip(5)
            .Take(5)
            .ToList()
            .ForEach(row => Console.WriteLine(row.Title));
    }

    static void Opdracht5()
    {
        // Is er een film uit 1997 (True/False)?
        var waarde = Movies
            .Any(column => column.Year == 1997);

        Console.WriteLine("Er bestaat " + (waarde ? "wel" : "geen") + " een film uit 1997");
    }

    static void Opdracht6()
    {
        // Van welke regisseur is de film 'One Flew over the Cuckoo's Nest'?
        var waarde = Movies
            .Where(column => column.Title == "One Flew Over the Cuckoo's Nest") // Docent vergat een hoofdletter O in "over" :(
            .Select(column => column.Director)
            .FirstOrDefault();
        
        Console.WriteLine($"De film 'One Flew over the Cuckoo's Nest' is geregisseerd door: {waarde}");
    }

    static void Opdracht7()
    {
        // Wat is het 1000e Fibonacci getal?
        IEnumerable<BigInteger> fibonacci = Fibonacci();
        
        var waarde = fibonacci
            .Skip(999)
            .FirstOrDefault();
        
        Console.WriteLine($"De 1000e Fibonacci getal is: {waarde}");
    }
}