using LanguageList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LanguageList.ViewModels
{
    public class LanguageMstViewModel
    {
        // 言語情報
        //public IEnumerable<LanguageMst> LanguageMst { get; set; }
        public List<LanguageMst> LanguageMst { get; set; }
        // 言語名ブルダウン
        public SelectList? LanguageNames { get; set; }
        // 選択した言語名
        public string? SelectName { get; set; }
        // 一覧表示フラグ
        public bool ShowIndex { get; set; }
    }
}
