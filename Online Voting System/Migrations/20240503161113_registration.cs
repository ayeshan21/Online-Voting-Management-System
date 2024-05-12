using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Voting_System.Migrations
{
    /// <inheritdoc />
    public partial class registration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "Login",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Login",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Login",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "mobile",
                table: "Login",
                newName: "Mobile");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Login",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Confirm_password",
                table: "Login",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Confirm_password",
                table: "Login");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Login",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Login",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Login",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "Login",
                newName: "mobile");
        }
    }
}
