using FarmApplication.Migrations.FarmApplicationDB;
using System.ComponentModel.DataAnnotations;

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






        // create a link between another table

        //public int ID { get; set; }

        //public UserData UserData { get; set; }
    }
}
