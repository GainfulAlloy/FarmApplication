using FarmApplication.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmApplication.Model
{
	public class Workers
	{
		[Key]
		public int WorkerID { get; set; }

		[Required]
		public string WorkerName { get; set; }
		// optional field that will allow the user to quickly assess how much they are paying all thier workers
		public int WorkerSalary { get; set; }

		// remove the worker from the table if it hits this date
		public DateTime EmployedUntil { get; set; }

		public string UserID { get; set; }
		[ForeignKey("UserID")]
		public virtual FarmApplicationDBUser AspNetUsers { get; set; }


	}
}
