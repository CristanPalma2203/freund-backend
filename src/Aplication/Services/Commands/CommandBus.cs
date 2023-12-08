using Aplication.Dtos;

using Aplication.Services.Validations;
using Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly IEnumerable<ICommandHandler> commandHandlers;
        private readonly IValidatorService validatorService;
        private readonly ILogger<CommandBus> logger;


        public CommandBus(IEnumerable<ICommandHandler> commandHandlers, IValidatorService validatorService,
            ILogger<CommandBus> logger)
        {
            this.commandHandlers = commandHandlers;
            this.validatorService = validatorService;
            this.logger = logger;

        }
        public IResponse execute(IMessage comando)
        {

            validatorService.AplicarValidador(comando);
            var instance = commandHandlers.FirstOrDefault(c => c.GetType().Name == comando.GetType().Name + "Handler");

            if (instance == null)
            {
                throw new NotImplementedException("Handler no implementado para el mensaje: " + comando.GetType().Name);
            }


            return instance.ejecutar(comando);
        }

      

    }
}
