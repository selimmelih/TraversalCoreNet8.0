using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage ="Lütfen Adınızı Giriniz!")]
        public string? Name { get; set; }

		[Required(ErrorMessage ="Lütfen Soyadınızı Giriniz!")]
        public string? Surname { get; set; }

		[Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz!")]
        public string? Username { get; set; }

		[Required(ErrorMessage ="Lütfen Mail Adresinizi Giriniz!")]
        public string? Mail { get; set; }

		[Required(ErrorMessage = "Lütfen Parolanızı Giriniz!")]
        public string? Password { get; set; }

		[Required(ErrorMessage = "Lütfen Parolanızı Tekrar Giriniz!")]
		[Compare("Password",ErrorMessage ="Parolalar Uyumlu Değil!")]
        public string? ConfirmPassword { get; set; }

    }
}
