using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Voting_System.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "User");
        }
    }
}
