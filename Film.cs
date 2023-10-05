namespace LinqExercise;

public class Film
{
    public string Title { get; set; }

    public string Director { get; set; }


    public int ReleaseYear { get; set; }

    public double Rating { get; set; }

    public List<int> Films;

    public Film(string title, string director, int releaseYear, double rating)
    {
        Title = title;
        Director = director;
        ReleaseYear = releaseYear;
        Rating = rating;
    }

  

}