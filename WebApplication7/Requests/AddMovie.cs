namespace WebApplication7.Requests;

public class AddMovie
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public decimal Budget { get; set; }
    public string Genre { get; set; }
    public int Rating { get; set; }
    public bool HasOscar { get; set; }
    public TimeSpan Duration { get; set; }
    public string CountryFrom { get; set; }
}
