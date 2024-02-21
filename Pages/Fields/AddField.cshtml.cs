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
            await _db.Fields.AddAsync(field);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
