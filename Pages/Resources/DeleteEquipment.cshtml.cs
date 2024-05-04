using FarmApplication.Areas.Identity.Data;
using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages.Resources
{
    public class DeleteEquipmentModel : PageModel
    {
		private readonly ApplicationDBContext _db;
        private readonly UserManager<FarmApplicationDBUser> _userManager;

        [ActivatorUtilitiesConstructor]
        public DeleteEquipmentModel(ApplicationDBContext db, UserManager<FarmApplicationDBUser> userManager)
		{
			_db = db;
            this._userManager = userManager;
        }


		public void OnGet(int id)
		{
			
		}

		public async Task<IActionResult> OnPost(int id)
		{
			var EquipFromDB = _db.Equipment.Find(id);

	
				_db.Equipment.Remove(EquipFromDB);
				await _db.SaveChangesAsync();
				TempData["success"] = "Equipment Deleted";
				return RedirectToPage("ResourceIndex");
			

			return Page();
		}
	}
}
