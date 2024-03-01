using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FarmApplication.Pages.Fields
{
    public class DeleteFieldModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public Field field {  get; set; } 

        public DeleteFieldModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            // idk if this is needed 
            field = _db.Fields.Find(id);
        }
        public async Task<IActionResult> OnPost(int id)
        {
            // problem i think its just trying to delete an id rather then an object
            // fixed it		
            var FieldFromDB = _db.Fields.Find(id);

            if (FieldFromDB != null)
            {
                _db.Fields.Remove(FieldFromDB);
                await _db.SaveChangesAsync();
				TempData["success"] = "Field Deleted";
				return RedirectToPage("Index");
            }               
						
			return Page();
		}
    }
}
