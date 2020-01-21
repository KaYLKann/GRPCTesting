using System;
using System.Threading.Tasks;
using Calculator;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcService {
    public class CalcService :  Calculate.CalculateBase {
        private readonly ILogger<CalcService> _logger;
        private readonly IExponentiationOperation<double> _exponentiationOperation;

        public CalcService(ILogger<CalcService> logger, IExponentiationOperation<double> exponentiationOperation) {
            _logger = logger;
            _exponentiationOperation = exponentiationOperation;
        }

        public override async Task<ExponentiationResult> Exec(ExponentiationRequest request, ServerCallContext context)
        {
            try {
                if (request.Value < 1 ) throw new ArgumentException($"value cannot be less 1");
                if (request.Value > 50 ) throw new ArgumentException($"value cannot be more 100");
                if ((request.Value % 2) == 0) throw new ArgumentException($"value cannot be {request.Value}");
                
                if (request.Operation == ExponentiationRequest.Types.Op.Square) {
                    return new ExponentiationResult( _exponentiationOperation.Calculate(request.Value, 3));
                }
            
                throw new Exception("Operation is not exist");
            }
            catch (Exception ex) {
                _logger.LogError(ex, "{@request}", request);
                throw;
            }
        }
    }
}