using Microsoft.EntityFrameworkCore.Migrations;
using MiniSaaSBackend.Migrations.Customs;

#nullable disable

namespace MiniSaaSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateUser("admin", "admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteUser("admin");
        }
    }
}
