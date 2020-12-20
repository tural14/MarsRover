using MarsRover.Application.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Threading;
using log4net;
using MarsRover.Application.Common;

namespace MarsRover.Application
{
    class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((hostingContext, services) =>
               {
                   services.AddMediatR(Assembly.GetExecutingAssembly());
                   services.AddSingleton<IHostedService, ConsoleApp>();
               });

        static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);

            await hostBuilder.RunConsoleAsync();
        }
    }
    public class ConsoleApp : IHostedService
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IServiceScopeFactory _serviceScopeFactory;
        public ConsoleApp(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var commandList = new List<IRequest>();
            logger.Info("Application Started");
            try
            {
                #region Plateau Info

                Console.WriteLine("Enter The Plateau width and height");
                string plateauInput = Console.ReadLine().Trim();


                #endregion

                int marsRover = 1;

                while (true)
                {
                    commandList.Add(new CommandConverter().GetCommand(0, plateauInput.ToString()));

                    #region Rover Info

                    Console.WriteLine("Enter The Rover info. Example 3 3 N");
                    string roverInput = Console.ReadLine().Trim();
                    commandList.Add(new CommandConverter().GetCommand(marsRover, roverInput.ToString()));

                    #endregion

                    #region Command Info

                    Console.WriteLine("Enter The Command info. Example LMLMLMLMM");
                    string commandInput = Console.ReadLine().Trim();
                    foreach (var command in commandInput.ToCharArray())
                    {
                        commandList.Add(new CommandConverter().GetCommand(marsRover, command.ToString()));
                    }

                    #endregion

                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                        foreach (var command in commandList)
                        {
                            await _mediator.Send(command);
                        }
                    }

                    marsRover++;
                    commandList.Clear();
                    Console.WriteLine("Enter The New Rover info Y/N");
                    string startRover = Console.ReadLine().Trim();

                    if (startRover == "N")
                    {
                        break;
                    }

                }
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                    var rovers = await _mediator.Send(new GetAllRoverQuery());

                    foreach (var rover in rovers)
                    {
                        Console.WriteLine("Output :" + rover.X + " " + rover.Y + " " + rover.Direction);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"There was an error." + ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Application shut down");
        }
    }
}