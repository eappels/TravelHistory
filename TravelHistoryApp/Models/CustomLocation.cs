namespace TravelHistoryApp.Models;

public class CustomLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public CustomLocation(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public override string ToString()
    {
        return $"({Latitude}, {Longitude})";
    }
}