using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newsapplibrary.Data;
using Newsapplibrary.Models;

namespace razornewsapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly newsappContext newsappContext1;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,newsappContext newsappContext)
        {
            _logger = logger;
            newsappContext1 = newsappContext;
        }
        public IList<Articulo> articulos { get; set; }
        public void OnGet()
        {
            articulos = newsappContext1.Articulos.ToList();
        }
    }
}
