//using AutoMapper;
//using Sensor.Domain.Enum;
//using Sensor.Domain.Model;
//using Sensor.Infrastructure.Repository.Model;
//using Sensor.Presentation.Rest.Services.Dto.Threshold;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sensor.Presentation.Rest.Services.Mapper
//{
   
//    public class ThresholdDtoMapperProfil : Profile
//    {

//        public ThresholdDtoMapperProfil()
//        {
//            // using contructor to map Db entity to domain model as domain.setters are private
//            CreateMap<IndicatorEntity, Indicator>()
//                .ConstructUsing(db => new Indicator(
//                    db.Id,
//                    db.Name,
//                    db.Description,
//                    db.Category,
//                    EnumConverter<ValueTypeEnum>.ConvertFromString(db.Type)
//                    )
//                );

//            CreateMap<Indicator, IndicatorEntity>()
//                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ValueType.ToString()));


//            mc.CreateMap<CreateThresholdDto, Threshold>()
//            .ForMember(dest => dest.SourceId, opt => opt.MapFrom(src => src.SourceId))
//            .ForMember(dest => dest.IndicatorId, opt => opt.MapFrom(src => src.IndicatorId))
//            .ForMember(dest => dest.MinValue, opt => opt.MapFrom(src => src.MinValue))
//            .ForMember(dest => dest.MaxValue, opt => opt.MapFrom(src => src.MaxValue));

//            mc.CreateMap<UpdateThresholdDto, Threshold>()
//                .ForMember(dest => dest.MinValue, opt => opt.MapFrom(src => src.MinValue))
//                .ForMember(dest => dest.MaxValue, opt => opt.MapFrom(src => src.MaxValue))
//                .ForAllOtherMembers(opts => opts.Ignore()); // Ignorer l'ID et d'autres champs non modifiables

//            mc.CreateMap<Threshold, ThresholdDto>();


//        }
//    }
//}
