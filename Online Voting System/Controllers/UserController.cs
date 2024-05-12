using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Online_Voting_System.Models;
using Online_Voting_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Online_Voting_System.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbcontext _db;
        public UserController(ApplicationDbcontext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User modelLogin)
        {
            var user = await _db.User.FirstOrDefaultAsync(u => u.Mobile == modelLogin.Mobile && u.Password == modelLogin.Password && u.Role == modelLogin.Role);
            
            if (user != null)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.n_id)),
                    new Claim("Role",user.Role),
                    new Claim("Id", Convert.ToString(user.n_id))
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {

                    AllowRefresh = true,
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidateMessage"] = "user not found";
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if(ModelState.IsValid)
            {
                _db.User.Add(model);
                await _db.SaveChangesAsync();
                ViewData["Success"] = "User Created Successfully";
                return RedirectToAction("Login", "User");
            }
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }
    }
}
