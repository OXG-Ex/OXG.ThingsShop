using Microsoft.AspNetCore.Mvc;
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

        [Required(ErrorMessage ="Это поле обязательно для заполнения")]
        [Display(Name = "Намименование")]
        public string Name { get; set; }//Наименование

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Количество в упаковке")]
        [Range(0, 999, ErrorMessage = "Значение не может быть меньше 0 и больше 999")]
        public int? Count { get; set; }//Кол-во

        [Required(ErrorMessage ="Это поле обязательно для заполнения")]
        [Display(Name = "Стоимость")]
        [DataType(DataType.Currency, ErrorMessage = "Это поле обязательно для заполнения")]
        public decimal? Price { get; set; }//Стоимость

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }//Описание, необязательное поле

        [Display(Name = "Производитель")]
        public string? Manufacturer { get; set; }//Производитель, Необязательное поле

        [Display(Name = "Цвет")]
        public string? Color { get; set; }//Цвет, Необязательное поле

        [Display(Name = "Год выпуска")]
        [Range(1960, 2020, ErrorMessage = "Значение не может быть меньше 1960 и больше 2020")]
        public int? Year { get; set; }//Год выпуска, Необязательное поле
    }
}
