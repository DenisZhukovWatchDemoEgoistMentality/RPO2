using API_BucketWithBolts.Context;
using API_BucketWithBolts.Routers;
using Api_Topito.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API_BucketWithBolts.Pages.API_Methods
{
    public class UserMethodsModel : PageModel
    {
        private readonly ILogger<UserMethodsModel> _logger;
        private readonly Database _context;

        private API_Methods_User _user_router = new();

        [BindProperty]
        public User NewUser { get; set; }


        public UserMethodsModel(ILogger<UserMethodsModel> logger, Database context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            bool userAdd = _user_router.OnPost(_context, NewUser);

            if (!userAdd)
                return Page();

            return RedirectToPage();
        }
    }
}
