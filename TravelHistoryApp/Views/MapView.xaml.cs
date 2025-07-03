using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Maps;
using TravelHistoryApp.Messages;
using TravelHistoryApp.ViewModels;

namespace TravelHistoryApp.Views;

public partial class MapView : ContentPage
{

	private readonly MapViewModel viewModel;
    private double zoomLevel = 100;

    public MapView()
	{
		InitializeComponent();
		viewModel = (MapViewModel)BindingContext;

        if (MyMap != null)
        {
            MyMap.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "VisibleRegion")
                {
                    zoomLevel = MyMap.VisibleRegion.Radius.Meters;
                }
            };
        }

        WeakReferenceMessenger.Default.Register<LocationUpdateMessage>(this, (r, m) =>
        {
            if (MyMap != null && m.Value != null)
            {
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(m.Value.Latitude, m.Value.Longitude), Distance.FromMeters(zoomLevel)));
            }
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (MyMap != null)
        {
            MyMap.MapElements.Add(((MapViewModel)(BindingContext)).Track);
            Location currentLocation = await Geolocation.GetLastKnownLocationAsync();
            if (currentLocation != null)
            {
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(currentLocation, Distance.FromMeters(zoomLevel)));
            }
        }
    }
}