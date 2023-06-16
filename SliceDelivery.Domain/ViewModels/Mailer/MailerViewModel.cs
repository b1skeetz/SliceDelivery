using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceDelivery.Domain.ViewModels.Mailer
{
    public class MailerViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }
        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите почту")]
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Укажите номер телефона")]
        [Display(Name = "Номер телефона")]
        public string Number { get; set; }
    }
}
