using System;
using System.Threading.Tasks;


namespace GrpcClient {
    class Program {
        private const string ExitCommand = "exit";
        static async Task Main(string[] args) {
            var loop = true;
            Console.WriteLine();
            Console.WriteLine($"Введите команду и значение. Формат [cube/square] [value]");
            Console.WriteLine($"Введите {ExitCommand} для выхода");
            do {
                try {
                    Console.WriteLine();
                    var readUserCommand = Console.ReadLine();
                    if (readUserCommand == ExitCommand) {
                        loop = false;
                        break;
                    }
                    var parsedResult    = readUserCommand.Split(" ");
                
                    await CalculatorHandler.Handle(parsedResult[0], int.Parse(parsedResult[1]));
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message + " " + ex.StackTrace);
                }
            }
            while (loop);
        }
    }
}