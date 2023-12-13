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
    public class SourceMapperProfile : Profile
    {
        public SourceMapperProfile()
        {
            // using contructor to map Db entity to domain model as domain.setters are private
            CreateMap<SourceEntity, Source>()
                .ConstructUsing(db => new Source(
                    db.Id,
                    db.Name,
                    EnumConverter<SourceTypeEnum>.ConvertFromString(db.SourceType)
                    )
                );

           CreateMap<Source, SourceEntity>()
                .ForMember(dest => dest.SourceType,opt => opt.MapFrom(src => src.SourceType.ToString()));

                }
    }
}
