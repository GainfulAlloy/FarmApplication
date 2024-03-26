using System.ComponentModel.DataAnnotations;

namespace FarmApplication.Model
{
	public class Equipment
	{
		[Key]
		public int Id { get; set; }

		[Required]
		// name of the item to add, could be items like tractors, electric screwdrivers... Expensive tools that the user may have a low quantitiy of
		// to do specific jobs
		public string EquipmentName { get; set; }

		[Required]
		// the user can list how many of this object they have, then the count can be decreased when the item is in use
		public int EquipmentCount { get; set; }

		// create a link between another table

		//public int ID { get; set; }

		//public UserData UserData { get; set; }


	}
}
