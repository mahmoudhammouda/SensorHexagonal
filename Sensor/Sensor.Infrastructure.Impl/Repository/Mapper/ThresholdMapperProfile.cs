using AutoMapper;
using Sensor.Domain.Enum;
using Sensor.Domain.Model;
using Sensor.Infrastructure.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Impl.Repository.Mapper
{
    public class ThresholdMapperProfile : Profile
    {

        public ThresholdMapperProfile()
        {
            CreateMap<ThresholdEntity, Threshold>().ReverseMap();
        }
    }
}
