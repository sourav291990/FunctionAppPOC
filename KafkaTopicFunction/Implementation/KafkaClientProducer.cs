using Confluent.Kafka;
using KafkaTopicFunction.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaTopicFunction.Implementation
{
    public class KafkaClientProducer : IKafkaTopicProducer
    {
        private readonly ProducerConfig _producerConfig;

        public KafkaClientProducer(string bootstrapServers)
        {
            _producerConfig = new ProducerConfig
            {
                BootstrapServers = bootstrapServers
            };
        }
        public void ProduceMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
