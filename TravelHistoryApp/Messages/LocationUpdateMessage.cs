using CommunityToolkit.Mvvm.Messaging.Messages;
using TravelHistoryApp.Models;

namespace TravelHistoryApp.Messages;

public class LocationUpdateMessage : ValueChangedMessage<CustomLocation>
{
    public LocationUpdateMessage(CustomLocation location)
        : base(location)
    {
    }
}