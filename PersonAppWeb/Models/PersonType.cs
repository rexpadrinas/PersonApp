using System.ComponentModel.DataAnnotations;

namespace PersonAppWeb.Models
{
    public class PersonType
    {
        [Key]
        public int Type { get; set; }
        public string Description { get; set; }
    }
}
