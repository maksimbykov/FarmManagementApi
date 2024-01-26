using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmManagementApi.Models
{
    public class Animal
    {
        [Key]
        public string Name { get; set; }
    }
}
