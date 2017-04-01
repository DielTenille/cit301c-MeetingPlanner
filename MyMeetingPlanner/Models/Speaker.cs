using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMeetingPlanner.Models
{
    public partial class Speaker
    {
        public int SpeakerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Assigned")]
        public DateTime SpeakerDate { get; set; }

        [Required]
        [Display(Name = "Name")]
        public int FkWardMember { get; set; }

        [Display(Name = "Topic")]
        public int? FkTopic { get; set; }

        [Required]
        [Display(Name = "Speaker Type")]
        public int FkSpeakerType { get; set; }

        [Display(Name = "Speaker Type")]
        public virtual SpeakerType FkSpeakerTypeNavigation { get; set; }
        [Display(Name = "Topic")]
        public virtual Topic FkTopicNavigation { get; set; }
        [Display(Name = "Name")]
        public virtual WardMember FkWardMemberNavigation { get; set; }
    }
}
