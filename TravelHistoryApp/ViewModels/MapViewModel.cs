using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls.Maps;
using TravelHistoryApp.Messages;
using TravelHistoryApp.Models;
using TravelHistoryApp.Services.Interfaces;

namespace TravelHistoryApp.ViewModels;

public partial class MapViewModel : ObservableObject, IDisposable
{

    private readonly ILocationService locationService;

    public MapViewModel(ILocationService locationService)
    {
        this.locationService = locationService;
        locationService.OnLocationUpdate = OnLocationUpdate;
        locationService.StartTracking();
        Track = new Polyline
        {
            StrokeColor = Colors.Blue,
            StrokeWidth = 5
        };
    }

    private void OnLocationUpdate(CustomLocation location)
    {
        Track.Geopath.Add(new Location(location.Latitude, location.Longitude));
        WeakReferenceMessenger.Default.Send(new LocationUpdateMessage(location));
    }

    public void Dispose()
    {
        if (locationService != null)
        {
            locationService.OnLocationUpdate = null;
            locationService.StopTracking();
        }
    }

    [ObservableProperty]
    private Polyline track;
}