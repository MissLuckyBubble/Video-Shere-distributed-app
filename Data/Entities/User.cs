using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User : BaseEntitiy
    {
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(56)]
        public string Country { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(200)]
        public string ProfilePictureLink { get; set; }
    }
}