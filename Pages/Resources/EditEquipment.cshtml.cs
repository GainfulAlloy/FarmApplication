using FarmApplication.Areas.Identity.Data;
using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages.Resources
{
    public class EditEquipmentModel : PageModel
    {
		private readonly ApplicationDBContext _db;
        private readonly UserManager<FarmApplicationDBUser> _userManager;

        [ActivatorUtilitiesConstructor]
        public EditEquipmentModel(ApplicationDBContext db, UserManager<FarmApplicationDBUser> userManager)
		{
			_db = db;
            this._userManager = userManager;
        }


		[BindProperty]
		public Equipment equipment { get; set; }

		public void OnGet(int id)
		{
			equipment = _db.Equipment.Find(id);
		}

		public async Task<IActionResult> OnPost(Equipment equipment)
		{
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
			{
                equipment.UserID = currentUser.Id;


                // Custom error that will not allow the creation of a field with the name and size as the same value
                if (equipment.EquipmentName == equipment.EquipmentCount.ToString())
			{
				ModelState.AddModelError("equipment.EquipmentName", "Name cant be the same as the size");
			}

			//if (ModelState.IsValid)
			//{
				_db.Equipment.Update(equipment);
				await _db.SaveChangesAsync();
				TempData["success"] = "Item Updated";
				return RedirectToPage("ResourceIndex");

			//}
			}

			return Page();
		}
	}
}
