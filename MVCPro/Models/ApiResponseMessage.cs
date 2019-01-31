using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCPro.Models
{
    public class ApiResponseMessage
    {
        //
        // Summary:
        //     Gets or sets the reason phrase which typically is sent by servers together with
        //     the status code.
        //
        // Returns:
        //     The reason phrase sent by the server.
        public string ReasonPhrase { get; set; }
        //
        // Summary:
        //     Gets or sets the status code of the HTTP response.
        //
        // Returns:
        //     The status code of the HTTP response.
        public HttpStatusCode StatusCode { get; set; }
        //
        // Summary:
        //     Gets or sets the content of a HTTP response message.
        //
        // Returns:
        //     The content of the HTTP response message.
        public object Content { get; set; }

    }
}
