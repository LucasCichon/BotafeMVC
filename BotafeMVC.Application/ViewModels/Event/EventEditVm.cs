using AutoMapper;
using BotafeMVC.Application.Mapping;
using System.ComponentModel;

namespace BotafeMVC.Application.ViewModels.Event
{
    public class EventEditVm : IMapFrom<BotafeMVC.Domain.Model.Event>, IEventVm
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Data rozpoczęcia")]
        public DateOnly StartDate { get; set; }
        [DisplayName("Data zakończenia")]
        public DateOnly EndDate { get; set; }
        [DisplayName("Dostępne miejsca")]
        public int TotalNumberOfPlaces { get; set; }
        public int PlacesAvailable { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EventEditVm, BotafeMVC.Domain.Model.Event>().ReverseMap();
        }
    }
}
