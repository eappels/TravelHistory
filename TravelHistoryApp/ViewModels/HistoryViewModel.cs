using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.Maps;

namespace TravelHistoryApp.ViewModels;

public partial class HistoryViewModel : ObservableObject
{
    public HistoryViewModel()
    {
        
    }

    [ObservableProperty]
    private Polyline track = new();
}