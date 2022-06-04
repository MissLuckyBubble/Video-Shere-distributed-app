using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationService.DTOs
{
    public class CommentDTO : BaseDTO
    {
        [Required]
        [StringLength(500)]
        public string Text { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public int OwnerId { get; set; }
        public UserDTO Owner { get; set; }

        public int VideoId { get; set; }
        public VideoDTO Video { get; set; }

    }
}
