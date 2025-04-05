using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Lütfen Üyeliğe Ait Mail Adresinizi Giriniz!")]
        public string Mail { get; set; }
    }
}
