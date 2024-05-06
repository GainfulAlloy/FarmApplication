using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace FarmApplication.Pages.Maps
{
	public class MappedIndexModel : PageModel
	{
		private readonly ApplicationDBContext _db;
		public IEnumerable<Map> Maps { get; set; }

		//public MappedIndexModel(ApplicationDBContext db)
		//{
		//	_db = db;
		//}


		//public void OnGet()
		//{
		//	//Fields = _db.Fields;
		//}
	}
}
