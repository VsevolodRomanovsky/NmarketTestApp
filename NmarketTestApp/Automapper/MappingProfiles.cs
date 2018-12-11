using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NmarketTestApp.ViewModel;
using NmarketTestApp.Models;

namespace NmarketTestApp.Automapper
{
  public class MappingProfiles: Profile
  {
    public MappingProfiles()
    {
      CreateMap<Flat, ObjectViewModel>().ReverseMap();
    }
  }
}
