using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FarmApplication.Pages
{
    public class CalendarModel : PageModel
    {

		private readonly ApplicationDBContext _db;
		public List<FarmTasks> FarmTask { get; set; }

		[ActivatorUtilitiesConstructor]
		public CalendarModel(ApplicationDBContext db)
		{
			_db = db;
		}



		
		public void OnGet()
        {
			FarmTask = _db.Tasks						
				.Include(ft => ft.FieldValues)
				.Include(ft => ft.ResourcesValues)
				.Include(ft => ft.EquipmentValues)
				.Include(ft => ft.WorkersValues)
				.ToList();

			

		}
	}
}
