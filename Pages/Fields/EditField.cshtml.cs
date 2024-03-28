using FarmApplication.Areas.Identity.Data;
using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FarmApplication.Pages.Fields
{
    public class EditFieldModel : PageModel
    {
        private readonly ApplicationDBContext _db;
		private readonly UserManager<FarmApplicationDBUser> _userManager;
		public Field field {  get; set; }

		[ActivatorUtilitiesConstructor]
		public EditFieldModel(ApplicationDBContext db, UserManager<FarmApplicationDBUser> userManager)
		{
			_db = db;
			this._userManager = userManager;
		}
		public void OnGet(int id)
        {
            field = _db.Fields.Find(id);
        }
        public async Task<IActionResult> OnPost(Field field)
        {
			var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
				field.UserID = currentUser.Id;

				// Custom error that will not allow the creation of a field with the name and size as the same value
				if (field.FieldName == field.FieldSize.ToString())
                {
                    ModelState.AddModelError("field.FieldName", "Name cant be the same as the size");
                }
                //if (ModelState.IsValid)
                //{
                    _db.Fields.Update(field);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Field Updated";
                    return RedirectToPage("Index");

                //}
            }
            return Page();
        }
    }
}
