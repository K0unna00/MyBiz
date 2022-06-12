using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBiz.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CatagoryId { get; set; }
        [Required]
        public string Desc { get; set; }
        public Catagory Catagories { get; set; }
        public string Image { get; set; }
        [Required]
        [NotMapped]
        public IFormFile PortfolioImage{ get; set; }
    }
}
