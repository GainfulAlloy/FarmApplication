using System.ComponentModel.DataAnnotations;

namespace FarmApplication.Model
{
    public class Field
    {
        [Key]
        public int FieldID { get; set; }
        [Required]
        public string FieldName { get; set; }
        public int FieldSize { get; set; }
    }
}
