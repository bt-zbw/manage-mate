using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class _20250623143034_PROD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Court_CourtId",
                table: "Hall");

            migrationBuilder.DropIndex(
                name: "IX_Hall_CourtId",
                table: "Hall");

            migrationBuilder.DropColumn(
                name: "CourtId",
                table: "Hall");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccessCodeUsed",
                table: "Reservation",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Court_HallId",
                table: "Court",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Court_Hall_HallId",
                table: "Court",
                column: "HallId",
                principalTable: "Hall",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Court_Hall_HallId",
                table: "Court");

            migrationBuilder.DropIndex(
                name: "IX_Court_HallId",
                table: "Court");

            migrationBuilder.DropColumn(
                name: "IsAccessCodeUsed",
                table: "Reservation");

            migrationBuilder.AddColumn<Guid>(
                name: "CourtId",
                table: "Hall",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hall_CourtId",
                table: "Hall",
                column: "CourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Court_CourtId",
                table: "Hall",
                column: "CourtId",
                principalTable: "Court",
                principalColumn: "Id");
        }
    }
}
