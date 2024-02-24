using Microsoft.EntityFrameworkCore;
using PersonApp.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PersonApp.Model
{
    public class PersonType
    {
        [Key]
        public int Type { get; set; }
        public string Description { get; set; }

    }
}
