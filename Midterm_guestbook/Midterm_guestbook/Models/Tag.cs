using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Midterm_guestbook.Models
{
    public class Tag
    {
        public List<Guestbook> Guestbooks;
        public SelectList Tags;

        public string GuestbookTags { get; set; }
        public string Str_search { get; set; }
    }
}
