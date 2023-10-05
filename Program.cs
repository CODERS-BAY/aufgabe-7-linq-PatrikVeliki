using Newtonsoft.Json;

namespace LinqExercise;

public class Program
{
    public static void Main()
    { 
        FilmOperations filmOperations = new FilmOperations();
        var films = filmOperations.GetAllMovies();
        Console.WriteLine();
        Console.WriteLine("Alle Filme:");
        foreach (Film film in films)
        {
            Console.WriteLine($"{film.Title} {film.Director} {film.ReleaseYear} {film.Rating}");
        }

        Console.WriteLine();
        Console.WriteLine("Filme von welchem Regisseur:");
        string director = Console.ReadLine();
        Film[] filmsByDirector = filmOperations.GetMoviesByDirector(director);
        foreach (Film film in filmsByDirector)
        {
            Console.WriteLine($"{film.Title} {film.Director} {film.ReleaseYear} {film.Rating}");
        }


        Console.WriteLine();
        Console.WriteLine("Filme von welchem Jahr:");
        string year = Console.ReadLine();
            Film[] filmsByYear = filmOperations.GetMoviesByYear(int.Parse(year));
        foreach (Film film in filmsByYear)
        {
            Console.WriteLine($"{film.Title} {film.Director} {film.ReleaseYear} {film.Rating}");
        }


        Console.WriteLine();
        Console.WriteLine("Filme mit einer Bewertung von:");
        string rating = Console.ReadLine();
        try
        {
            Film[] filmsByRatingRange2 = filmOperations.GetMoviesByRatingRange(double.Parse(rating), 10);
            foreach (Film film in filmsByRatingRange2)
            {
                Console.WriteLine($"{film.Title} {film.Director} {film.ReleaseYear} {film.Rating}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


        Console.WriteLine();
        Console.WriteLine("Wieviele filme mit Topbewertung willst du anzeigen?");
        string numberOfFilms = Console.ReadLine();
        Film[] filmsByRatingSortedLimited = filmOperations.GetMoviesByRatingSortedLimited(int.Parse(numberOfFilms));
        foreach (Film film in filmsByRatingSortedLimited)
        {
            Console.WriteLine($"{film.Title} {film.Director} {film.ReleaseYear} {film.Rating}");
        }

    }

}