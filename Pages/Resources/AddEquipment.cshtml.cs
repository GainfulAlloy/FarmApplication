using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages.Resources
{
    public class AddEquipmentModel : PageModel
    {
		private readonly ApplicationDBContext _db;

		public AddEquipmentModel(ApplicationDBContext db)
		{
			_db = db;
		}


		[BindProperty]
		public Equipment equipment { get; set; }

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPost(Equipment equipment)
		{

			// Custom error that will not allow the creation of a field with the name and size as the same value
			if (equipment.EquipmentName == equipment.EquipmentCount.ToString())
			{
				ModelState.AddModelError("equipment.EquipmentName", "Name cant be the same as the size");
			}

			if (ModelState.IsValid)
			{
				_db.Equipment.Add(equipment);
				await _db.SaveChangesAsync();
				TempData["success"] = "Item Added";
				return RedirectToPage("ResourceIndex");

			}

			return Page();
		}
	}
}
