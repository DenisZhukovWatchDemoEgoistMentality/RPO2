using API_BucketWithBolts.Context;
using Api_Topito.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace API_BucketWithBolts.Routers
{
    public class API_Methods_User
    {
        public bool OnPost(Database _context, User newUser)
        {
            if (string.IsNullOrEmpty(newUser.First_name))
                return false;

            _context.Users.Add(newUser);
            _context.SaveChangesAsync();

            return true;
        }

        public bool OnGet(Database _context, User newUser, int id)
        {
            return true;
        }
    }
}
