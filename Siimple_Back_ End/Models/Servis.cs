using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siimple_Back__End.Models
{
    public class Servis
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
