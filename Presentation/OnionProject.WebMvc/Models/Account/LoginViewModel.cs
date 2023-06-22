using System.ComponentModel.DataAnnotations;

namespace OnionProject.WebMvc.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }
    }
}
