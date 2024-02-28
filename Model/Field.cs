using System.ComponentModel.DataAnnotations;

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
        // largest farm in the uk is 25,000
        [Range(0, 50000,ErrorMessage ="Field size has to be in the range of 0 - 50000")]
        public int FieldSize { get; set; }
    }
}
