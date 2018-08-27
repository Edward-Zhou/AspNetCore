using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationPro.Models
{
    public class Command  //: IRequest<AcceptCostEstimateResponse>
    {
        public Command()
        {
            Estimate = new EstimateDTO();
            ClientHeader = new ClientHeaderDTO();
        }
        public EstimateDTO Estimate { get; set; }
        public ClientHeaderDTO ClientHeader { get; set; }
    }
}
