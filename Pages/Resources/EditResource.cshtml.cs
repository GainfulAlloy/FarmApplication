using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages.Resources
{
    public class EditResourceModel : PageModel
    {
		private readonly ApplicationDBContext _db;

		public FarmResources Resources { get; set; }

		public EditResourceModel(ApplicationDBContext db)
		{
			_db = db;
		}

		

		public void OnGet(int id)
		{
			Resources = _db.Resources.Find(id);
		}

		public async Task<IActionResult> OnPost(FarmResources Resources)
		{

			// Custom error that will not allow the creation of a field with the name and size as the same value
			if (Resources.ResourceName == Resources.ResourceCount.ToString())
			{
				ModelState.AddModelError("Resources.ResourceName", "Name cant be the same as the size");
			}

			if (ModelState.IsValid)
			{
				_db.Resources.Update(Resources);
				await _db.SaveChangesAsync();
				TempData["success"] = "Resource Updated";
				return RedirectToPage("ResourceIndex");

			}

			return Page();
		}
	}
}
