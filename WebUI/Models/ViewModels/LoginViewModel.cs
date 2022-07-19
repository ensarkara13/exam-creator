using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.ViewModels
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "*Email alanı boş bırakılamaz.")]
    [EmailAddress(ErrorMessage = "*Geçerli bir email giriniz.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "*Şifre alanı boş bırakılamaz.")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "*Şifre en az 8 karakterden oluşmalıdır.")]
    [MaxLength(20, ErrorMessage = "*Şifre en fazla 20 karakterden oluşmalıdır.")]
    public string Password { get; set; }
  }
}