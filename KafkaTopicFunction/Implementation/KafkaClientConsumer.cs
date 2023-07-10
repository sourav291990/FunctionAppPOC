using Confluent.Kafka;
using KafkaTopicFunction.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaTopicFunction.Implementation
{
    public class KafkaClientConsumer : IKafkaTopicConsumer
    {
        private readonly ConsumerConfig _consumerConfig;
        public KafkaClientConsumer(string bootstrapServers, string consumerGroup)
        {
            _consumerConfig = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = consumerGroup,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }
        public void ConsumeMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
