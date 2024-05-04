using FarmApplication.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmApplication.Model
{
    public class Field
    {
        [Key]
        public int FieldID { get; set; }
        [Required]
        public string FieldName { get; set; }

        // this will change the display name of this property everywhere in the app unless overriden 
        [Display(Name = "Size (Acres)")]
        // largest farm in the uk is 25,000 acres 
        [Range(0, 50000,ErrorMessage ="Field size has to be in the range of 0 - 50000")]
        public int FieldSize { get; set; }

		public string UserID { get; set; }
		//[ForeignKey("UserID")]
		//public virtual FarmApplicationDBUser AspNetUsers { get; set; }
        // might need to keep an eye on this line above (if you get an error for trying to access data from an empty table it may be this)

	}
}
