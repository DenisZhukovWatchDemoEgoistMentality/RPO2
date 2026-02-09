using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    }
}
