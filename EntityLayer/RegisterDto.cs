using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public record RegisterDto
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adı giriniz!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen E-Posta giriniz!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen şifre giriniz!")]
        public string Password { get; set; }
    }
}
