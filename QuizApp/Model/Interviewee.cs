using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Interviewee
    {
        public int Id { get; set; }
        [ForeignKey("Identity")]
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }  // navigation property
        public string Location { get; set; }
        public string Locale { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        [ForeignKey("AddedBy")]
        public string AddedId { get; set; }
        [Required]
        public AppUser AddedBy { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        
    }
}
