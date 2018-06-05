using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovaSimplePerfTests.Models;
using Starcounter.Nova;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaSimplePerfTests.Controllers
{
    public class UserController : Controller
    {
        // POST: /User/Add
        [HttpPost]
        public async Task<IActionResult> Add(string username, string email, string password)
        {
            User user = null;

            Db.Transact(() =>
            {
                user = Db.Insert<User>();
                user.UserName = username;
                user.Email = email;
            });
           
            Db.Transact(() =>
            {
                user.PasswordHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            });


            return Content("Added");
        }
    }
}
