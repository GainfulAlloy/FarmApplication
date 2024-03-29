using System.ComponentModel.DataAnnotations;

namespace FarmApplication.Model
{
    public class FarmTasks
    {
        [Key]
        public int TaskID { get; set; }

        public string TaskField { get; set; }

        public string TaskResources { get; set; }

        public string TaskEquipment { get; set; }

        public string TaskWorker { get; set; }

    }
}
