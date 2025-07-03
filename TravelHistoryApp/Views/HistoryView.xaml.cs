using TravelHistoryApp.ViewModels;

namespace TravelHistoryApp.Views;

public partial class HistoryView : ContentPage
{

    private HistoryViewModel viewModel;

    public HistoryView()
	{
		InitializeComponent();
        viewModel = (HistoryViewModel)BindingContext;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel = (HistoryViewModel)BindingContext;

        if (MyMap != null && viewModel != null)
        {
            MyMap.MapElements.Add(viewModel.Track);
        }
    }
}