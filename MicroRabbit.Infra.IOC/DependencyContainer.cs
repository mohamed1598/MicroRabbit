using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddTransient<BankingDbContext>();
            //services.AddTransient<TransferDbContext>();

            //domain bus
            Assembly handlerAssembly = typeof(TransferCommandHandler).Assembly;
            services.AddTransient<TransferCommandHandler, TransferCommandHandler>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(handlerAssembly));
            services.AddTransient<IEventBus, RabbitMQBus>();

            //domain banking commands 
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
            //domain events
            services.AddTransient<IEventHandler<Transfer.Domain.Events.TransferCreatedEvent>,TransferEventHandler>();
        }
    }
}
