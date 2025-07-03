using TravelHistoryApp.Models;
using TravelHistoryApp.Services.Interfaces;

namespace TravelHistoryApp.Services;

public partial class LocationService : ILocationService
{
    public Action<CustomLocation> OnLocationUpdate { get; set; }

    public void StartTracking()
    {
        StartTrackingInternal();
    }

    public void StopTracking()
    {
        StopTrackingInternal();
    }

    partial void StartTrackingInternal();
    partial void StopTrackingInternal();
}