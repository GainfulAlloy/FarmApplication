using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmApplication.Pages.Resources
{
    public class ResourceIndexModel : PageModel
    {
		// need to add all the tables i want to display on this page in here
		private readonly ApplicationDBContext _db;
		public IEnumerable<FarmResources> FarmingResources { get; set; }
		public IEnumerable<Equipment> Equipments { get; set; }
		public IEnumerable<Workers> WorkersOnFarm { get; set; }


		// i dont know why it needs a dependency injection here???
		//[ActivatorUtilitiesConstructor]
		public ResourceIndexModel(ApplicationDBContext db)
		{
			_db = db;
		}


		public void OnGet()
		{
			FarmingResources = _db.Resources;
			Equipments = _db.Equipment;
			WorkersOnFarm = _db.Workers;
		}

		


	}
}
