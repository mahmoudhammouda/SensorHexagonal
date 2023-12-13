using Sensor.Domain.Const;
using Sensor.Domain.Model;
using Sensor.Domain.Services;
using Sensor.Infrastructure.Cache;
using Sensor.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Impl.Services
{
    public class ThresholdService : IThresholdService
    {
        private readonly IThresholdRepository _thresholdRepository;
        private readonly ICache _cache;

        public ThresholdService(
            ICache cache,
            IThresholdRepository thresholdRepository)
        {
            _thresholdRepository = thresholdRepository ?? throw new ArgumentNullException(nameof(thresholdRepository));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache)); ;
        }

        public void AddThreshold(Threshold threshold)
        {
            if (CheckIfThresholdExists(threshold.IndicatorId, threshold.SourceId))
            {
                throw new InvalidOperationException("Only one thresold should be created for indicatorId,sourceId.");
            }

            _thresholdRepository.Add(threshold);
            // Mise à jour du cache si nécessaire
            var key = CacheKey.GenCacheKey("Threshold", threshold.Id);
            _cache.Set(key, threshold);

        }

        public IEnumerable<Threshold> GetAllThreshold()
        {
            return _thresholdRepository.GetAll();
        }

        public Threshold GetThreshold(int id)
        {

            try  
            {
                var key = CacheKey.GenCacheKey("Threshold", id);
                var threshold = _cache.Get<Threshold>(key);
                // If data not exist from cache we will get it from database 
                if (threshold == null) 
                {
                    threshold = _thresholdRepository.GetById(id);
                    if (threshold != null) 
                    {
                        _cache.Set(key, threshold);
                    }
                }

                return threshold;
            }
            catch(Exception e)
            {
                throw;
            }

        }

        public void UpdateThreshold(Threshold threshold)
        {
            _thresholdRepository.Update(threshold);
            var key = CacheKey.GenCacheKey("Threshold", threshold.Id);
            _cache.Set(key, threshold);
        }

        public void DeleteThreshold(Threshold threshold)
        {
            _thresholdRepository.Delete(threshold);
            var key = CacheKey.GenCacheKey("Threshold", threshold.Id);
            _cache.Remove(key); 
        }

        private bool CheckIfThresholdExists(int indicatorId, int sourceId)
        {
            var allThresholds = _thresholdRepository.GetAll();
            return allThresholds.Any(t => t.IndicatorId == indicatorId && t.SourceId == sourceId);
        }

        public IEnumerable<Threshold> FindBySourceId(int sourceId)
        {
           return _thresholdRepository.GetAll().Where(item => item.SourceId == sourceId);
        }

        public Threshold FindBySourceIdAndIndicatorId(int sourceId, int indicatorId)
        {
            return _thresholdRepository.GetAll().Where(item => item.SourceId == sourceId && item.IndicatorId == indicatorId).FirstOrDefault(); ;
        }
    }
}
