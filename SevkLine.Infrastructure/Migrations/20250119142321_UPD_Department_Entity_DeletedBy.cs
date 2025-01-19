using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SevkLine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UPD_Department_Entity_DeletedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Departments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Departments",
                type: "uuid",
                nullable: true);
        }
    }
}
