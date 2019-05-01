using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Midterm_guestbook.Models
{
    public class Guestbook
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "標題")]
        public string Title { get; set; }

        [Display(Name = "標籤")]
        public string Tag { get; set; }

        [Required, Display(Name = "內容")]
        public string Comment { get; set; }

        [Required, Display(Name = "日期"), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true), DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
