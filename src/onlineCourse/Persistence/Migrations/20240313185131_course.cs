using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ef66f430-1058-4852-8b7b-bd9effd2b575"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6a3e8274-f96d-41e1-83fd-6358410bd902"));

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseContent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseContent_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    FileSize = table.Column<double>(type: "float", nullable: false),
                    CourseContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDocument_CourseContent_CourseContentId",
                        column: x => x.CourseContentId,
                        principalTable: "CourseContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Admin", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Read", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Write", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Create", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Update", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("7867f6e1-6b14-4895-9723-0c0cc511e6d6"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 236, 44, 240, 171, 27, 190, 159, 153, 172, 93, 103, 17, 181, 6, 213, 14, 17, 202, 132, 186, 180, 133, 246, 249, 50, 128, 212, 227, 10, 8, 188, 208, 121, 242, 234, 163, 235, 128, 189, 226, 65, 125, 118, 88, 152, 194, 66, 94, 170, 223, 124, 14, 64, 95, 133, 204, 25, 64, 171, 122, 56, 24, 4, 225 }, new byte[] { 154, 200, 242, 244, 132, 26, 7, 7, 147, 115, 88, 181, 23, 45, 233, 191, 152, 160, 193, 216, 78, 115, 34, 243, 137, 229, 202, 245, 124, 173, 247, 219, 153, 109, 139, 167, 152, 215, 180, 185, 35, 116, 148, 134, 248, 97, 214, 104, 230, 22, 40, 85, 18, 71, 253, 141, 157, 153, 125, 177, 136, 81, 172, 73, 24, 4, 200, 243, 235, 136, 196, 206, 206, 230, 222, 14, 125, 217, 213, 19, 227, 75, 70, 134, 27, 148, 145, 82, 215, 172, 34, 21, 169, 33, 159, 243, 32, 115, 184, 17, 19, 10, 20, 147, 228, 201, 131, 230, 198, 107, 27, 36, 24, 182, 61, 229, 34, 187, 240, 85, 92, 9, 156, 122, 52, 24, 188, 172 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("93ea5777-a6dc-45a5-9769-2b13e30105f2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("7867f6e1-6b14-4895-9723-0c0cc511e6d6") });

            migrationBuilder.CreateIndex(
                name: "IX_CourseContent_CourseId",
                table: "CourseContent",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDocument_CourseContentId",
                table: "CourseDocument",
                column: "CourseContentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDocument");

            migrationBuilder.DropTable(
                name: "CourseContent");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("93ea5777-a6dc-45a5-9769-2b13e30105f2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7867f6e1-6b14-4895-9723-0c0cc511e6d6"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("6a3e8274-f96d-41e1-83fd-6358410bd902"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 74, 27, 166, 43, 110, 38, 33, 249, 98, 58, 198, 4, 136, 210, 161, 210, 229, 66, 155, 167, 50, 182, 154, 55, 139, 97, 168, 168, 42, 109, 48, 228, 170, 141, 109, 249, 148, 223, 95, 32, 195, 16, 68, 247, 111, 204, 7, 85, 139, 93, 30, 220, 63, 148, 185, 26, 222, 142, 70, 19, 132, 214, 44, 84 }, new byte[] { 172, 117, 91, 154, 60, 98, 218, 218, 215, 34, 28, 210, 7, 222, 179, 29, 207, 200, 193, 187, 48, 62, 147, 126, 79, 160, 126, 183, 65, 27, 111, 27, 67, 245, 87, 184, 14, 207, 177, 152, 181, 50, 249, 226, 238, 6, 223, 192, 74, 199, 13, 226, 103, 78, 196, 101, 74, 157, 181, 224, 22, 95, 31, 129, 147, 232, 230, 237, 48, 154, 17, 28, 204, 50, 178, 151, 174, 224, 203, 150, 249, 175, 150, 73, 89, 138, 15, 66, 225, 205, 209, 66, 5, 77, 185, 234, 248, 139, 56, 71, 206, 187, 162, 27, 161, 224, 110, 198, 80, 118, 215, 122, 142, 90, 34, 100, 94, 145, 66, 121, 245, 20, 30, 153, 127, 62, 243, 140 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("ef66f430-1058-4852-8b7b-bd9effd2b575"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6a3e8274-f96d-41e1-83fd-6358410bd902") });
        }
    }
}
