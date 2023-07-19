using FluentValidation;
using OnionProject.WebMvc.Models.Account;

namespace OnionProject.WebMvc.Validators
{
    public class LoginValidator:AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(r => r.Username)
                .NotEmpty()
                .WithMessage("Lütfen Kullanıcı Adını Giriniz");

            RuleFor(r => r.Password).NotEmpty().WithMessage("Lütfen Şifrenizi Giriniz");
        }
    }
}
