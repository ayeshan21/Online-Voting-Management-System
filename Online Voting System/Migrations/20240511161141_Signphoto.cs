using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Voting_System.Migrations
{
    /// <inheritdoc />
    public partial class Signphoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sign_photoURL",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sign_photoURL",
                table: "User");
        }
    }
}
