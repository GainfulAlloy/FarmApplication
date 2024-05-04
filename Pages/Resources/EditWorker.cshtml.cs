using FarmApplication.Areas.Identity.Data;
using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages.Resources
{
    public class EditWorkerModel : PageModel
    {
		private readonly ApplicationDBContext _db;
        private readonly UserManager<FarmApplicationDBUser> _userManager;

        // not to sure why this is only needed for this class

        public EditWorkerModel(ApplicationDBContext db, UserManager<FarmApplicationDBUser> userManager)
		{
			_db = db;
            this._userManager = userManager;
        }


		[BindProperty]
		public Workers WorkersOnFarm { get; set; }

		public void OnGet(int id)
		{
			WorkersOnFarm = _db.Workers.Find(id);
		}

		public async Task<IActionResult> OnPost(Workers WorkersOnFarm)
		{

            var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser != null)
			{
				WorkersOnFarm.UserID = currentUser.Id;

				// Custom error that will not allow the creation of a field with the name and size as the same value
				if (WorkersOnFarm.WorkerName == WorkersOnFarm.WorkerSalary.ToString())
				{
					ModelState.AddModelError("WorkersOnFarm.WorkerName", "Name cant be the same as the size");
				}

				//if (ModelState.IsValid)
				//{
					_db.Workers.Update(WorkersOnFarm);
					await _db.SaveChangesAsync();
					TempData["success"] = "Employee Updated";
					return RedirectToPage("ResourceIndex");

				//}
			}
			return Page();
		}
	}
}
