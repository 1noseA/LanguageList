using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LanguageList.Models;

namespace LanguageList.Data
{
    public class LanguageListContext : DbContext
    {
        public LanguageListContext (DbContextOptions<LanguageListContext> options)
            : base(options)
        {
        }

        public DbSet<LanguageList.Models.LanguageMst> LanguageMst { get; set; } = default!;
    }
}
