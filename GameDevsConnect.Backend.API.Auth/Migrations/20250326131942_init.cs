using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDevsConnect.Backend.API.Auth.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auth",
                columns: table => new
                {
                    userid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expires = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth", x => x.userid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auth");
        }
    }
}
