using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name ="Введите имя")]
        [StringLength(10)]
        [Required(ErrorMessage ="Поле не заполнено")]
        public string name { get; set; }
        [Display(Name = "Введите фамилию")]
        [StringLength(10)]
        [Required(ErrorMessage = "Поле не заполнено")]
        public string surname { get; set; }
        [Display(Name = "Введите номер")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Поле не заполнено")]
        public string phone { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public  DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
