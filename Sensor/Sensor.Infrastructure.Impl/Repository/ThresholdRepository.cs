using AutoMapper;
using Sensor.Domain.Model;
using Sensor.Infrastructure.Repository;
using Sensor.Infrastructure.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Impl.Repository
{
    public class ThresholdRepository : IThresholdRepository
    {
        private readonly IGenericRepository<ThresholdEntity> _thresholdEntityRepository;
        private readonly IMapper _mapper;
        public ThresholdRepository(
            IGenericRepository<ThresholdEntity> genericRepository,
            IMapper mapper
            )
        {
            _thresholdEntityRepository = genericRepository??throw new ArgumentNullException(nameof(genericRepository)); 
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Add(Threshold threshold)
        {
            var dbThreshol = _mapper.Map<ThresholdEntity>(threshold);
            int newId =_thresholdEntityRepository.Add(dbThreshol);
            threshold.SetAndValidateId(newId);
        }

        public IEnumerable<Threshold> GetAll() 
        {
            var thresholdDbLst = _thresholdEntityRepository.GetAll();
            var thresholdLst = _mapper.Map<IEnumerable<ThresholdEntity>, IEnumerable<Threshold>>(thresholdDbLst);

            return thresholdLst;
        }

        public Threshold GetById(int id)
        {
            var thresholdDb = _thresholdEntityRepository.GetById(id);
            var threshold = _mapper.Map<Threshold>(thresholdDb);
            return threshold;
        }

        public bool Update(Threshold threshold)
        {
            var thresholdDb = _mapper.Map<ThresholdEntity>(threshold);
            return _thresholdEntityRepository.Update(thresholdDb);
        }

        public bool Delete(Threshold threshold)
        {
            var thresholdDb = _mapper.Map<ThresholdEntity>(threshold);
            return _thresholdEntityRepository.Delete(thresholdDb);
        }
    }
}
