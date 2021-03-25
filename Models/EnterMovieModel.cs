using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DateMe.Models
{
    public class EnterMovieModel
    {
        [Required]
        [Key]
        public int movieId { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string rating { get; set; }

        public bool edited { get; set; }

        public string lentto { get; set; }

        public string notes { get; set; }
    }
}
