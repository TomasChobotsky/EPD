using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Project : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)] 
        public string Title { get; set; }
        [Required]
        public int Wage { get; set; }

        public List<Activity> Activities { get; set; } = new List<Activity>();
        [ForeignKey("Customer")]
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}