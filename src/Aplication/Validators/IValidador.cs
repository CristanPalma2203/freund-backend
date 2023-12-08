using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validators
{
    public interface IValidador
    {

        void ValidarComando(IMessage comando);
        void Validar(IMessage comando);

    }
}
