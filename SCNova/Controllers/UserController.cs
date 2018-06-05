using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovaSimplePerfTests.Models;
using Starcounter.Nova;

namespace NovaSimplePerfTests.Controllers
{
    public class UserController : Controller
    {
        // GET: /User/Add
        [HttpGet("User/Add/{username}/{password}")]
        public async Task<IActionResult> Add(string username, string password)
        {
            User user = null;

            Db.Transact(() =>
            {
                user = Db.Insert<User>();
                user.UserName = username;
            });
            Db.Transact(() =>
            {
                user.PasswordHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            });

            return Content("Added");
        }
    }
}
