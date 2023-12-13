using Microsoft.AspNetCore.Mvc;
using Sensor.Infrastructure.Bus;
using Sensor.Infrastructure.Bus.Model;

namespace Sensor.Presentation.Rest.Services
{


    [ApiController]
    [Route("api/[controller]")]
    public class BusController : ControllerBase
    {

        private readonly IBus<SensorMessage> _bus ;

        public BusController(IBus<SensorMessage> bus)
        {
           _bus= bus?? throw new ArgumentNullException(nameof(bus));
        }

        [HttpGet]
        public IEnumerable<double> Get()
        {
            return _bus.PeekAll().Select(item => item.Temperature);
            
        }
    }
}
