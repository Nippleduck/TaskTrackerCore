using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class PropFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_IdentityId",
                table: "ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUsers_IdentityId",
                table: "ProjectUsers");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "ProjectUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ProjectUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_ApplicationUserId",
                table: "ProjectUsers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_ApplicationUserId",
                table: "ProjectUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_ApplicationUserId",
                table: "ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUsers_ApplicationUserId",
                table: "ProjectUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ProjectUsers");

            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "ProjectUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_IdentityId",
                table: "ProjectUsers",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_IdentityId",
                table: "ProjectUsers",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
