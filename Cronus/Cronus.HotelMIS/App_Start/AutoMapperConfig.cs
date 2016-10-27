using AutoMapper;
using Cronus.HotelMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cronus.HotelMIS
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Country, CountryModel>();
                cfg.CreateMap<CountryModel, Country>();
                cfg.CreateMap<State, StateModel>();
                cfg.CreateMap<StateModel, State>();
                cfg.CreateMap<City, CityModel>();
                cfg.CreateMap<CityModel, City>();
            });
        }
   
    }


}