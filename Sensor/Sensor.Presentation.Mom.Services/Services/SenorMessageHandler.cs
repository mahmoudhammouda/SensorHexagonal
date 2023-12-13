using Sensor.Infrastructure.Bus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Sensor.Domain.Services;
using Sensor.Domain.Model;

namespace Sensor.Presentation.Mom.Services.Services
{
    public class SenorMessageHandler : IMessageHandler
    {
        private readonly IMeasureService _measureService;
        private readonly IStateService _stateService;


        public SenorMessageHandler(IMeasureService measureService, IStateService stateService) 
        {
            _measureService = measureService?? throw new ArgumentNullException(nameof(measureService));
            _stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
        }

        public SenorMessageHandler(IMeasureService measureService)
        {
            _measureService = measureService ?? throw new ArgumentNullException(nameof(measureService));
            _stateService = null;
        }
        public void HandleMessage(SensorMessage message)
        {
            try 
            {
                HandleTemperatureMessage(message);

            }
            catch(Exception e)
            { 

                throw;
            }
        }

        public void HandleTemperatureMessage(SensorMessage message)
        {
            try
            {
                if (message != null
                    && !string.IsNullOrEmpty(message.SensorName)
                    && message.ObservationTime.Kind == DateTimeKind.Utc
                    )
                {

                    Indicator indic = new Indicator(
                    0,
                    "Temperature",
                    "Mesure le degre de chaleur ou de froid. Indispensable pour evaluer les conditions climatiques et environnementales",
                    "Chaleur",
                    Domain.Enum.ValueTypeEnum.Numeric
                    );

                    Source s = new Source(
                        0,
                        "Pioneer2",
                        Domain.Enum.SourceTypeEnum.Sensor
                        );

                    Measure measure = new Measure(
                        -1,
                        indic,
                        s,
                        new MeasureValue(message.Temperature.ToString(), "Celsius"),
                        message.ObservationTime
                        );
                    
                    if(_stateService!= null)
                        _stateService.UpdateOrCreateState(s.Id,indic.Id, (int)message.Temperature);

                    _measureService.AddMeasure(measure);
                }


            }
            catch (Exception e)
            {
                // issue done willl processing message
                throw;
            }
        }
    }
}
