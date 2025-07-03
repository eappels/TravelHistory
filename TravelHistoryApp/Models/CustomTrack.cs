namespace TravelHistoryApp.Models;

public class CustomTrack
{
    public int Id { get; set; }
    public List<CustomLocation> Locations { get; set; }

    public CustomTrack()
    {
    }

    public CustomTrack(List<CustomLocation> locations)
    {
        Locations = locations ?? new List<CustomLocation>();
    }
}