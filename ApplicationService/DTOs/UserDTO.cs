using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationService.DTOs
{
    public class UserDTO : BaseDTO
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(56)]
        public string Country { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int Age { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(200)]
        public string ProfilePictureLink { get; set; }
    }
}
