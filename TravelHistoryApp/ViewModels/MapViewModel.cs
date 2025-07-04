using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        StartStopButtonEnabed = true;
        StartStopButtonColor = "Green";
        StartStopButtonText = "Start";
        this.locationService = locationService;
        locationService.OnLocationUpdate = OnLocationUpdate;
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

    [RelayCommand]
    public async Task StartStopRecordingAsync()
    {
        StartStopButtonText = StartStopButtonText == "Start" ? "Stop" : "Start";
        if (StartStopButtonText == "Stop")
        {
            Track.Geopath.Clear();
            locationService.StartTracking();
            StartStopButtonColor = "Red";
        }
        else
        {
            locationService.StopTracking();
            StartStopButtonEnabed = false;
            var result = await Application.Current.MainPage.DisplayAlert("Save Track", "Do you want to save the current track?", "Yes", "No");
            if (result == true)
            {
                var track = new CustomTrack(Track.Geopath);
                //await dbService.SaveTrackAsync(track);
                result = await App.Current.Windows[0].Page.DisplayAlert("Track saved", "Do you want to display the saved track?", "Yes", "No");
                if (result == true)
                {
                    await Shell.Current.GoToAsync($"///HistoryView", new Dictionary<string, object>
                    {
                        { "track", Track }
                    });
                }
                else
                {
                    Track.Geopath.Clear();
                    StartStopButtonColor = "Green";
                    StartStopButtonEnabed = true;
                }
            }
            else
            {
                Track.Geopath.Clear();
            }
            StartStopButtonColor = "Green";
            StartStopButtonEnabed = true;
        }
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

    [ObservableProperty]
    private string startStopButtonText;

    [ObservableProperty]
    private string startStopButtonColor;

    [ObservableProperty]
    private bool startStopButtonEnabed;
}