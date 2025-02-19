using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class ResisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public ResisterUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("O nome é obrigatório");
            RuleFor(request => request.Email).EmailAddress().NotEmpty().WithMessage("O email não é valido");
            RuleFor(request => request.Password).NotEmpty().WithMessage("A senha é obrigatória");
            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request => request.Password).MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres");
            });
        }
    }
}
