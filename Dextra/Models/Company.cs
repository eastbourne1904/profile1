using System.ComponentModel.DataAnnotations;

namespace Dextra.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
