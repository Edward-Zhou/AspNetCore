using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientClient.HttpClients
{
    public class SomeClient:ISomeClient
    {
        public SomeClient(HttpClient httpClient ,CancellationTokenSource cancellationToken)
        {

        }
    }

    public interface ISomeClient
    {

    }
}
