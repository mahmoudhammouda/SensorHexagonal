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
    public class IndicatorMapperProfile : Profile
    {

        public IndicatorMapperProfile()
        {
            // using contructor to map Db entity to domain model as domain.setters are private
            CreateMap<IndicatorEntity, Indicator>()
                .ConstructUsing(db => new Indicator(
                    db.Id,
                    db.Name,
                    db.Description,
                    db.Category,
                    EnumConverter<ValueTypeEnum>.ConvertFromString(db.Type)
                    )
                );

            CreateMap<Indicator, IndicatorEntity>()
                .ForMember(dest => dest.Type,opt => opt.MapFrom(src => src.ValueType.ToString()));
                }
    }
}
