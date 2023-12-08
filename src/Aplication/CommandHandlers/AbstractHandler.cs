using Aplication.Dtos;
using Aplication.Services.Commands;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.CommandHandlers
{
    public abstract class AbstractHandler<T> : ICommandHandler<T> where T : IMessage
    {
        public abstract IResponse Handle(T message);


        public IResponse ejecutar(IMessage message)
        {
            return Handle((T)message);
        }
    }
}
