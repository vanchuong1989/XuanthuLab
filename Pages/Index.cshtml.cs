using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TichHopEntityFramwork.Models;

namespace TichHopEntityFramwork.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly MyBlogContext _myContext;
        public IndexModel(ILogger<IndexModel> logger, MyBlogContext myContext)
        {
            _logger = logger;
            _myContext = myContext;
        }

        public void OnGet()
        {
            var posts = (from a in _myContext.articles
                        orderby a.Created descending
                        select a).ToList();
            ViewData["posts"] = posts;
        }
    }
}
