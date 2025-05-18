using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDevsConnect.Backend.Shared.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    request_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    file_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    owner_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    created = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    deleted = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__3213E83F66D90817", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    owner_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Files__3213E83FF08B3AF0", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    type = table.Column<int>(type: "int", nullable: true),
                    owner_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    seen = table.Column<bool>(type: "bit", nullable: false),
                    created = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83FFA33E195", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    discord_url = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    x_url = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    website_url = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    show_discord = table.Column<byte>(type: "tinyint", nullable: true),
                    show_x = table.Column<byte>(type: "tinyint", nullable: true),
                    show_website = table.Column<byte>(type: "tinyint", nullable: true),
                    show_email = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Profiles__3213E83F90589B08", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Project_Team",
                columns: table => new
                {
                    project_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    team_member_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    owner_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Projects__3213E83F52B40C40", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Request_Like",
                columns: table => new
                {
                    request_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    owner_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Request_Tag",
                columns: table => new
                {
                    request_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    tag_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    project_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    owner_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    file_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Requests__3213E83F7C3B1A3E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tag = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tags__3213E83FFFD2E1F7", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    avatar = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    accounttype = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83F1FAE596D", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Project_Team");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Request_Like");

            migrationBuilder.DropTable(
                name: "Request_Tag");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
