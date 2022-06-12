using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBiz.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Desc { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }

        public string Image { get; set; }
        [NotMapped]
        [Required]
        public IFormFile MemberImage{ get; set; }
    }
}
