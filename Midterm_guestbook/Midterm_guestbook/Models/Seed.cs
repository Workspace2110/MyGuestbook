using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Midterm_guestbook.Models
{
    public static class Seed
    {
        public static void Initalize(Midterm_guestbookContext context)
        {
            context.Database.EnsureCreated();

            if (context.Guestbook.Count() == 0)
            {
                var data = new Guestbook[]
                {
                    new Guestbook
                    {
                        Title = "C",
                        Tag = "Program",
                        Date = DateTime.Parse("2019/4/3").Date,
                        Comment =
                        "#include <stdio.h>\n"+
                        "int main(void){\n"+
                        "   printf(\"hello, world\\n\");\n"+
                        "}",
                    },
                    new Guestbook
                    {
                        Title = "C++",
                        Tag = "Program",
                        Date = DateTime.Parse("2019/4/4").Date,
                        Comment =
                        "#include <iostream>\n"+
                        "int main(){\n"+
                        "   std::out<<\"hello, world\\n\";\n"+
                        "}",
                    },
                    new Guestbook
                    {
                        Title = "C#",
                        Tag = "Program",
                        Date = DateTime.Parse("2019/4/5").Date,
                        Comment =
                        "using System;\n"+
                        "namespace HelloWorld{\n"+
                        "   class Hello{\n"+
                        "       static void Main(){\n"+
                        "           Console.WriteLine(\"Hello World!\");\n"+
                        "           Console.WriteLine(\"Press any key to exit.\");\n"+
                        "           Console.ReadKey();"+
                        "       }\n"+
                        "   }\n"+
                        "}",
                    }
                };

                foreach(Guestbook g in data)
                {
                    context.Guestbook.Add(g);
                }

                context.SaveChanges();
            }
        }
    }
}
