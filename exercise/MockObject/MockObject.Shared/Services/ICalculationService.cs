using MockObject.Shared.Models;

namespace MockObject.Shared.Services
{
    public interface ICalculationService
    {
        CalculationResponse SendRequest(CalculationRequest request);
    }
}