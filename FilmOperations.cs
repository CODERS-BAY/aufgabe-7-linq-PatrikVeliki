using Newtonsoft.Json;

namespace LinqExercise;

public class FilmOperations
{
    List<Film> films;

    public FilmOperations()
    {
        films = GetAllMovies();
    }

    /// <returns>eine Liste aller Filme zurück.</returns>
    public List<Film> GetAllMovies()
    {
        StreamReader reader = new StreamReader(@"C:\\Users\\CodersBay\\Source\\Repos\\aufgabe-7-linq-PatrikVeliki\\films.json");
        string json = reader.ReadToEnd();
        List<Film> films = JsonConvert.DeserializeObject<List<Film>>(json);
        return films;      
    }

    /// <returns> ein Array von Filmen zurück, die von dem angegebenen Regisseur stammen. </returns>
    public Film[] GetMoviesByDirector(string director)
    {
        return this.films.Where(film => film.Director == director).ToArray();
    }

    /// <returns>ein Array von Filmen zurück, die im angegebenen Erscheinungsjahr veröffentlicht wurden.</returns>
    public Film[] GetMoviesByYear(int releaseYear)
    {
        return this.films.Where(film => film.ReleaseYear == releaseYear).ToArray();
    }

    /// <returns>ein Array von Filmen zurück, die zwischen der angegebenen Mindest- und Höchstbewertung liegen.</returns>
    public Film[] GetMoviesByRatingRange(double minRating, double maxRating)
    {
        var films = from film in this.films
                    orderby film.Rating descending
                    where film.Rating >= minRating && film.Rating <= maxRating
                    select film;
        return films.ToArray();
    }
    
    /// <returns>gibt ein Array mit den best bewerteten Filme zurück, sortiert nach Bewertung. numberOfFilms gibt die
    /// Anzahl der zurückgegeben Filme an.</returns>
    public Film[] GetMoviesByRatingSortedLimited(int numberOfFilms)
    {
        var films = from film in this.films
                    orderby film.Rating descending
                    select film;
        return films.Take(numberOfFilms).ToArray();
    }
}