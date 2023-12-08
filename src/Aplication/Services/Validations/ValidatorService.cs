using Aplication.Validators;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Validations
{
    public class ValidatorService : IValidatorService
    {
        private readonly IEnumerable<IValidador> validadors;

        public ValidatorService(IEnumerable<IValidador> validadors)
        {
            this.validadors = validadors;
        }
        public void AplicarValidador(IMessage message)
        {
            var instace = validadors.FirstOrDefault(c => c.GetType().Name == message.GetType().Name + "Validator");
            if (instace == null)
            {
                throw new NotImplementedException("Validaciones no creadas para el comando: " + message.GetType().Name);
            }
            instace.Validar(message);
        }
    }
}
