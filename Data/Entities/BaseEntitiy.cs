using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class BaseEntitiy
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
