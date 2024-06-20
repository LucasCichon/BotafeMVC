using System.ComponentModel;

namespace BotafeMVC.Application.ViewModels.Event
{
    internal interface IEventVm
    {
        int Id { get; set; }
        string Name { get; set; }
        DateOnly StartDate { get; set; }
        DateOnly EndDate { get; set; }
        int TotalNumberOfPlaces { get; set; }
        int PlacesAvailable { get; set; }
    }
}