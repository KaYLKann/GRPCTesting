using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcService;

namespace GrpcClient {
    public class CalculatorHandler {
        public const string CubeConstant ="cube";
        public const string SquareConstant ="square";
        public static async Task Handle(string command, int value) {
            if (value < 1 ) {
                throw new ArgumentException($"значение не может быть меньше 1");
            }
            
            if (value > 100 ) {
                throw new ArgumentException($"значение не может быть больше 100");
            }
            
            switch (command) {
                case CubeConstant:
                    Console.WriteLine($"результат: {Math.Pow(value, 2)}");
                    break;
                
                case SquareConstant:
                    var result = await GrpcSquareRequestAsync();
                    Console.WriteLine($"результат: {result}");
                    break;
                
                default: Console.WriteLine($"неизвестная команда {command}");
                    break;
            }
        }

        private static async Task<double> GrpcSquareRequestAsync() {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Calculate.CalculateClient(channel);
            var result =  await client.ExecAsync(new ExponentiationRequest(ExponentiationRequest.Types.Op.Square, 3));
            return result.Result;
        }
    }
}