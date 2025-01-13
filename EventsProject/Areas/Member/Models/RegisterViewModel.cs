using System.ComponentModel.DataAnnotations;

namespace EventsProject.Areas.Member.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Ad Soyad gereklidir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad gereklidir.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı gereklidir.")]

        public string Username { get; set; }

        [Required(ErrorMessage = "Email gereklidir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu degil")]
        public string ConfirmPassword { get; set; }




    }
}