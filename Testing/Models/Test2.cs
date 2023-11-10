using System.ComponentModel.DataAnnotations;

namespace Testing.Models
{
    public class Test2
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        [MaxLength(255)]
        public string Applier { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public bool Status { get; set; } = false;

        [Required]
        public DateTime Time { get; set; }

        public Test2()
        {
            UserEmail = string.Empty;
        }
    }
}
