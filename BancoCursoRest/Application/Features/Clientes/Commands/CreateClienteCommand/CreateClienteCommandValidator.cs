using FluentValidation;

namespace Application.Features.Clientes.Commands.CreateClienteCommand
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(x => x.FechaNacimiento)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacía");

            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                .Matches(@"^\d{4}-\d{4}$").WithMessage("{PropertyName} debe cumplir el formato 0000-0000")
                .MaximumLength(9).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                .EmailAddress().WithMessage("{PropertyName} debe ser una dirección de email válida")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(x => x.Direccion)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}