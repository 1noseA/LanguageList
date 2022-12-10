using System.ComponentModel.DataAnnotations;

namespace LanguageList.Models
{
    public class LanguageMst
    {
        [Display(Name = "言語コード")]
        public int Id { get; set; }

        [Required(ErrorMessage = "[Error]入力情報に誤りがあります")]
        [Display(Name = "言語名")]
        public string LanguageName { get; set; }
    }
}
