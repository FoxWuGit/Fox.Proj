using AutoMapper;
using Fox.Model.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fox.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration { get; private set; }
        public static IMapper Mapper { get; private set; }
        public static void Config()
        {
            MapperConfiguration = new AutoMapper.MapperConfiguration(x =>
            {
                x.CreateMap<IModelResult, ModelResult>();
            });
            Mapper = MapperConfiguration.CreateMapper();
        }
    }
}