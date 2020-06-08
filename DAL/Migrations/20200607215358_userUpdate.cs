using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class userUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUsers_UserContacts_UserContactsId1",
                table: "ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUsers_UserContactsId1",
                table: "ProjectUsers");

            migrationBuilder.DropColumn(
                name: "UserContactsId1",
                table: "ProjectUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserContactsId",
                table: "ProjectUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_UserContactsId",
                table: "ProjectUsers",
                column: "UserContactsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUsers_UserContacts_UserContactsId",
                table: "ProjectUsers",
                column: "UserContactsId",
                principalTable: "UserContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUsers_UserContacts_UserContactsId",
                table: "ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUsers_UserContactsId",
                table: "ProjectUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserContactsId",
                table: "ProjectUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserContactsId1",
                table: "ProjectUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_UserContactsId1",
                table: "ProjectUsers",
                column: "UserContactsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUsers_UserContacts_UserContactsId1",
                table: "ProjectUsers",
                column: "UserContactsId1",
                principalTable: "UserContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
