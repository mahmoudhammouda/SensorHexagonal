using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Bus.Model
{
    public interface IMessageHandler
    {
        void HandleMessage(SensorMessage message);
    }
}
