using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FarmApplication.Pages
{
    public class CreateTaskModel : PageModel
    {

		private readonly ApplicationDBContext _db;

        [ActivatorUtilitiesConstructor]
        public CreateTaskModel(ApplicationDBContext db)
        {
            _db = db;   
        }

        public List<Field> Fields { get; set; }
        [BindProperty]
        public int SelectFieldID { get; set; }

        public List<FarmResources> Resources { get; set; }
        [BindProperty]
        public int SelectResourceID { get; set; }

        public List<Equipment> Equipments { get; set; }
        [BindProperty]
        public int SelectEquipmentID { get; set; }

        public List<Workers> Worker {  get; set; }
        [BindProperty]
        public int SelectWorkerID { get; set; }

		public void OnGet()
        {
            Fields = _db.Fields.ToList();
            Resources = _db.Resources.ToList();
            Equipments = _db.Equipment.ToList();
            Worker = _db.Workers.ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            // !!!! Notice this will break if the nothing option is chosen at the moment

            if (!ModelState.IsValid)
            {
                return Page(); // Return the page with validation errors
            }
            //var NewNewFieldTask = _db.Fields.Find(SelectFieldID);


			var selectedField = _db.Fields.Find(SelectFieldID);
			var selectedResource = _db.Resources.Find(SelectResourceID);
			var selectedEquipment = _db.Equipment.Find(SelectEquipmentID);
			var selectedWorker = _db.Workers.Find(SelectWorkerID);


			// This will input the ID's of the options chosen from the drop down menu

			var newTask = new FarmApplication.Model.FarmTasks
            {

                TaskField = SelectFieldID,
                TaskResources = SelectResourceID,
                TaskEquipment = SelectEquipmentID,
                TaskWorker = SelectWorkerID,

			};

			newTask.FieldValues = _db.Fields.Find(SelectFieldID);
			newTask.ResourcesValues = _db.Resources.Find(SelectResourceID);
			newTask.EquipmentValues = _db.Equipment.Find(SelectEquipmentID);
			newTask.WorkersValues = _db.Workers.Find(SelectWorkerID);



			_db.Tasks.Add(newTask);
                await _db.SaveChangesAsync();

                return RedirectToPage("Calendar"); // Redirect to a success page or wherever you want               
            //}
            // doesnt seem to be working atm
            return Page();
            return RedirectToPage("Calendar");            
        }

    }
}
