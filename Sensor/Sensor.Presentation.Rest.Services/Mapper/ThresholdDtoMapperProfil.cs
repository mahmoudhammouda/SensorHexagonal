using AutoMapper;
using Newtonsoft.Json.Linq;
using Sensor.Domain.Enum;
using Sensor.Domain.Model;
using Sensor.Infrastructure.Repository.Model;
using Sensor.Presentation.Rest.Services.Dto.Threshold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Presentation.Rest.Services.Mapper
{

    public class ThresholdDtoMapperProfil : Profile
    {

        public ThresholdDtoMapperProfil()
        {

            CreateMap<CreateThresholdDto, Threshold>()
                 .ConstructUsing(dto => new Threshold(
                    -1,
                    dto.IndicatorId,
                    dto.SourceId,
                    dto.MinValue,
                    dto.MaxValue
                    )
                );



            CreateMap<UpdateThresholdDto, Threshold>()
                .ConstructUsing(dto => new Threshold(
                    dto.Id,
                    dto.IndicatorId,
                    dto.SourceId,
                    dto.MinValue,
                    dto.MaxValue
                    )
                );

            CreateMap<ThresholdDto,Threshold>().ReverseMap();


        }
    }
}
