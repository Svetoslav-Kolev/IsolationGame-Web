using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IsolationGame.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IsolationGame.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly ApplicationDbContext _context;
        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger,ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            DeleteInactiveGames();
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }
        private void DeleteInactiveGames()
        {
            string yourId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            foreach (var game in _context.Games.Where(g => (g.PlayerOneId == yourId && g.PlayerTwoId == null) || (g.PlayerTwoId == yourId && g.PlayerOneId == null)))
            {
                _context.Games.Remove(game);
            }
            foreach (var queuedUp in _context.Queue.Where(u => u.UserId == yourId))
            {
                _context.Queue.Remove(queuedUp);
            }
            _context.SaveChanges();

        }
    }
}