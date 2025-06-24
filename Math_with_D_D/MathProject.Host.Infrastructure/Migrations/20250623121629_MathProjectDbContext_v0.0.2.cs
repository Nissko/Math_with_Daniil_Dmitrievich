using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathProject.Host.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MathProjectDbContext_v002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "LearningTopics",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "LearningTopics");
        }
    }
}
