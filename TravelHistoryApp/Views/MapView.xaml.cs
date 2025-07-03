using Microsoft.Maui.Maps;
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
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        Location currentLocation = await Geolocation.GetLastKnownLocationAsync();
        if (currentLocation != null)
        {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(currentLocation, Distance.FromMeters(zoomLevel)));
        }
    }
}