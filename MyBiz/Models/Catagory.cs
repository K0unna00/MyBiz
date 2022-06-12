using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBiz.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Portfolio> Portfolios { get; set; }
    }
}
