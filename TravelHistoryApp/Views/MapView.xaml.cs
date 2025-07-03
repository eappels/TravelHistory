using TravelHistoryApp.ViewModels;

namespace TravelHistoryApp.Views;

public partial class MapView : ContentPage
{

	private readonly MapViewModel viewModel;

	public MapView()
	{
		InitializeComponent();
		viewModel = (MapViewModel)BindingContext;
    }
}