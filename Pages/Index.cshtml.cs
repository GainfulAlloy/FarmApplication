using FarmApplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<FarmApplicationDBUser> _userManager;

		[BindProperty]
		public DateTime CurrentTime { get; set; }


		[ActivatorUtilitiesConstructor]
        public IndexModel(ILogger<IndexModel> logger, UserManager<FarmApplicationDBUser> userManager)
        {
            _logger = logger;
            this._userManager = userManager;

        }

        public void OnGet()
        {
            ViewData["UserID"] = _userManager.GetUserId(this.User);
			CurrentTime = DateTime.Now;
		}
    }
}
