using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceDelivery.Domain.Enum
{
    public enum ProductType
    {
        [Display(Name = "Бургеры")]
        BurgerProd = 0,
        [Display(Name = "Пицца")]
        PizzaProd = 1
    }
}
