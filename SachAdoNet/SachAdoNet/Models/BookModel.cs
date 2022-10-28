using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SachAdoNet.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Không được để trống")]
        public string Title { get; set; }
    }
}