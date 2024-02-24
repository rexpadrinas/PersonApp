using System.ComponentModel.DataAnnotations;

namespace PersonAppWeb.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int TypeID { get; set; }

    }
}
