using FarmApplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmApplication.Model
{
    public class FarmTasks
    {
        [Key]
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public int? TaskField { get; set; }

        public int? TaskResources { get; set; }
        public int? TaskResourceCount { get; set; }

        public int? TaskEquipment { get; set; }
        public int? TaskEquipmentCount { get; set; }

        public int? TaskWorker { get; set; }
        public DateTime TaskStart { get; set; }
        public DateTime TaskEnd { get; set; }


        // this should allow for grabbing fk's 
        public Field? FieldValues { get; set; }
        public FarmResources? ResourcesValues { get; set; }
        public Equipment? EquipmentValues { get; set; }
        public Workers? WorkersValues { get; set; }

		public string UserID { get; set; }
		//[ForeignKey("UserID")]
		//public virtual FarmApplicationDBUser AspNetUsers { get; set; }

	}
}
