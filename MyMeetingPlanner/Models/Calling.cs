using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMeetingPlanner.Models
{
    public partial class Calling
    {
        public Calling()
        {
            WardMember = new HashSet<WardMember>();
        }

        public int CallingId { get; set; }

        [Required]
        [Display(Name = "Member of Bishopric?")]
        public bool Bishopric { get; set; } //Need to change to bool

        [Required]
        [Display(Name = "Auxillary Leader?")]
        public bool OtherLeader { get; set; } //Need to change to bool

        [Required]
        [Display(Name = "Calling Name")]
        public string CallingName { get; set; }

        public virtual ICollection<WardMember> WardMember { get; set; }
    }
}
