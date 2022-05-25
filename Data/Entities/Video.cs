using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Video : BaseEntitiy
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string VideoLink { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
    }
}
