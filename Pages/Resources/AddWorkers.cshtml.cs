using FarmApplication.Areas.Identity.Data;
using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages.Resources
{
    public class AddWorkersModel : PageModel
    {
		private readonly ApplicationDBContext _db;
		private readonly UserManager<FarmApplicationDBUser> _userManager;
		// not to sure why this is only needed for this class
		// (error resolved public Workers workers { get; set; } had the same name as it did in ResourceIndex.cshtml.cs).


		[ActivatorUtilitiesConstructor]
		public AddWorkersModel(ApplicationDBContext db, UserManager<FarmApplicationDBUser> userManager)
		{
			_db = db;
			this._userManager = userManager;
		}


		[BindProperty]
		public Workers workers { get; set; }

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPost(Workers workers)
		{

			// Custom error that will not allow the creation of a field with the name and size as the same value
			if (workers.WorkerName == workers.WorkerSalary.ToString())
			{
				ModelState.AddModelError("WorkersOnFarm.WorkerName", "Name cant be the same as the size");
			}

			var currentUser = await _userManager.GetUserAsync(User);
			workers.UserID = currentUser.Id;
			_db.Workers.Add(workers);
			await _db.SaveChangesAsync();
			TempData["success"] = "Employee Added";
			return RedirectToPage("ResourceIndex");

			//if (ModelState.IsValid)
			//{
				

			//}

			//return Page();
		}
	}
}
