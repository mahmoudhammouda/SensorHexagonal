using Sensor.Infrastructure.Bus;
using Sensor.Infrastructure.Bus.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Impl.Bus
{
    public class SensorMessageBus : IBus<SensorMessage>
    {
        private ConcurrentQueue<SensorMessage> _queue = new ConcurrentQueue<SensorMessage>();

        public void Publish(SensorMessage item)
        {
            _queue.Enqueue(item);
        }

        public bool TryPull(out SensorMessage item)
        {
            return _queue.TryDequeue(out item);
        }

        public IEnumerable<SensorMessage> PeekAll()
        {
            // Renvoie une copie des éléments actuels dans la file d'attente
            return _queue.ToArray();
        }

        public void Subscribe(string topic, IConsumer<SensorMessage> consumer)
        {
            throw new NotImplementedException();
        }

        public void Publish(string topic, SensorMessage message)
        {
            throw new NotImplementedException();
        }
    }
}

