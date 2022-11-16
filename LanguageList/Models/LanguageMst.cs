using System.ComponentModel.DataAnnotations;

namespace LanguageList.Models
{
    public class LanguageMst
    {
        [Display(Name = "言語コード")]
        public int Id { get; set; }

        [Display(Name = "言語名")]
        public string LanguageName { get; set; }
    }
}
