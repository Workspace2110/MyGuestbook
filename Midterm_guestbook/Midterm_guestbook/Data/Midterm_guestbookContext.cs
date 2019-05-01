using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Midterm_guestbook.Models
{
    public class Midterm_guestbookContext : DbContext
    {
        public Midterm_guestbookContext (DbContextOptions<Midterm_guestbookContext> options)
            : base(options)
        {
        }

        public DbSet<Midterm_guestbook.Models.Guestbook> Guestbook { get; set; }
    }
}
