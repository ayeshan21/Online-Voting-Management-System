using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Voting_System.Data;
using Online_Voting_System.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Online_Voting_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbcontext _db;

        public HomeController(ApplicationDbcontext db)
        {
            _db = db;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            Claim claimId = claimUser.FindFirst("Id");
            string Id = claimId?.Value;

            User user = await _db.User.FirstOrDefaultAsync(x => Convert.ToString(x.n_id) == Id);

            List<User> groups = await _db.User.Where(x => x.Role == "Group").OrderByDescending(x => x.Votes).ToListAsync();

            ViewBag.User = user;
            ViewBag.Groups = groups;

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Vote(double? n_id)
        {
            if (n_id == null)
            {
                return NotFound();
            }
            var group = await _db.User.FindAsync(n_id);

            if (group == null)
            {
                return RedirectToAction("Index");
            }

            ClaimsPrincipal claimUser = HttpContext.User;
            Claim claimId = claimUser.FindFirst("Id");
            string Id = claimId?.Value;

            User user = await _db.User.FindAsync(Convert.ToDouble(Id));


            group.Votes += 1;
            user.HasVoted = true;

            _db.Update(group);
            _db.Update(user);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
