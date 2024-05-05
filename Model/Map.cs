using FarmApplication.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmApplication.Model
{
	public class Map
	{
		[Key]
		public int FarmID { get; set; }

		[Required]

		public float Latitute1 { get; set; }
		public float Latitute2 { get; set; }
		public float Latitute3 { get; set; }
		public float Latitute4 { get; set; }

		public float Longitude1 { get; set; }
		public float Longitude2 { get; set; }
		public float Longitude3 { get; set; }	
		public float Longitude4 { get; set; }

		public string FieldID { get; set; }
		[ForeignKey("FieldID")]

        public virtual FarmApplicationDBUser AspNetUsers { get; set; }

    }
}
