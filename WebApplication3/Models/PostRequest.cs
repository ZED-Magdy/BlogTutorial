using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class PostRequest
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }
        [Required]
        [MinLength(5)]
        public string Excerpt { get; set; }
        [Required]
        [MinLength(20)]
        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}
