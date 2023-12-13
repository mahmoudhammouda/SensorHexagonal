using AutoMapper;
using Sensor.CrossCutting;
using Sensor.Domain.Model;
using Sensor.Infrastructure.Repository;
using Sensor.Infrastructure.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Impl.Repository
{
    public class SourceRepository : ISourceRepository
    {
        private readonly IGenericRepository<SourceEntity> _sourceEntityRepository;

        private readonly IMapper _mapper;
        public SourceRepository(
            IGenericRepository<SourceEntity> sourceEntityRepository,
            IMapper mapper
            )
        {
            _sourceEntityRepository = sourceEntityRepository ?? throw new ArgumentNullException(nameof(sourceEntityRepository));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        public int Add(Source source)
        {

            try
            {
                var dbItem = _mapper.Map<SourceEntity>(source);
                var newId = _sourceEntityRepository.Add(dbItem);
                source.SetAndValidateId(newId);
                return newId;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public Source GetById(int id)
        {
            Source result = null;

            try
            {
                SourceEntity dbItem = _sourceEntityRepository.GetById(id);
                var source  = dbItem != null ? _mapper.Map<SourceEntity, Source>(dbItem) : null;
                result = source;
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public bool Update(Source source)
        {
            try
            {
                var dbItem = _mapper.Map<SourceEntity>(source);
                return _sourceEntityRepository.Update(dbItem);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
