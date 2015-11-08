using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcNet5.Models
{
    public class Speaker
    {

        public int SpeakerId { get; set; }
        [StringLength(40)]
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [StringLength(40)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(15)]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Blog URL")]
        public string Blog { get; set; }
        [StringLength(15)]
        [Display(Name = "Twitter Handle")]
        public string Twitter { get; set; }
        [StringLength(40)]
        public string Specialization { get; set; }
        public string Bio { get; set; }
        [StringLength(200)]
        [Display(Name = "Picture URL")]
        public string PhotoURL { get; set; }
    }
}
