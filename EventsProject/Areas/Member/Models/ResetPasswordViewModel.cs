using System.ComponentModel.DataAnnotations;

namespace EventsProject.Areas.Member.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı gereklidir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Yeni şifre gereklidir.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Şifre doğrulama gereklidir.")]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}