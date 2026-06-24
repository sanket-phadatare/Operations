using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst1.Migrations
{
    /// <inheritdoc />
    public partial class AddedOnenewPropinModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Students");
        }
    }
}
