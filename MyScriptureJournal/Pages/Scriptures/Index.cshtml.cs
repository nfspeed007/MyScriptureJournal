using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList StandardWorks { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Notes { get; set; }

        public IList<Scripture> Scripture { get;set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Scripture
                                            orderby m.StandardWorks
                                            select m.StandardWorks;

            var scriptures = from m in _context.Scripture
                             select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(Notes))
            {
                scriptures = scriptures.Where(x => x.StandardWorks == Notes);
            }
            StandardWorks = new SelectList(await genreQuery.Distinct().ToListAsync());
            Scripture = await _context.Scripture.ToListAsync();
        }
    }
}
