using Sensor.Domain.Const;
using Sensor.Domain.Exceptions;
using Sensor.Domain.Model;
using Sensor.Domain.Services;
using Sensor.Infrastructure.Cache;
using Sensor.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Impl.Services
{

    public class StateService : IStateService
    {
        private readonly ICache _cache;
        private readonly IThresholdService _thresholdService;

        public StateService(
            ICache cache,
            IThresholdService thresholdService
            )
        {
             _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _thresholdService = thresholdService ?? throw new ArgumentNullException(nameof(thresholdService));  

        }


       public void UpdateOrCreateState(int sourceId, int indicatorId,int value) 
        {
            try
            {
                var threshold = _thresholdService.FindBySourceIdAndIndicatorId(sourceId, indicatorId);

                if (threshold == null)
                {
                    throw new InvalidOperationException("Aucun seuil trouvé pour les identifiants fournis.");
                }

                string label = "";

                if (value < threshold.MinValue)
                {
                    label = "COLD";
                }
                else if (value > threshold.MaxValue)
                {
                    label = "HOT";
                }
                else
                {
                    label = "WARM";
                }

                TemperatureState temperaturState = new TemperatureState()
                {
                    SourceId = sourceId,
                    IndicatorId = indicatorId,
                    Value = label
                };


                string cacheKey = $"SourceId_{sourceId}_IndicatorId_{indicatorId}";
                _cache.Set(cacheKey, temperaturState);

            }
            catch
            {
                throw;
            }
           


        }


        public State GetState(int sourceId,int indicatorId)
        {
            try  
            {
                string cacheKey = $"SourceId_{sourceId}_IndicatorId_{indicatorId}";

                var state = _cache.Get<TemperatureState>(cacheKey);
                if (state == null)
                    throw new StateDomainException(cacheKey);
                return state;
            }
            catch (Exception e)
            {
                throw;
            }

        }





    }
}
