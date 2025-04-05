using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Lütfen Parolanızı Giriniz!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen Parolanızı Tekrar Giriniz!")]
        public string ConfirmPassword { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != ConfirmPassword)
            {
                yield return new ValidationResult("Parolalar eşleşmiyor!", new[] { "ConfirmPassword" });
            }
        }
    }
}
