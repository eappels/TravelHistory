using Microsoft.Maui.Controls.Maps;
using TravelHistoryApp.ViewModels;

namespace TravelHistoryApp.Views;

[QueryProperty(nameof(Polyline), "track")]
public partial class HistoryView : ContentPage
{

    private HistoryViewModel viewModel;

    Polyline track;
    public Polyline Track
    {
        get => track;
        set
        {
            track = value;
            OnPropertyChanged();
        }
    }

    public HistoryView()
	{
		InitializeComponent();
        viewModel = (HistoryViewModel)BindingContext;
        if (MyMap != null && viewModel != null)
        {
            MyMap.MapElements.Add(Track);
        }
    }
}