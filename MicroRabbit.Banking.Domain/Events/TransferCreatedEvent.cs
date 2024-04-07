using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Domain.Events
{
    public class TransferCreatedEvent(int from, int to, decimal amount):Event
    {
        public int From { get; private set; } = from;
        public int To { get; private set; } = to;
        public decimal Amount { get; private set; } = amount;
    }
}
