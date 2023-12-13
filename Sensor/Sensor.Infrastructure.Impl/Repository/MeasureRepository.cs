using AutoMapper;
using Sensor.CrossCutting;
using Sensor.Domain.Model;
using Sensor.Infrastructure.Repository;
using Sensor.Infrastructure.Repository.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Impl.Repository
{
    public class MeasureRepository : IMeasureRepository
    {
        private readonly IGenericRepository<MeasureEntity> _measureEntityRepository;
        private readonly IGenericRepository<IndicatorEntity> _indicatorEntityRepository;
        private readonly IGenericRepository<SourceEntity> _sourceEntityRepository;

        private readonly IMapper _mapper;
        public MeasureRepository(
            IGenericRepository<MeasureEntity> measureEntityRepository,
            IGenericRepository<IndicatorEntity> indicatorEntityRepository,
            IGenericRepository<SourceEntity> sourceEntityRepository,
            IMapper mapper
            )
        {
            _measureEntityRepository = measureEntityRepository ?? throw new ArgumentNullException(nameof(measureEntityRepository)); 
            _indicatorEntityRepository = indicatorEntityRepository ?? throw new ArgumentNullException(nameof(indicatorEntityRepository));
            _sourceEntityRepository = sourceEntityRepository ?? throw new ArgumentNullException(nameof(sourceEntityRepository));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        public int Add(Measure measure)
        {
            try
            {
                MeasureEntity dbItem = new MeasureEntity()
                {
                    Id = -1,
                    IndicatorId = measure.Indicator.Id,
                    SourceId = measure.Source.Id,
                    Value = measure.Value.Valeur,
                    Unity = measure.Value.Unite,
                    ObservationTime = DateTimeConverter.ConvertDateTimeUtcToString(measure.ObservationTime)
                };

                var newId =_measureEntityRepository.Add(dbItem);
                measure.SetAndValidateId(newId);
                return newId;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public IEnumerable<Measure> GetAll()
        {
            var measureDbLst = _measureEntityRepository.GetAll();
            List<Measure> measureList = new List<Measure>();

            foreach (var measureDbItem in measureDbLst) 
            {
                MeasureEntity mesureEntity = null;
                SourceEntity sourceEntity = null;
                IndicatorEntity indicatorEntity = null;

                mesureEntity = measureDbItem; //_measureEntityRepository.GetById(measureDbItem.Id);
                if (mesureEntity.IndicatorId >= 0)
                    indicatorEntity = _indicatorEntityRepository.GetById(mesureEntity.IndicatorId);
                if (mesureEntity.SourceId >= 0)
                    sourceEntity = _sourceEntityRepository.GetById(mesureEntity.SourceId);

                var indicator = indicatorEntity != null ? _mapper.Map<IndicatorEntity, Indicator>(indicatorEntity) : null;
                var source = sourceEntity != null ? _mapper.Map<SourceEntity, Source>(sourceEntity) : null;

                measureList.Add(new Measure
                     (
                     id: mesureEntity.Id,
                     indicator: indicator,
                     source: source,
                     new MeasureValue(mesureEntity.Value, mesureEntity.Unity),
                     observationTime: DateTimeConverter.ConvertToDateTimeUtc(mesureEntity.ObservationTime)
                     ));

            }

            return measureList;

        }

        public Measure GetById(int mesureEntityId)
        {


            Measure result = null;

            try
            {
                MeasureEntity mesureEntity      = null;
                SourceEntity sourceEntity       = null;
                IndicatorEntity indicatorEntity = null;

                 mesureEntity = _measureEntityRepository.GetById(mesureEntityId);
                if(mesureEntity.IndicatorId>=0)
                    indicatorEntity = _indicatorEntityRepository.GetById(mesureEntity.IndicatorId);
                if (mesureEntity.SourceId >= 0)
                    sourceEntity = _sourceEntityRepository.GetById(mesureEntity.SourceId);

                var indicator = indicatorEntity !=null ? _mapper.Map<IndicatorEntity, Indicator>(indicatorEntity) : null;
                var source  = sourceEntity != null ? _mapper.Map<SourceEntity, Source>(sourceEntity) : null;

               result = new Measure
                    (
                    id: mesureEntity.Id,
                    indicator: indicator,
                    source:source,
                    new MeasureValue(mesureEntity.Value, mesureEntity.Unity),
                    observationTime: DateTimeConverter.ConvertToDateTimeUtc(mesureEntity.ObservationTime)
                    );
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public bool Update(Measure measure)
        {

            MeasureEntity mesureDb = new MeasureEntity()
            {
                Id = measure.Id,
                IndicatorId = measure.Indicator.Id,
                SourceId = measure.Source.Id,
                Value = measure.Value.Valeur,
                Unity = measure.Value.Unite,
                ObservationTime = DateTimeConverter.ConvertDateTimeUtcToString(measure.ObservationTime)
            };
            return _measureEntityRepository.Update(mesureDb);
        }


        public void Delete(Measure mesure)
        {
            var mesureDb = _mapper.Map<MeasureEntity>(mesure);
            var isDeleted = _measureEntityRepository.Delete(mesureDb);

        }
    }
}
