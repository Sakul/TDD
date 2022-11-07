using MockObject.Shared.Models;
using MockObject.Shared.Services;

namespace MockObject.Shared
{
    public class Calculator
    {
        public ICalculationService CalculationService { get; set; }

        public CalculationResponse Add(int addend1, int addend2)
        {
            var req = new CalculationRequest
            {
                Operator = "+",
                Operand1 = addend1,
                Operand2 = addend2,
            };
            return CalculationService.SendRequest(req);
        }

        public CalculationResponse Subtract(int minuend, int subtrahend)
            => throw new NotImplementedException();

        public CalculationResponse Multiply(int multiplicand, int multiplier)
            => throw new NotImplementedException();

        public CalculationResponse Divide(int dividend, int divisor)
            => throw new NotImplementedException();
    }
}
