using LanguageList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LanguageList.ViewModels
{
    public class LanguageMstViewModel
    {
        //public IEnumerable<LanguageMst> LanguageMst { get; set; }
        public List<LanguageMst> LanguageMst { get; set; }
        public SelectList? LanguageNames { get; set; }
        public string? selectName { get; set; }
    }
}
