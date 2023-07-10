using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaTopicFunction.Abstraction
{
    public interface IKafkaTopicProducer
    {
        void ProduceMessage(string message);
    }
}
