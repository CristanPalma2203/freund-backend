using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Validations
{
    public interface IValidatorService
    {
        void AplicarValidador(IMessage message);
    }
}
