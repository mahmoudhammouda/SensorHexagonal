using Sensor.Infrastructure.Bus;
using Sensor.Infrastructure.Bus.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Impl.Bus
{
    public class SensorTopicBus : IBus<SensorMessage>
    {
        private readonly ConcurrentDictionary<string, ConcurrentQueue<SensorMessage>> _topicQueues;
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<IConsumer<SensorMessage>, ConcurrentQueue<SensorMessage>>> _topicsConsumersQeueues;
        

        public SensorTopicBus()
        {
            _topicQueues = new ConcurrentDictionary<string, ConcurrentQueue<SensorMessage>>();
            _topicsConsumersQeueues = new ConcurrentDictionary<string, ConcurrentDictionary<IConsumer<SensorMessage>, ConcurrentQueue<SensorMessage>>>();
        }

        public IEnumerable<SensorMessage> PeekAll()
        {
            return null;
        }

        
        public void Publish(string topic, SensorMessage message)
        {
            // if no topic found no issue, message will be lost

            if (_topicsConsumersQeueues.TryGetValue(topic, out var consumersQeueues))
            {
                foreach (var queue in consumersQeueues.Values)
                {
                    queue.Enqueue(message);
                }
            }

            // there is no consumer yet - on ne gere pas pour le moment le mode kafka
            //if (consumersQeueues == null) 
            //{
            //    // Ensure there is a queue for the topic
            //    var topicQueue = _topicQueues.GetOrAdd(topic, new ConcurrentQueue<SensorMessage>());
            //    topicQueue.Enqueue(message);
            //}

            // need to creeate the forward process

          


          
        }

        public void Publish(SensorMessage item)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(string topic, IConsumer<SensorMessage> consumer)
        {
            // check if topic name exist, if not so add (topic,dicof(consumer,conssumer)) and return dicof(consumer,message queue) else return dicof(consumer,message queue)
            var consumerQueues = _topicsConsumersQeueues.GetOrAdd(topic, _ => new ConcurrentDictionary<IConsumer<SensorMessage>, ConcurrentQueue<SensorMessage>>());

            // add the new (consumer, queue message) if not found
            consumerQueues.TryAdd(consumer, new ConcurrentQueue<SensorMessage>());

            // Start a task to process messages for this consumer
            Task.Run(() => ProcessMessages(consumer, consumerQueues[consumer]));
        }

        public bool TryPull(out SensorMessage item)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(string topic, IConsumer<SensorMessage> consumer)
        {
            if (_topicsConsumersQeueues.TryGetValue(topic, out var consumers) && consumers.TryRemove(consumer, out var queue))
            {
                // Optionally, process remaining messages or dispose of the queue
            }
        }

        /// <summary>
        /// Start task by message queue for each consumer
        /// </summary>
        /// <param name="consumer"></param>
        /// <param name="queue"></param>
        private void ProcessMessages(IConsumer<SensorMessage> consumer, ConcurrentQueue<SensorMessage> queue)
        {
            while (true) // Replace with a condition for graceful shutdown
            {
                if (queue.TryDequeue(out var message))
                {
                    consumer.ReceiveMessage(message);
                }
                else
                {
                    Task.Delay(100).Wait(); // Prevents tight looping, adjust as necessary
                }
            }
        }

       
    }
}
