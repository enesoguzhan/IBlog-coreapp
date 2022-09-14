using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBlog.DataAccess.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreationDatetime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 9, 13, 14, 35, 58, 975, DateTimeKind.Local).AddTicks(6118)),
                    RoleType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 9, 13, 14, 35, 58, 976, DateTimeKind.Local).AddTicks(1064)),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Github = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Linkedin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialLinks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 9, 13, 14, 35, 58, 976, DateTimeKind.Local).AddTicks(4445)),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteracitonType = table.Column<bool>(type: "bit", nullable: false),
                    InteractionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 9, 13, 14, 35, 58, 976, DateTimeKind.Local).AddTicks(5660)),
                    IpAddress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interactions_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("739a8565-1df4-4c5b-be8a-73e9b81ab7b3"), "Oyun" },
                    { new Guid("9bda077c-2be9-4170-80ad-98164040c761"), "Spor" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarImage", "CreationDatetime", "Email", "Explanation", "Name", "Password", "RoleType", "Surname" },
                values: new object[,]
                {
                    { new Guid("475a613b-f8d4-45ee-82ee-1003f267814e"), "b91f2c8d-1c82-4b86-9bb7-44ee5649bb20.jpg", new DateTime(2022, 9, 13, 14, 35, 58, 975, DateTimeKind.Local).AddTicks(8296), "yucar@gmail.com", "Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test ", "Yusuf", "58775877", 0, "Uçar" },
                    { new Guid("577d0a6c-cfbe-4d1e-940a-50b9d1e6d5a3"), "d7f30a1e-a537-45b6-899c-dee04ecc555b.jpg", new DateTime(2022, 9, 13, 14, 35, 58, 975, DateTimeKind.Local).AddTicks(8302), "earaci@gmail.com", "Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama777777777585858", "Enes Oğuzhan", "58775877", 1, "Aracı" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_BlogId",
                table: "Images",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_BlogId",
                table: "Interactions",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_UserId",
                table: "SocialLinks",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
