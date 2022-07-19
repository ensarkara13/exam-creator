using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.ViewModels
{
  public class RegisterViewModel
  {
    [Required(ErrorMessage = "*İsim alanı boş bırakılamaz.")]
    [RegularExpression(@"^[A-Za-zşğİüçöÖÜĞ ]+$", ErrorMessage = "İsim sadece harflerden oluşabilir.")]
    [MinLength(8, ErrorMessage = "*İsim en az 2 karakterden oluşmalıdır.")]
    [MaxLength(20, ErrorMessage = "*İsim en fazla 20 karakterden oluşmalıdır.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "*Soyisim alanı boş bırakılamaz.")]
    [RegularExpression(@"^[A-Za-zşğİüçöÖÜĞ ]+$", ErrorMessage = "Soyisim sadece harflerden oluşabilir.")]
    [MinLength(8, ErrorMessage = "*Soyisim en az 8 karakterden oluşmalıdır.")]
    [MaxLength(20, ErrorMessage = "*Soyisim en fazla 20 karakterden oluşmalıdır.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "*Email alanı boş bırakılamaz.")]
    [EmailAddress(ErrorMessage = "*Geçerli bir email giriniz.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "*Şifre alanı boş bırakılamaz.")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "*Şifre en az 8 karakterden oluşmalıdır.")]
    [MaxLength(20, ErrorMessage = "*Şifre en fazla 20 karakterden oluşmalıdır.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "*Şifre tekrar alanı boş bırakılamaz.")]
    [Compare(nameof(Password), ErrorMessage = "Şifreler uyuşmuyor.")]
    [DataType(DataType.Password)]
    public string PasswordConfirm { get; set; }
  }
}