using FarmApplication.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmApplication.Model
{
	public class FarmResources
	{
		[Key]
		public int ResourceId { get; set; }
		[Required]
		// resources could include seeds or standard items they may have quantities of such as wood that would be spent up on a task.
		public string ResourceName { get; set; }

		// be careful about the resource count going into negative numbers if being taken away
		[Required]
		public int ResourceCount { get; set; }


		public string UserID { get; set; }
		//[ForeignKey("UserID")]
		//public virtual FarmApplicationDBUser AspNetUsers { get; set; }

	}
}
