using AutoMapper;
using BotafeMVC.Application.Mapping;
using FluentValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BotafeMVC.Application.ViewModels.Event
{
    public class NewEventVm : IMapFrom<BotafeMVC.Domain.Model.Event>
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Data rozpoczęcia")]
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [DisplayName("Data zakończenia")]
        public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [DisplayName("Ilość miejsc")]
        public int TotalNumberOfPlaces { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewEventVm, BotafeMVC.Domain.Model.Event>()
                .ForMember(p => p.StatusId, opt => opt.MapFrom(o => 1));
        }
    }

    public class NewEventValidator : AbstractValidator<NewEventVm>
    {
        public NewEventValidator()
        {
            RuleFor(e => e.Id).NotNull();
            RuleFor(e => e.Id).Equal(0);
            RuleFor(e => e.Name).NotNull();
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.StartDate).GreaterThan(new DateOnly());
            RuleFor(e => e.EndDate).GreaterThan(new DateOnly());
            RuleFor(e => e.TotalNumberOfPlaces).GreaterThan(0);

        }
    }
}
