using AutoMapper;
using BotafeMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotafeMVC.Application.ViewModels.Event
{
    public class EventDetailsVm : IMapFrom<BotafeMVC.Domain.Model.Event>, IEventVm
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Data rozpoczęcia")]
        public DateOnly StartDate { get; set; }
        [DisplayName("Data zakończenia")]
        public DateOnly EndDate { get; set; }
        [DisplayName("Dostępne miejsca")]
        public int PlacesAvailable { get; set; }
        [DisplayName("Całkowita ilość miejsc")]
        public int TotalNumberOfPlaces { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BotafeMVC.Domain.Model.Event, EventDetailsVm>();
        }
    }
}
