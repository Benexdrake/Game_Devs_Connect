using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDevsConnect.Backend.API.Request.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "request",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileid = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ownerid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "request");
        }
    }
}
