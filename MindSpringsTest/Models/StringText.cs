using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindSpringsTest.Models
{
    public class StringText
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int TextValue { get; set; }

        //Navigation Properties For App User
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
