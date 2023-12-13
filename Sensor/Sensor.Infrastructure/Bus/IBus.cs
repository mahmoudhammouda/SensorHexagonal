using Sensor.Infrastructure.Bus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Bus
{
    public interface IBus<T>
    {
        void Publish(T item);
        void Publish(string topic, SensorMessage message);
        //void Publish(DestinationTypeEnum destinationType,string topic, SensorMessage message);
        bool TryPull(out T item);

        void Subscribe(string topic, IConsumer<T> consumer);
       
        IEnumerable<T> PeekAll();
    }

}
