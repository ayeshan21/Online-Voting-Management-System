using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Voting_System.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    n_id = table.Column<double>(type: "float", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.n_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");
        }
    }
}
