using FarmApplication.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmApplication.Model
{
    public class FarmTasks
    {
        [Key]
        public int TaskID { get; set; }

        public int TaskField { get; set; }

        public int TaskResources { get; set; }

        public int TaskEquipment { get; set; }

        public int TaskWorker { get; set; }


        // this should allow for grabbing fk's 
        public Field FieldValues { get; set; }
        public FarmResources ResourcesValues { get; set; }
        public Equipment EquipmentValues { get; set; }
        public Workers WorkersValues { get; set; }

		public string UserID { get; set; }
		[ForeignKey("UserID")]
		public virtual FarmApplicationDBUser AspNetUsers { get; set; }

	}
}
