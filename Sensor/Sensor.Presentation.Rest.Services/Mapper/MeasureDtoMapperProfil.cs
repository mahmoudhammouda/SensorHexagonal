using AutoMapper;
using Sensor.Domain.Enum;
using Sensor.Domain.Model;
using Sensor.Infrastructure.Repository.Model;
using Sensor.Presentation.Rest.Services.Dto.Measure;
using Sensor.Presentation.Rest.Services.Dto.Threshold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Presentation.Rest.Services.Mapper
{

    public class MeasureDtoMapperProfil : Profile
    {

        public MeasureDtoMapperProfil()
        {
            // MeseaureDto
            CreateMap<Measure, MeasureDto>()
                .ForMember(dest => dest.IndicatorId, opt => opt.MapFrom(src => src.Indicator.Id))
                .ForMember(dest => dest.SourceId, opt => opt.MapFrom(src => src.Source.Id))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value.Valeur))
                .ForMember(dest => dest.Unity, opt => opt.MapFrom(src => src.Value.Unite))
                ;

            // not needed for input
            // CreateMap<MeasureDto,Measure>()

            // MeasurCreateDto
            // MeasurUpdateDto
            // Not needed as by parameters DDD







        }
    }
}
