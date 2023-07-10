using KafkaTopicFunction;
using KafkaTopicFunction.Abstraction;
using KafkaTopicFunction.Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(Startup))]

namespace KafkaTopicFunction
{
    public class KafkaFunction
    {
        private readonly IKafkaTopicConsumer _consumer;
        private readonly IKafkaTopicProducer _producer;
        private readonly IApiRepository _apiRepository;

        public KafkaFunction(IKafkaTopicConsumer consumer, IKafkaTopicProducer producer, IApiRepository apiRepository)
        {
            _consumer = consumer;
            _producer = producer;
            _apiRepository = apiRepository;
        }

        // KafkaTrigger sample 
        // Consume the message from "my-topic" on the LocalBroker.
        // Add `BrokerList` and `KafkaPassword` to the local.settings.json
        // For EventHubs
        // "BrokerList": "{EVENT_HUBS_NAMESPACE}.servicebus.windows.net:9093"
        // "KafkaPassword":"{EVENT_HUBS_CONNECTION_STRING}
        [FunctionName("KafkaFunction")]
        public async Task RunAsync(
            [KafkaTrigger("BrokerList",
                          "my-topic",
                          Username = "$ConnectionString",
                          Password = "%KafkaPassword%",
                          Protocol = BrokerProtocol.SaslSsl,
                          AuthenticationMode = BrokerAuthenticationMode.Plain,
                          ConsumerGroup = "$Default")] KafkaEventData<string>[] events,
            ILogger logger)
        {
            foreach (KafkaEventData<string> eventData in events)
            {
                string message = eventData.Value;
                // Consume the Kafka message
                _consumer.ConsumeMessage(message);

                // Post the event to the REST API
                await _apiRepository.PostEventAsync(message);

                logger.LogInformation("Function execution completed.");
            }
        }
    }
}
