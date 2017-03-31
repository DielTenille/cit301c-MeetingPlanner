using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyMeetingPlanner.Models;

namespace MyMeetingPlanner.Migrations
{
    [DbContext(typeof(MeetingPlannerContext))]
    [Migration("20170331033831_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyMeetingPlanner.Models.Calling", b =>
                {
                    b.Property<int>("CallingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CallingID");

                    b.Property<bool>("Bishopric")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("CallingName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("OtherLeader")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("CallingId");

                    b.ToTable("Calling");
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.Hymn", b =>
                {
                    b.Property<int>("HymnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("HymnID");

                    b.Property<int>("FkHymnType")
                        .HasColumnName("fk_HymnType");

                    b.Property<int?>("HymnNum");

                    b.Property<string>("HymnTitle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("HymnId");

                    b.HasIndex("FkHymnType");

                    b.ToTable("Hymn");
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.HymnType", b =>
                {
                    b.Property<int>("HymnTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("HymnTypeID");

                    b.Property<string>("HymnType1")
                        .IsRequired()
                        .HasColumnName("Hymn_Type")
                        .HasMaxLength(60);

                    b.HasKey("HymnTypeId");

                    b.ToTable("HymnType");
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.Prayer", b =>
                {
                    b.Property<int>("PrayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PrayerID");

                    b.Property<int>("FkPrayerType")
                        .HasColumnName("fk_PrayerType")
                        .HasMaxLength(100);

                    b.Property<int>("FkWardMemberId")
                        .HasColumnName("fk_WardMemberID");

                    b.Property<DateTime>("PrayerDate")
                        .HasColumnType("date");

                    b.HasKey("PrayerId");

                    b.HasIndex("FkPrayerType");

                    b.HasIndex("FkWardMemberId");

                    b.ToTable("Prayer");
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.PrayerType", b =>
                {
                    b.Property<int>("PrayerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PrayerTypeID");

                    b.Property<string>("TypePrayer")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("PrayerTypeId");

                    b.ToTable("PrayerType");
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.SacramentMeeting", b =>
                {
                    b.Property<int>("SacramentMeetingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SacramentMeetingID");

                    b.Property<bool?>("BabyBlessing")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<bool?>("Confirmation")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<int?>("FkClosingPrayer")
                        .HasColumnName("fk_ClosingPrayer");

                    b.Property<int?>("FkClosingSong")
                        .HasColumnName("fk_ClosingSong");

                    b.Property<int>("FkConducting")
                        .HasColumnName("fk_Conducting");

                    b.Property<int?>("FkFirstSpeaker")
                        .HasColumnName("fk_FirstSpeaker");

                    b.Property<int?>("FkIntermediateSong")
                        .HasColumnName("fk_IntermediateSong");

                    b.Property<int?>("FkMeetingTopic")
                        .HasColumnName("fk_MeetingTopic");

                    b.Property<int?>("FkMusicLeader")
                        .HasColumnName("fk_MusicLeader");

                    b.Property<int?>("FkMusicPlayer")
                        .HasColumnName("fk_MusicPlayer");

                    b.Property<int?>("FkOpenPrayer")
                        .HasColumnName("fk_OpenPrayer");

                    b.Property<int?>("FkOpenSong")
                        .HasColumnName("fk_OpenSong");

                    b.Property<int?>("FkSacramentSong")
                        .HasColumnName("fk_SacramentSong");

                    b.Property<int?>("FkSecondSpeaker")
                        .HasColumnName("fk_SecondSpeaker");

                    b.Property<int?>("FkYouthSpeaker")
                        .HasColumnName("fk_YouthSpeaker");

                    b.Property<DateTime>("SacramentDate")
                        .HasColumnType("date");

                    b.HasKey("SacramentMeetingId");

                    b.HasIndex("FkClosingPrayer");

                    b.HasIndex("FkClosingSong");

                    b.HasIndex("FkConducting");

                    b.HasIndex("FkIntermediateSong");

                    b.HasIndex("FkMeetingTopic");

                    b.HasIndex("FkMusicLeader");

                    b.HasIndex("FkMusicPlayer");

                    b.HasIndex("FkOpenPrayer");

                    b.HasIndex("FkOpenSong");

                    b.HasIndex("FkSacramentSong");

                    b.ToTable("SacramentMeeting");
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.Speaker", b =>
                {
                    b.Property<int>("SpeakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SpeakerID");

                    b.Property<int>("FkSpeakerType")
                        .HasColumnName("fk_SpeakerType");

                    b.Property<int?>("FkTopic")
                        .HasColumnName("fk_Topic");

                    b.Property<int>("FkWardMember")
                        .HasColumnName("fk_WardMember");

                    b.Property<DateTime>("SpeakerDate")
                        .HasColumnType("date");

                    b.HasKey("SpeakerId");

                    b.HasIndex("FkSpeakerType");

                    b.HasIndex("FkTopic");

                    b.HasIndex("FkWardMember");

                    b.ToTable("Speaker");
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.SpeakerType", b =>
                {
                    b.Property<int>("SpeakerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SpeakerTypeID");

                    b.Property<string>("SpeakerType1")
                        .IsRequired()
                        .HasColumnName("Speaker_Type")
                        .HasMaxLength(45);

                    b.HasKey("SpeakerTypeId");

                    b.ToTable("SpeakerType");
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TopicID");

                    b.Property<string>("TopicTitle")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("TopicId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.WardMember", b =>
                {
                    b.Property<int>("WardMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("WardMemberID");

                    b.Property<int>("FkCallingId")
                        .HasColumnName("fk_CallingID");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnName("FName")
                        .HasMaxLength(45);

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnName("LName")
                        .HasMaxLength(45);

                    b.HasKey("WardMemberId");

                    b.HasIndex("FkCallingId");

                    b.ToTable("WardMember");
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.Hymn", b =>
                {
                    b.HasOne("MyMeetingPlanner.Models.HymnType", "FkHymnTypeNavigation")
                        .WithMany("Hymn")
                        .HasForeignKey("FkHymnType")
                        .HasConstraintName("fk_Hymn_HymnType")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.Prayer", b =>
                {
                    b.HasOne("MyMeetingPlanner.Models.PrayerType", "FkPrayerTypeNavigation")
                        .WithMany("Prayer")
                        .HasForeignKey("FkPrayerType")
                        .HasConstraintName("fk_prayer_prayerType")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyMeetingPlanner.Models.WardMember", "FkWardMember")
                        .WithMany("Prayer")
                        .HasForeignKey("FkWardMemberId")
                        .HasConstraintName("fk_prayer_wardMember")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.SacramentMeeting", b =>
                {
                    b.HasOne("MyMeetingPlanner.Models.Prayer", "FkClosingPrayerNavigation")
                        .WithMany("SacramentMeetingFkClosingPrayerNavigation")
                        .HasForeignKey("FkClosingPrayer")
                        .HasConstraintName("fk_closing_meeting_prayer");

                    b.HasOne("MyMeetingPlanner.Models.Hymn", "FkClosingSongNavigation")
                        .WithMany("SacramentMeetingFkClosingSongNavigation")
                        .HasForeignKey("FkClosingSong")
                        .HasConstraintName("fk_closing_meeting_hymn");

                    b.HasOne("MyMeetingPlanner.Models.WardMember", "FkConductingNavigation")
                        .WithMany("SacramentMeetingFkConductingNavigation")
                        .HasForeignKey("FkConducting")
                        .HasConstraintName("fk_conducting_meeting_wardMember")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyMeetingPlanner.Models.Hymn", "FkIntermediateSongNavigation")
                        .WithMany("SacramentMeetingFkIntermediateSongNavigation")
                        .HasForeignKey("FkIntermediateSong")
                        .HasConstraintName("fk_intermediate_meeting_hymn");

                    b.HasOne("MyMeetingPlanner.Models.Topic", "FkMeetingTopicNavigation")
                        .WithMany("SacramentMeeting")
                        .HasForeignKey("FkMeetingTopic")
                        .HasConstraintName("fk_meeting_topic")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyMeetingPlanner.Models.WardMember", "FkMusicLeaderNavigation")
                        .WithMany("SacramentMeetingFkMusicLeaderNavigation")
                        .HasForeignKey("FkMusicLeader")
                        .HasConstraintName("fk_musicLeader_meeting_wardMember");

                    b.HasOne("MyMeetingPlanner.Models.WardMember", "FkMusicPlayerNavigation")
                        .WithMany("SacramentMeetingFkMusicPlayerNavigation")
                        .HasForeignKey("FkMusicPlayer")
                        .HasConstraintName("fk_musicPlayer_meeting_wardMember");

                    b.HasOne("MyMeetingPlanner.Models.Prayer", "FkOpenPrayerNavigation")
                        .WithMany("SacramentMeetingFkOpenPrayerNavigation")
                        .HasForeignKey("FkOpenPrayer")
                        .HasConstraintName("fk_open_meeting_prayer");

                    b.HasOne("MyMeetingPlanner.Models.Hymn", "FkOpenSongNavigation")
                        .WithMany("SacramentMeetingFkOpenSongNavigation")
                        .HasForeignKey("FkOpenSong")
                        .HasConstraintName("fk_open_meeting_hymn")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyMeetingPlanner.Models.Hymn", "FkSacramentSongNavigation")
                        .WithMany("SacramentMeetingFkSacramentSongNavigation")
                        .HasForeignKey("FkSacramentSong")
                        .HasConstraintName("fk_sacrament_meeting_hymn");
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.Speaker", b =>
                {
                    b.HasOne("MyMeetingPlanner.Models.SpeakerType", "FkSpeakerTypeNavigation")
                        .WithMany("Speaker")
                        .HasForeignKey("FkSpeakerType")
                        .HasConstraintName("fk_speaker_type")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyMeetingPlanner.Models.Topic", "FkTopicNavigation")
                        .WithMany("Speaker")
                        .HasForeignKey("FkTopic")
                        .HasConstraintName("fk_speaker_topic")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyMeetingPlanner.Models.WardMember", "FkWardMemberNavigation")
                        .WithMany("Speaker")
                        .HasForeignKey("FkWardMember")
                        .HasConstraintName("fk_speaker_wardMember")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyMeetingPlanner.Models.WardMember", b =>
                {
                    b.HasOne("MyMeetingPlanner.Models.Calling", "FkCalling")
                        .WithMany("WardMember")
                        .HasForeignKey("FkCallingId")
                        .HasConstraintName("fk_wardMember_calling")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
