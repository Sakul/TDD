using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockObject.Shared.Models
{
    public class CalculationResponse
    {
        public int Result { get; set; }
        public string ErrorMessage { get; set; }
        public CalculationRequest Request { get; set; }
    }
}
