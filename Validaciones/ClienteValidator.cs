using EstacionamientoMedido.Modelos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Validaciones
{
    internal class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nombre)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(x => x.Apellido)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);
            RuleFor(x => x.DNI)
                .NotNull()
                .NotEmpty()
                .MinimumLength(7);
            RuleFor(x => x.Telefono)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10);
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

        }
        
    }
}
