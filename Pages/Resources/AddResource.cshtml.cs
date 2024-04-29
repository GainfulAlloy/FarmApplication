using FarmApplication.Areas.Identity.Data;
using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages.Resources
{
    public class AddResourceModel : PageModel
    {

		private readonly ApplicationDBContext _db;
		private readonly UserManager<FarmApplicationDBUser> _userManager;
		[ActivatorUtilitiesConstructor]
		public AddResourceModel(ApplicationDBContext db, UserManager<FarmApplicationDBUser> userManager)
		{
			_db = db;
			this._userManager = userManager;
		}


		[BindProperty]
        public FarmResources Resources { get; set; }

        public void OnGet()
        {
        }

		public async Task<IActionResult> OnPost(FarmResources resources)
		{
			
				// Custom error that will not allow the creation of a field with the name and size as the same value
				if (Resources.ResourceName == Resources.ResourceCount.ToString())
				{
					ModelState.AddModelError("Resources.ResourceName", "Name cant be the same as the size");
				}

			var currentUser = await _userManager.GetUserAsync(User);
			Resources.UserID = currentUser.Id;
			_db.Resources.Add(Resources);
			await _db.SaveChangesAsync();
			TempData["success"] = "Resource Added";
			return RedirectToPage("ResourceIndex");

			//if (ModelState.IsValid)
				//{
					

				//}	

			//return Page();
		}


	}
}
