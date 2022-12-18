using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanguageList.Data;
using LanguageList.Models;
using LanguageList.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace LanguageList.Controllers
{
    public class LanguageMstController : Controller
    {
        private readonly LanguageListContext _context;

        public LanguageMstController(LanguageListContext context)
        {
            _context = context;
        }

        // GET: LanguageMst
        public async Task<IActionResult> Index()
        {
            // DBから全ての言語名を取得するLINQクエリ
            IQueryable<string> query = from m in _context.LanguageMst
                                        orderby m.Id
                                        select m.LanguageName;
            //var languageMst = from m in _context.LanguageMst
            //                  orderby m.Id
            //                  select m;

            var viewModel = new LanguageMstViewModel
            {
                LanguageNames = new SelectList(await query.ToListAsync())
                //LanguageMst = await languageMst.ToListAsync()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Search(string selectName)
        {
            // DBから全ての言語名を取得するLINQクエリ
            IQueryable<string> query = from m in _context.LanguageMst
                                       orderby m.Id
                                       select m.LanguageName;
            var languageMst = from m in _context.LanguageMst
                              orderby m.Id
                              select m;

            if (!String.IsNullOrEmpty(selectName))
            {
                languageMst = (IOrderedQueryable<LanguageMst>)languageMst.Where(x => x.LanguageName == selectName);
            }

            var viewModel = new LanguageMstViewModel
            {
                LanguageNames = new SelectList(await query.ToListAsync()),
                LanguageMst = await languageMst.ToListAsync(),
                ShowIndex = true
            };

            //Session["LanguageList"] = viewModel;

            return View("Index", viewModel);
        }

        // GET: LanguageMst/Create
        public IActionResult Create()
        {
            var viewModel = new LanguageMstViewModel();
            return View(viewModel);
        }

        // POST: LanguageMst/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LanguageName")] LanguageMst languageMst)
        {
            // 入力チェック問題なければ
            if (ModelState.IsValid)
            {
                // 入力値の追加
                _context.Add(languageMst);
                // INSERT実行
                await _context.SaveChangesAsync();
                // 登録完了メッセージを設定
                var viewModel = new LanguageMstViewModel
                {
                    LanguageName = String.Empty,
                    CompletionMessage = "[Info]" + languageMst.LanguageName + "を登録しました。"
                };
                ModelState.Clear();
                // 新規作成画面を再表示する
                return View("Create", viewModel);
            }
            return View(languageMst);
        }

        // POST: LanguageMst/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string languageName, string selectName)
        {
            
            if (id == 0 || string.IsNullOrEmpty(languageName))
            {
                return NotFound();
            }

            LanguageMst model = new LanguageMst();
            model.Id = id;
            model.LanguageName = languageName;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Search));
            }
            return RedirectToAction(nameof(Search));
        }

        // GET: LanguageMst/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LanguageMst == null)
            {
                return NotFound();
            }

            var languageMst = await _context.LanguageMst
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languageMst == null)
            {
                return NotFound();
            }

            return View(languageMst);
        }

        // POST: LanguageMst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LanguageMst == null)
            {
                return Problem("Entity set 'LanguageListContext.LanguageMst'  is null.");
            }
            var languageMst = await _context.LanguageMst.FindAsync(id);
            if (languageMst != null)
            {
                _context.LanguageMst.Remove(languageMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageMstExists(int id)
        {
          return _context.LanguageMst.Any(e => e.Id == id);
        }
    }
}
