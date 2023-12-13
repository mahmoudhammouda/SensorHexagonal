using Sensor.Infrastructure.Bus;
using Sensor.Infrastructure.Bus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sensor.Infrastructure.Impl.Bus
{
    public class SensorConsumer : IConsumer<SensorMessage>
    {
        private readonly string _name;
        private readonly IMessageHandler _messageHandler;

        public SensorConsumer(string name, IMessageHandler messageHandler)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name)); ;
            _messageHandler= messageHandler?? throw new ArgumentNullException(nameof(messageHandler));
        }

        public void ReceiveMessage(SensorMessage data)
        {
            Debug.WriteLine("Consumer :" + _name + " received message");
            _messageHandler.HandleMessage(data);
        }

    }
}
