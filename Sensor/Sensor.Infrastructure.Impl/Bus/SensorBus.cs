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
    public class SensorBus : IBus<string>
    {
        private ConcurrentQueue<string> _queue = new ConcurrentQueue<string>();

        public void Publish(string item)
        {
            _queue.Enqueue(item);
        }

        public bool TryPull(out string item)
        {
            return _queue.TryDequeue(out item);
        }

        public IEnumerable<string> PeekAll()
        {
            // Renvoie une copie des éléments actuels dans la file d'attente
            return _queue.ToArray();
        }

        public void Subscribe(string topic, IConsumer<string> consumer)
        {
            throw new NotImplementedException();
        }

        public void Publish(string topic, SensorMessage message)
        {
            throw new NotImplementedException();
        }
    }
}

