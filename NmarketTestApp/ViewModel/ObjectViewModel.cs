using System;
using NmarketTestApp.Models;
using AutoMapper;

namespace NmarketTestApp.ViewModel
{

  public class ObjectViewModel : Profile
  {
    public Guid Id { get; set; }
    public int FlatId { get; set; }
    public int RoomsCount { get; set; }
    public decimal TotalArea { get; set; }
    public decimal KitchenArea { get; set; }
    public int Floor { get; set; }
    public int BuildingId { get; set; }
    public decimal Price { get; set; }
    public Building Building { get; set; }

   /* [AutomapperInitialization]
    public static void ConfigureMap(MapperConfigurationExpression cfg)
    {
         cfg.CreateMap<Flat, ObjectViewModel>()
        .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
        .ForMember(d => d.FlatId, o => o.MapFrom(s => s.FlatId))
        .ForMember(d => d.BuildingId, o => o.MapFrom(s => s.BuildingId))
        .ForMember(d => d.RoomsCount, o => o.MapFrom(s => s.RoomsCount))
        .ForMember(d => d.TotalArea, o => o.MapFrom(s => s.TotalArea))
        .ForMember(d => d.KitchenArea, o => o.MapFrom(s => s.KitchenArea))
        .ForMember(d => d.Price, o => o.MapFrom(s => s.Price))
        .ForMember(d => d.Building, o => o.MapFrom(s => s.Building))
        .ForAllOtherMembers(x => x.Ignore());

         cfg.CreateMap<ObjectViewModel, Flat>()
        .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
        .ForMember(d => d.FlatId, o => o.MapFrom(s => s.FlatId))
        .ForMember(d => d.BuildingId, o => o.MapFrom(s => s.BuildingId))
        .ForMember(d => d.RoomsCount, o => o.MapFrom(s => s.RoomsCount))
        .ForMember(d => d.TotalArea, o => o.MapFrom(s => s.TotalArea))
        .ForMember(d => d.KitchenArea, o => o.MapFrom(s => s.KitchenArea))
        .ForMember(d => d.Price, o => o.MapFrom(s => s.Price))
        .ForMember(d => d.Building, o => o.MapFrom(s => s.Building))
        .ForAllOtherMembers(x => x.Ignore());
    }*/

  }
}
