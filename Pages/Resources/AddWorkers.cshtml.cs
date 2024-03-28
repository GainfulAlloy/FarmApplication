using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages.Resources
{
    public class AddWorkersModel : PageModel
    {
		private readonly ApplicationDBContext _db;

		// not to sure why this is only needed for this class

		[ActivatorUtilitiesConstructor]
		public AddWorkersModel(ApplicationDBContext db)
		{
			_db = db;
		}


		[BindProperty]
		public Workers WorkersOnFarm { get; set; }

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPost(Workers WorkersOnFarm)
		{

			// Custom error that will not allow the creation of a field with the name and size as the same value
			if (WorkersOnFarm.WorkerName == WorkersOnFarm.WorkerSalary.ToString())
			{
				ModelState.AddModelError("WorkersOnFarm.WorkerName", "Name cant be the same as the size");
			}

			if (ModelState.IsValid)
			{
				_db.Workers.Add(WorkersOnFarm);
				await _db.SaveChangesAsync();
				TempData["success"] = "Employee Added";
				return RedirectToPage("ResourceIndex");

			}

			return Page();
		}
	}
}
