using LanguageList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LanguageList.ViewModels
{
    public class LanguageMstViewModel
    {
        // 言語名
        [Required(ErrorMessage = "[Error]入力情報に誤りがあります")]
        [Display(Name = "言語名")]
        public string LanguageName { get; set; }
        // 完了メッセージ
        public string? CompletionMessage { get; set; }
    }
}
