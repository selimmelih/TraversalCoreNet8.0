﻿using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz.")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen Parolanızı Giriniz.")]
        public string password { get; set; }

    }
}
