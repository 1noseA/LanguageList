using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LanguageList.Data;
using System;
using System.Linq;

namespace LanguageList.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LanguageListContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LanguageListContext>>()))
            {
                // Look for any movies.
                if (context.LanguageMst.Any())
                {
                    return;   // DB has been seeded
                }

                context.LanguageMst.AddRange(
                    new LanguageMst
                    {
                        LanguageName = "C言語"
                    },

                    new LanguageMst
                    {
                        LanguageName = "C++"
                    },

                    new LanguageMst
                    {
                        LanguageName = "Java"
                    },

                    new LanguageMst
                    {
                        LanguageName = "C#"
                    },

                    new LanguageMst
                    {
                        LanguageName = "Java Script"
                    },

                    new LanguageMst
                    {
                        LanguageName = "PHP"
                    },

                    new LanguageMst
                    {
                        LanguageName = "Ruby"
                    },

                    new LanguageMst
                    {
                        LanguageName = "Type Script"
                    },

                    new LanguageMst
                    {
                        LanguageName = "Python"
                    },

                    new LanguageMst
                    {
                        LanguageName = "Go"
                    },

                    new LanguageMst
                    {
                        LanguageName = "VB"
                    },

                    new LanguageMst
                    {
                        LanguageName = "Python"
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
