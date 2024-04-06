using FarmApplication.Data;
using FarmApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;

namespace FarmApplication.Pages
{
    public class CalendarModel : PageModel
    {
		/*
		public List<TaskEvent> TaskEvents { get; set; }

		public IActionResult OnGetGetTasks()
		{
			// Fetch tasks from the database or any other source
			TaskEvents = new List<TaskEvent>
			{
				new TaskEvent { Id = 1, Title = "Task 1", Start = "2024-04-04T09:00:00", End = "2024-04-04T10:00:00" },
				new TaskEvent { Id = 2, Title = "Task 2", Start = "2024-04-04T11:00:00", End = "2024-04-04T12:00:00" },
				new TaskEvent { Id = 3, Title = "Task 3", Start = "2024-04-04T23:58:00", End = "2024-04-04T23:59:00" }
			};

			return new JsonResult(TaskEvents);
		}
		

		public class TaskEvent
		{
			public int Id { get; set; }
			public string Title { get; set; }
			public string Start { get; set; }
			public string End { get; set; }
		}*/

		public DateTime DayToView { get; set; }
		public DateTime SelectedDay { get; set; } = DateTime.Now.Date;

		public List<FarmTasks> TaskTimetable { get; set; }

		public SelectList Days { get; set; }






		private readonly ApplicationDBContext _db;
		public List<FarmTasks> FarmTask { get; set; }

		[ActivatorUtilitiesConstructor]
		public CalendarModel(ApplicationDBContext db)
		{
			_db = db;
		}



		
		/*public void OnGet()
        {
			FarmTask = _db.Tasks						
				.Include(ft => ft.FieldValues)
				.Include(ft => ft.ResourcesValues)
				.Include(ft => ft.EquipmentValues)
				.Include(ft => ft.WorkersValues)
				.ToList();

			

		}*/
		public async Task OnGetAsync(DateTime selectedDay)
		{
			Console.WriteLine($"SelectedDay in OnGetAsync: {selectedDay}");

			FarmTask = _db.Tasks
				.Include(ft => ft.FieldValues)
				.Include(ft => ft.ResourcesValues)
				.Include(ft => ft.EquipmentValues)
				.Include(ft => ft.WorkersValues)				 
				.ToList();

			//var testing1 = selectedDay.Date;
			//var testing2 = selectedDay.Date.AddDays(1);

			//Console.WriteLine($"Testing1: {testing1}"); // Output: Testing1: 05/04/2024 00:00:00
			//Console.WriteLine($"Testing2: {testing2}");


			//DateTime parsedSelectedDay;
			//DateTime.TryParseExact(selectedDay, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedSelectedDay);
			//Console.WriteLine($"SelectedDay in OnGetAsync: {parsedSelectedDay}");

			//int day = selectedDay.Day;
			//int month = selectedDay.Month;
			//int year = selectedDay.Year;

			//Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");

			// Construct correctedSelectedDay using the correct order (dd/mm/yyyy)
			//DateTime correctedSelectedDay;
			//correctedSelectedDay = new DateTime(year, day, month);


			// Notice -- selectedDay is stuck in american format, whatever option you pick from the drop down gets converted

			TaskTimetable = _db.Tasks
				.Where(t => t.TaskStart.Date == selectedDay && t.TaskStart <= selectedDay.Date.AddDays(1))
				.ToList();
			





			Days = new SelectList(await _db.Tasks
				.Select(t => t.TaskStart.Date)
				.Distinct()
				.ToListAsync());
			
			//return Partial("_TaskTable", tasks);
			//return new JsonResult(TaskTimetable);
		}
	}
}
