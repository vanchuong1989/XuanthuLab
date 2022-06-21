using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TichHopEntityFramwork.Models;

namespace TichHopEntityFramwork.Pages.Blog
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TichHopEntityFramwork.Models.MyBlogContext _context;

        public IndexModel(TichHopEntityFramwork.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; }

        //Phân trang
        public const int ITEMS_PER_PAGE = 10;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }


        public async Task OnGetAsync(string searchStr)
        {
            //Article = await _context.articles.ToListAsync();
            //==============================================================================
            int totalArticle = await _context.articles.CountAsync();//get all records in article table

            //ex : totalArticle =150 ;  ITEMS_PER_PAGE =10
            //     countPages = 150 /10 = 15
            countPages = (int)Math.Ceiling((double)totalArticle / ITEMS_PER_PAGE);

            if (currentPage < 1)
            {
                currentPage = 1;
            }
            if (currentPage > countPages)
            {
                currentPage = countPages;
            }

            //===============================================================================
            var qr = (from a in _context.articles
                     orderby a.Created descending
                     select a).Skip((currentPage-1)*ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);

            if (!string.IsNullOrEmpty(searchStr))
            {
                Article = await qr.Where(a => a.Title.Contains(searchStr)).ToListAsync();
            }
            else
            {
                Article = await qr.ToListAsync();
            }
            ;

        }
    }
}
