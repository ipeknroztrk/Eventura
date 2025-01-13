using System.ComponentModel.DataAnnotations;

namespace EventsProject.Areas.Member.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı gereklidir.")]
        public string Username { get; set; }
    }
}