using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages.Fields
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public IEnumerable<Field> Fields { get; set; }

        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }


        public void OnGet()
        {
            Fields = _db.Fields;
        }
    }
}
