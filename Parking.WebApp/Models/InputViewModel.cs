using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.WebApp.Models
{
    public class InputViewModel
    {
        [Required(ErrorMessage = "Car Entry is a required Input")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "Car Entry")]
        public DateTime? CarEntryInput { get; set; }

        [Required(ErrorMessage = "Car Exit is a required Input")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "Car Exit")]
        public DateTime? CarExitInput { get; set; }
        public string Errors { get; set; }
        public string Results { get; set; }
    }
}
