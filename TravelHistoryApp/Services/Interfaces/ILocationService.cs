using TravelHistoryApp.Models;

namespace TravelHistoryApp.Services.Interfaces;

public interface ILocationService
{
    Action<CustomLocation> OnLocationUpdate { get; set; }
    void StartTracking();
    void StopTracking();
}