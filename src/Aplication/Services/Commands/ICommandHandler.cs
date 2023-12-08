using Aplication.Dtos;
using Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Commands
{
    public interface ICommandHandler<T> : ICommandHandler where T : IMessage
    {
        IResponse Handle(T message);
    }

    public interface ICommandHandler
    {
        IResponse ejecutar(IMessage message);
    }

}
