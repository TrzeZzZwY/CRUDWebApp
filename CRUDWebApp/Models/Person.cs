using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CRUDWebApp.Models
{
    public class Person
    {
        [HiddenInput]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Podaj imię")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj nazwisko")]
        public string Surename { get; set; }
        [Required(ErrorMessage = "Podaj datę urodzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birth { get; set; }
    }
}
