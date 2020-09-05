using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektInzynierski.Migrations
{
    public partial class s17041mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobby",
                columns: table => new
                {
                    IdHobby = table.Column<int>(nullable: false),
                    HobbyName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Hobby_pk", x => x.IdHobby);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Surname = table.Column<string>(maxLength: 64, nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Avatar = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "User_Hobby",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false),
                    IdHobby = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_Hobby_pk", x => new { x.IdUser, x.IdHobby });
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(maxLength: 64, nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EventPlace = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Event_pk", x => x.IdEvent);
                    table.ForeignKey(
                        name: "Okazja_Uzytkownik",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gift",
                columns: table => new
                {
                    IdGift = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    Gift = table.Column<string>(maxLength: 64, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Size = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    Brand = table.Column<string>(maxLength: 30, nullable: true),
                    Color = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Gift_pk", x => x.IdGift);
                    table.ForeignKey(
                        name: "Prezent_Uzytkownik",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relation",
                columns: table => new
                {
                    IdRelation = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    IdUser_2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Relation_pk", x => x.IdRelation);
                    table.ForeignKey(
                        name: "Znajomosc_Uzytkownik",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Znajomosc_Uzytkownik_2",
                        column: x => x.IdUser_2,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventRelation",
                columns: table => new
                {
                    IdEventRelation = table.Column<int>(nullable: false),
                    IdEvent = table.Column<int>(nullable: false),
                    IdRelation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EventRelation_pk", x => x.IdEventRelation);
                    table.ForeignKey(
                        name: "Table_5_Okazja",
                        column: x => x.IdEvent,
                        principalTable: "Event",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OkazjaZnajomi_Znajomosc",
                        column: x => x.IdRelation,
                        principalTable: "Relation",
                        principalColumn: "IdRelation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gift_Relation_Event",
                columns: table => new
                {
                    IdGift = table.Column<int>(nullable: false),
                    IdRelation = table.Column<int>(nullable: false),
                    IdEvent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Gift_Relation_Event_pk", x => new { x.IdGift, x.IdRelation, x.IdEvent });
                    table.ForeignKey(
                        name: "Table_9_Okazja",
                        column: x => x.IdEvent,
                        principalTable: "Event",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_9_Prezent",
                        column: x => x.IdGift,
                        principalTable: "Gift",
                        principalColumn: "IdGift",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_9_Znajomosc",
                        column: x => x.IdRelation,
                        principalTable: "Relation",
                        principalColumn: "IdRelation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Forum_Event",
                columns: table => new
                {
                    IdEventRelation = table.Column<int>(nullable: false),
                    IdEvent = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Comment = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Forum_Event_pk", x => new { x.IdEventRelation, x.IdEvent, x.Date });
                    table.ForeignKey(
                        name: "Wpis_Okazja",
                        column: x => x.IdEvent,
                        principalTable: "Event",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Wpis_OkazjaZnajomi",
                        column: x => x.IdEventRelation,
                        principalTable: "EventRelation",
                        principalColumn: "IdEventRelation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_IdUser",
                table: "Event",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_EventRelation_IdEvent",
                table: "EventRelation",
                column: "IdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_EventRelation_IdRelation",
                table: "EventRelation",
                column: "IdRelation");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Event_IdEvent",
                table: "Forum_Event",
                column: "IdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Gift_IdUser",
                table: "Gift",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Gift_Relation_Event_IdEvent",
                table: "Gift_Relation_Event",
                column: "IdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Gift_Relation_Event_IdRelation",
                table: "Gift_Relation_Event",
                column: "IdRelation");

            migrationBuilder.CreateIndex(
                name: "IX_Relation_IdUser",
                table: "Relation",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Relation_IdUser_2",
                table: "Relation",
                column: "IdUser_2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forum_Event");

            migrationBuilder.DropTable(
                name: "Gift_Relation_Event");

            migrationBuilder.DropTable(
                name: "Hobby");

            migrationBuilder.DropTable(
                name: "User_Hobby");

            migrationBuilder.DropTable(
                name: "EventRelation");

            migrationBuilder.DropTable(
                name: "Gift");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Relation");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
