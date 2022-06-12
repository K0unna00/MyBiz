using System.ComponentModel.DataAnnotations;

namespace MyBiz.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
    }
}
