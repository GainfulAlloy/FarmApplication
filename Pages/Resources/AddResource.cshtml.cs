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

		public AddResourceModel(ApplicationDBContext db)
		{
			_db = db;
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

				if (ModelState.IsValid)
				{
					_db.Resources.Add(Resources);
					await _db.SaveChangesAsync();
					TempData["success"] = "Resource Added";
					return RedirectToPage("ResourceIndex");

				}	

			return Page();
		}


	}
}
