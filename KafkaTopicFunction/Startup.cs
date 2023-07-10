using KafkaTopicFunction.Abstraction;
using KafkaTopicFunction.Implementation;
using KafkaTopicFunction.Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KafkaTopicFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IKafkaTopicConsumer>(sp => new KafkaClientConsumer("your_bootstrap_servers", "consumerGroup"));
            builder.Services.AddSingleton<IKafkaTopicProducer>(sp => new KafkaClientProducer("your_bootstrap_servers"));

            builder.Services.AddSingleton<IApiRepository, ApiRepository>();

            builder.Services.AddHttpClient();

            // Add configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddSingleton<IConfiguration>(configuration);
        }
    }
}
