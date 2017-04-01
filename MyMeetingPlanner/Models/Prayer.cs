using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMeetingPlanner.Models
{
    public partial class Prayer
    {
        public Prayer()
        {
            SacramentMeetingFkClosingPrayerNavigation = new HashSet<SacramentMeeting>();
            SacramentMeetingFkOpenPrayerNavigation = new HashSet<SacramentMeeting>();
        }

        public int PrayerId { get; set; }

        [Required]
        [Display(Name = "Prayer Type")]
        public int FkPrayerType { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Prayer")]
        public DateTime PrayerDate { get; set; }

        [Display(Name = "Name")]
        public int FkWardMemberId { get; set; }

        public virtual ICollection<SacramentMeeting> SacramentMeetingFkClosingPrayerNavigation { get; set; }
        public virtual ICollection<SacramentMeeting> SacramentMeetingFkOpenPrayerNavigation { get; set; }
        [Display(Name = "Prayer Type")]
        public virtual PrayerType FkPrayerTypeNavigation { get; set; }
        [Display(Name = "Name")]
        public virtual WardMember FkWardMember { get; set; }
    }
}
