using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3} [0-9]{2}$")]
        public string ZipCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string IC { get; set; }
        [Required]
        [MaxLength(100)]
        public string DIC { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();
    }
}