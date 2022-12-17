using LanguageList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LanguageList.ViewModels
{
    public class LanguageMstViewModel
    {
        // 言語情報
        public List<LanguageMst> LanguageMst { get; set; }
        // 言語名ブルダウン
        public SelectList? LanguageNames { get; set; }
        // 選択した言語名
        public string? SelectName { get; set; }
        // 一覧表示フラグ
        public bool ShowIndex { get; set; }

        // 言語コード
        [Display(Name = "言語コード")]
        public int Id { get; set; }

        // 言語名
        [Required(ErrorMessage = "[Error]入力情報に誤りがあります")]
        [Display(Name = "言語名")]
        public string LanguageName { get; set; }

        // 完了メッセージ
        public string? CompletionMessage { get; set; }
    }
}
