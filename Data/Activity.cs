using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Activity : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        
        [ForeignKey("Project")]
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}