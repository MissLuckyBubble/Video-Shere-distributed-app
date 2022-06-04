
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entities
{
    public class Comment : BaseEntitiy
    {
        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }

        public int VideoId { get; set; }
        [ForeignKey("VideoId")]
        public virtual Video Video { get; set; }


    }
}
