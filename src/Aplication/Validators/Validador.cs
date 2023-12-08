
using Aplication.Services.Validations;
using Domain.Exceptions;

using Domain.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace Aplication.Validators
{
    public abstract class Validador<T> : AbstractValidator<T>, IValidador
    {

        public Validador()
        {
            
        }
        public abstract IList<string> Permisos { get; }

        public void Validar(IMessage comando)
        {
            ValidarComando(comando);
        }

        public void ValidarComando(IMessage comando)
        {
            var reult = Validate((T)comando);
            if (!reult.IsValid)
            {
                var errores = new List<string>();
                foreach (var failure in reult.Errors)
                {
                    errores.Add(HttpUtility.HtmlAttributeEncode(failure.ErrorMessage));
                };
                if (errores.Count > 0) throw new HttpException(422, JsonConvert.SerializeObject(errores));
            }
        }

       
    }
}
