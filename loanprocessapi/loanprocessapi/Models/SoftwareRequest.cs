using System.ComponentModel.DataAnnotations;

namespace loanprocessapi.Models
{
    public class SoftwareRequest
    {
        [Key]

        public long ? SoftwareId { get; set; }
        [Required]
        public string ? SoftwareName { get; set; }
        [Required]

        public string ? SoftwareVersion { get; set; }
        [Required]
        public long ? SoftwareCost { get; set; }

    }
}
