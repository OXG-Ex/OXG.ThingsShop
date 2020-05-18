using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OXG.ThingsShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Намименование")]
        public string Name { get; set; }//Наименование

        [Required]
        [Display(Name = "Стоимость")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }//Стоимость

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }//Описание, необязательное поле

        [Display(Name = "Производитель")]
        public string Manufacturer { get; set; }//Производитель, Необязательное поле

        [Display(Name = "Цвет")]
        public string Color { get; set; }//Цвет, Необязательное поле

        [Display(Name = "Кол-во")]
        public int Count { get; set; }//Кол-во, Необязательное поле

        [Display(Name = "Год выпуска")]
        public string Year { get; set; }//Год выпуска, Необязательное поле
    }
}
