using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyMeetingPlanner.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calling",
                columns: table => new
                {
                    CallingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bishopric = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    CallingName = table.Column<string>(maxLength: 100, nullable: false),
                    OtherLeader = table.Column<bool>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calling", x => x.CallingID);
                });

            migrationBuilder.CreateTable(
                name: "HymnType",
                columns: table => new
                {
                    HymnTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hymn_Type = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HymnType", x => x.HymnTypeID);
                });

            migrationBuilder.CreateTable(
                name: "PrayerType",
                columns: table => new
                {
                    PrayerTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypePrayer = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrayerType", x => x.PrayerTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SpeakerType",
                columns: table => new
                {
                    SpeakerTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Speaker_Type = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerType", x => x.SpeakerTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    TopicID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TopicTitle = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.TopicID);
                });

            migrationBuilder.CreateTable(
                name: "WardMember",
                columns: table => new
                {
                    WardMemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_CallingID = table.Column<int>(nullable: false),
                    FName = table.Column<string>(maxLength: 45, nullable: false),
                    LName = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardMember", x => x.WardMemberID);
                    table.ForeignKey(
                        name: "fk_wardMember_calling",
                        column: x => x.fk_CallingID,
                        principalTable: "Calling",
                        principalColumn: "CallingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    HymnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_HymnType = table.Column<int>(nullable: false),
                    HymnNum = table.Column<int>(nullable: true),
                    HymnTitle = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.HymnID);
                    table.ForeignKey(
                        name: "fk_Hymn_HymnType",
                        column: x => x.fk_HymnType,
                        principalTable: "HymnType",
                        principalColumn: "HymnTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prayer",
                columns: table => new
                {
                    PrayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_PrayerType = table.Column<int>(maxLength: 100, nullable: false),
                    fk_WardMemberID = table.Column<int>(nullable: false),
                    PrayerDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prayer", x => x.PrayerID);
                    table.ForeignKey(
                        name: "fk_prayer_prayerType",
                        column: x => x.fk_PrayerType,
                        principalTable: "PrayerType",
                        principalColumn: "PrayerTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_prayer_wardMember",
                        column: x => x.fk_WardMemberID,
                        principalTable: "WardMember",
                        principalColumn: "WardMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_SpeakerType = table.Column<int>(nullable: false),
                    fk_Topic = table.Column<int>(nullable: true),
                    fk_WardMember = table.Column<int>(nullable: false),
                    SpeakerDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerID);
                    table.ForeignKey(
                        name: "fk_speaker_type",
                        column: x => x.fk_SpeakerType,
                        principalTable: "SpeakerType",
                        principalColumn: "SpeakerTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_speaker_topic",
                        column: x => x.fk_Topic,
                        principalTable: "Topic",
                        principalColumn: "TopicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_speaker_wardMember",
                        column: x => x.fk_WardMember,
                        principalTable: "WardMember",
                        principalColumn: "WardMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SacramentMeeting",
                columns: table => new
                {
                    SacramentMeetingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BabyBlessing = table.Column<bool>(nullable: true, defaultValueSql: "0"),
                    Confirmation = table.Column<bool>(nullable: true, defaultValueSql: "0"),
                    fk_ClosingPrayer = table.Column<int>(nullable: true),
                    fk_ClosingSong = table.Column<int>(nullable: true),
                    fk_Conducting = table.Column<int>(nullable: false),
                    fk_FirstSpeaker = table.Column<int>(nullable: true),
                    fk_IntermediateSong = table.Column<int>(nullable: true),
                    fk_MeetingTopic = table.Column<int>(nullable: true),
                    fk_MusicLeader = table.Column<int>(nullable: true),
                    fk_MusicPlayer = table.Column<int>(nullable: true),
                    fk_OpenPrayer = table.Column<int>(nullable: true),
                    fk_OpenSong = table.Column<int>(nullable: true),
                    fk_SacramentSong = table.Column<int>(nullable: true),
                    fk_SecondSpeaker = table.Column<int>(nullable: true),
                    fk_YouthSpeaker = table.Column<int>(nullable: true),
                    SacramentDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacramentMeeting", x => x.SacramentMeetingID);
                    table.ForeignKey(
                        name: "fk_closing_meeting_prayer",
                        column: x => x.fk_ClosingPrayer,
                        principalTable: "Prayer",
                        principalColumn: "PrayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_closing_meeting_hymn",
                        column: x => x.fk_ClosingSong,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_conducting_meeting_wardMember",
                        column: x => x.fk_Conducting,
                        principalTable: "WardMember",
                        principalColumn: "WardMemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_intermediate_meeting_hymn",
                        column: x => x.fk_IntermediateSong,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_meeting_topic",
                        column: x => x.fk_MeetingTopic,
                        principalTable: "Topic",
                        principalColumn: "TopicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_musicLeader_meeting_wardMember",
                        column: x => x.fk_MusicLeader,
                        principalTable: "WardMember",
                        principalColumn: "WardMemberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_musicPlayer_meeting_wardMember",
                        column: x => x.fk_MusicPlayer,
                        principalTable: "WardMember",
                        principalColumn: "WardMemberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_open_meeting_prayer",
                        column: x => x.fk_OpenPrayer,
                        principalTable: "Prayer",
                        principalColumn: "PrayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_open_meeting_hymn",
                        column: x => x.fk_OpenSong,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sacrament_meeting_hymn",
                        column: x => x.fk_SacramentSong,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hymn_fk_HymnType",
                table: "Hymn",
                column: "fk_HymnType");

            migrationBuilder.CreateIndex(
                name: "IX_Prayer_fk_PrayerType",
                table: "Prayer",
                column: "fk_PrayerType");

            migrationBuilder.CreateIndex(
                name: "IX_Prayer_fk_WardMemberID",
                table: "Prayer",
                column: "fk_WardMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_fk_ClosingPrayer",
                table: "SacramentMeeting",
                column: "fk_ClosingPrayer");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_fk_ClosingSong",
                table: "SacramentMeeting",
                column: "fk_ClosingSong");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_fk_Conducting",
                table: "SacramentMeeting",
                column: "fk_Conducting");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_fk_IntermediateSong",
                table: "SacramentMeeting",
                column: "fk_IntermediateSong");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_fk_MeetingTopic",
                table: "SacramentMeeting",
                column: "fk_MeetingTopic");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_fk_MusicLeader",
                table: "SacramentMeeting",
                column: "fk_MusicLeader");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_fk_MusicPlayer",
                table: "SacramentMeeting",
                column: "fk_MusicPlayer");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_fk_OpenPrayer",
                table: "SacramentMeeting",
                column: "fk_OpenPrayer");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_fk_OpenSong",
                table: "SacramentMeeting",
                column: "fk_OpenSong");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeeting_fk_SacramentSong",
                table: "SacramentMeeting",
                column: "fk_SacramentSong");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_fk_SpeakerType",
                table: "Speaker",
                column: "fk_SpeakerType");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_fk_Topic",
                table: "Speaker",
                column: "fk_Topic");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_fk_WardMember",
                table: "Speaker",
                column: "fk_WardMember");

            migrationBuilder.CreateIndex(
                name: "IX_WardMember_fk_CallingID",
                table: "WardMember",
                column: "fk_CallingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SacramentMeeting");

            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "Prayer");

            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "SpeakerType");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "PrayerType");

            migrationBuilder.DropTable(
                name: "WardMember");

            migrationBuilder.DropTable(
                name: "HymnType");

            migrationBuilder.DropTable(
                name: "Calling");
        }
    }
}
