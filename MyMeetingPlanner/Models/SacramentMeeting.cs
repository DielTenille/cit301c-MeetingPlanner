using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMeetingPlanner.Models
{
    public partial class SacramentMeeting
    {
        public int SacramentMeetingId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime SacramentDate { get; set; }

        [Required]
        [Display(Name = "Conducting")]
        public int FkConducting { get; set; }

        [Display(Name = "Leading Music")]
        public int? FkMusicLeader { get; set; }

        [Display(Name = "Playing Piano")]
        public int? FkMusicPlayer { get; set; }

        [Display(Name = "Meeting Topic")]
        public int? FkMeetingTopic { get; set; }

        [Display(Name = "Baby Blessing?")]
        public bool BabyBlessing { get; set; }

        [Display(Name = "Confirmation?")]
        public bool Confirmation { get; set; }

        [Display(Name = "Opening Prayer")]
        public int? FkOpenPrayer { get; set; }

        [Display(Name = "Opening Hymn")]
        public int? FkOpenSong { get; set; }

        [Display(Name = "Sacrament Hymn")]
        public int? FkSacramentSong { get; set; }

        [Display(Name = "Youth Speaker")]
        public int? FkYouthSpeaker { get; set; }

        [Display(Name = "First Speaker")]
        public int? FkFirstSpeaker { get; set; }

        [Display(Name = "Second Speaker")]
        public int? FkSecondSpeaker { get; set; }

        [Display(Name = "Intermediate Hymn")]
        public int? FkIntermediateSong { get; set; }

        [Display(Name = "Closing Hymn")]
        public int? FkClosingSong { get; set; }

        [Display(Name = "Closing Prayer")]
        public int? FkClosingPrayer { get; set; }

       
        [Display(Name = "Conducting")]
        public virtual WardMember FkConductingNavigation { get; set; }
        [Display(Name = "Intermediate Hymn")]
        public virtual Hymn FkIntermediateSongNavigation { get; set; }
        [Display(Name = "Meeting Topic")]
        public virtual Topic FkMeetingTopicNavigation { get; set; }
        [Display(Name = "Leading Music")]
        public virtual WardMember FkMusicLeaderNavigation { get; set; }
        [Display(Name = "Playing Piano")]
        public virtual WardMember FkMusicPlayerNavigation { get; set; }
        [Display(Name = "Opening Prayer")]
        public virtual Prayer FkOpenPrayerNavigation { get; set; }
        [Display(Name = "Opening Hymn")]
        public virtual Hymn FkOpenSongNavigation { get; set; }
        [Display(Name = "Sacrament Hymn")]
        public virtual Hymn FkSacramentSongNavigation { get; set; }
        [Display(Name = "Closing Prayer")]
        public virtual Prayer FkClosingPrayerNavigation { get; set; }
        [Display(Name = "Closing Hymn")]
        public virtual Hymn FkClosingSongNavigation { get; set; }
    }
}
