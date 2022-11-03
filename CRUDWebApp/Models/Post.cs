using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CRUDWebApp.Models
{
    public class Post
    {
        [HiddenInput]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Podaj tytuł")]
        public string Title { get; set; }
        [HiddenInput]
        public byte[] Image { get; set; }
        public string Description { get; set; }

    }
}
