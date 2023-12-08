using Aplication.Dtos;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Commands
{
    public interface ICommandBus
    {
        IResponse execute(IMessage comando);
    }
}
