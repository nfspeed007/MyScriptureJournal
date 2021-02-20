using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any Journals.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        StandardWorks = "Old Testament",
                        DateAdded = DateTime.Parse("1985-5-20"),
                        Book = "Genesis",
                        Chapter = 39,
                        Verse = 9,
                    },
                    
                    new Scripture
                    {
                        StandardWorks = "New Testament",
                        DateAdded = DateTime.Parse("1984-3-13"),
                        Book = "John",
                        Chapter = 3,
                        Verse = 5
                    },

                    new Scripture
                    {
                        StandardWorks = "Book of Mormon",
                        DateAdded = DateTime.Parse("1989-2-12"),
                        Book = "Helamen",
                        Chapter = 5,
                        Verse = 12
                    },

                    new Scripture
                    {
                        StandardWorks = "Doctrine & Covenants",
                        DateAdded = DateTime.Parse("1986-2-23"),
                        Book = "Section",
                        Chapter = 76
                    },

                    new Scripture
                    {
                        StandardWorks = "Pearl of Great Price",
                        DateAdded = DateTime.Parse("1959-4-15"),
                        Book = "Moses",
                        Chapter = 1,
                        Verse = 39
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
