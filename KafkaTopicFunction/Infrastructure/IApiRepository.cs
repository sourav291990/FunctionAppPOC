using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaTopicFunction.Infrastructure
{
    public  interface IApiRepository
    {
        Task PostEventAsync(string message);
    }
}
