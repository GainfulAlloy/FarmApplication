using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FarmApplication.Pages.Fields
{
    public class AddFieldModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public Field field {  get; set; } 

        public AddFieldModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Field field)
        {
            // Custom error that will not allow the creation of a field with the name and size as the same value
            if (field.FieldName == field.FieldSize.ToString())
            {
                ModelState.AddModelError("field.FieldName", "Name cant be the same as the size");
            }
            if (ModelState.IsValid)
            {
                await _db.Fields.AddAsync(field);
                await _db.SaveChangesAsync();
                TempData["success"] = "Field Created";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
