namespace TravelHistoryApp.Models;

public class CustomTrack
{
    public int Id { get; set; }
    public List<CustomLocation> Locations { get; set; } = new List<CustomLocation>();

    public CustomTrack()
    {
    }

    public CustomTrack(IList<Location> locations)
    {
        foreach (var loc in locations)
        {
            Locations.Add(new CustomLocation(loc.Latitude, loc.Longitude));
        }
    }
}