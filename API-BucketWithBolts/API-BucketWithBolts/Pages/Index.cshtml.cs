using API_BucketWithBolts.Context;
using API_BucketWithBolts.Routers;
using Api_Topito.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace API_BucketWithBolts.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Database _context;


        public IndexModel(ILogger<IndexModel> logger, Database context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/UserMethods");
        }
    }
}
