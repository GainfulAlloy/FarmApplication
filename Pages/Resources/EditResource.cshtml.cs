using FarmApplication.Areas.Identity.Data;
using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages.Resources
{
    public class EditResourceModel : PageModel
    {
		private readonly ApplicationDBContext _db;
        private readonly UserManager<FarmApplicationDBUser> _userManager;

        public FarmResources Resources { get; set; }

        [ActivatorUtilitiesConstructor]
        public EditResourceModel(ApplicationDBContext db, UserManager<FarmApplicationDBUser> userManager)
		{
			_db = db;
            this._userManager = userManager;
        }

		

		public void OnGet(int id)
		{
			Resources = _db.Resources.Find(id);
		}

		public async Task<IActionResult> OnPost(FarmResources Resources)
		{
            var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser != null)
			{
                Resources.UserID = currentUser.Id;

                // Custom error that will not allow the creation of a field with the name and size as the same value
                if (Resources.ResourceName == Resources.ResourceCount.ToString())
				{
					ModelState.AddModelError("Resources.ResourceName", "Name cant be the same as the size");
				}

				// i cant get validation to work with the user id feature
				//if (ModelState.IsValid)
				//{
					_db.Resources.Update(Resources);
					await _db.SaveChangesAsync();
					TempData["success"] = "Resource Updated";
					return RedirectToPage("ResourceIndex");

				//}
			}
			return Page();
		}
	}
}
