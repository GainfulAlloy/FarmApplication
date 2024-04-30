using FarmApplication.Areas.Identity.Data;
using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FarmApplication.Pages
{
    public class CreateTaskModel : PageModel
    {

		private readonly ApplicationDBContext _db;
		private readonly UserManager<FarmApplicationDBUser> _userManager;

		[ActivatorUtilitiesConstructor]
        public CreateTaskModel(ApplicationDBContext db, UserManager<FarmApplicationDBUser> userManager)
        {
            _db = db;
			this._userManager = userManager;
		}

        //[BindProperty]
        //public FarmTasks tasks { get; set; }

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public DateTime Start { get; set; }
        [BindProperty]
        public DateTime End { get; set; }

        [BindProperty]
        [Display(Name = "Resource Count to Use")]
        public int ResourceCountToUse { get; set; }

        [BindProperty]
        [Display(Name = "Equipment Count to Use")]
        public int EquipmentCountToUse { get; set; }

        public List<Field> Fields { get; set; }
        [BindProperty]
        public int? SelectFieldID { get; set; }

        public List<FarmResources> Resources { get; set; }
        [BindProperty]
        public int? SelectResourceID { get; set; }

        public List<Equipment> Equipments { get; set; }
        [BindProperty]
        public int? SelectEquipmentID { get; set; }

        public List<Workers> Worker {  get; set; }
        [BindProperty]
        public int? SelectWorkerID { get; set; }

		public void OnGet()
        {
            Fields = _db.Fields.ToList();
            Resources = _db.Resources.ToList();
            Equipments = _db.Equipment.ToList();
            Worker = _db.Workers.ToList();
            Name = "";  // Initialize Name property
            Start = DateTime.Now;  // Initialize Start property
            End = DateTime.Now;  // Initialize End property
            ResourceCountToUse = 0;
            EquipmentCountToUse = 0;


        }

        public async Task<IActionResult> OnPost()
        {
            // !!!! Notice this will break if the nothing option is chosen at the moment

            if (!ModelState.IsValid)
            {
                //return RedirectToPage("Index"); // Return the page with validation errors
                return Page();
            }
			//var NewNewFieldTask = _db.Fields.Find(SelectFieldID);

			var currentUser = await _userManager.GetUserAsync(User);

            //var selectedField = _db.Fields.Find(SelectFieldID);
            //var selectedResource = _db.Resources.Find(SelectResourceID);
            //var selectedEquipment = _db.Equipment.Find(SelectEquipmentID);
            //var selectedWorker = _db.Workers.Find(SelectWorkerID);


            // this allows me to check if the user actually has that much of a resource


            if ( SelectResourceID != null)
            {                   
                var SelctingNum = _db.Resources.Find(SelectResourceID);
                var EPICNUM = SelctingNum.ResourceCount;
                if(ResourceCountToUse > EPICNUM)
                {
                    ModelState.AddModelError("ResourceCountToUse", "ResourceCountToUse should not be greater than EPICNUM.");
			    }



                // All this allows me to remove resourceCount from the Resource Table
			    var selectedResource = await _db.Resources.FindAsync(SelectResourceID);

			    if (selectedResource == null)
			    {
				    ModelState.AddModelError("SelectResourceID", "Selected resource not found.");
				    //return Page();
			    }

			    if (ResourceCountToUse > selectedResource.ResourceCount)
			    {
				    ModelState.AddModelError("ResourceCountToUse", "ResourceCountToUse should not be greater than available ResourceCount.");
				    //return Page();
			    }
                
			    // Update ResourceCount in FarmResources table
			    selectedResource.ResourceCount -= ResourceCountToUse;
            }
            

            if (SelectEquipmentID != null)
            {
                var findEquipmentFK = _db.Equipment.Find(SelectEquipmentID);
                var ComparisonNum = findEquipmentFK.EquipmentCount;
                if (EquipmentCountToUse > ComparisonNum)
                {
                    ModelState.AddModelError("EquipmentCountToUse", "EquipmentCountToUse should not be greater than comparison number.");
                }
                findEquipmentFK.EquipmentCount -= EquipmentCountToUse;
            }   


            // maybe get rid of the model state validations to allow nulls????

            // This will input the ID's of the options chosen from the drop down menu
            if (ModelState.IsValid)
            {

            
                var newTask = new FarmApplication.Model.FarmTasks
                {

                    TaskField = SelectFieldID,
                    TaskResources = SelectResourceID,
                    TaskEquipment = SelectEquipmentID,
                    TaskWorker = SelectWorkerID,
                    TaskName = Name,
                    TaskStart = Start,
                    TaskEnd = End,
                    TaskResourceCount = ResourceCountToUse,
                    TaskEquipmentCount = EquipmentCountToUse,
                };

                if (SelectFieldID != null)
                {
                    newTask.FieldValues = _db.Fields.Find(SelectFieldID);
                }
                if (SelectResourceID != null)
                {
                    newTask.ResourcesValues = _db.Resources.Find(SelectResourceID);
                }
                if (SelectEquipmentID != null) { 
                    newTask.EquipmentValues = _db.Equipment.Find(SelectEquipmentID);
                }
                if (SelectWorkerID != null)
                {
                    newTask.WorkersValues = _db.Workers.Find(SelectWorkerID);
                }
                newTask.UserID = currentUser.Id;
            

			    _db.Tasks.Add(newTask);
                await _db.SaveChangesAsync();
				TempData["success"] = "Field Created";


			}
            // !!!!! Improtant notice, the Calendar page gets returned even if the model is invalid (couldnt figure out a way to return the page without it crashing)
            return RedirectToPage("Calendar");

            // doesnt seem to be working atm
            return Page();
            //return RedirectToPage("Calendar");            
        }

    }
}
