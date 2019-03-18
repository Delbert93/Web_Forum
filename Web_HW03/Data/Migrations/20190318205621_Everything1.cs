using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_HW03.Migrations
{
    public partial class Everything1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentsId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogPostId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentsId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentsId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TagId",
                table: "Comments",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogPosts_Id",
                table: "Comments",
                column: "Id",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tags_TagId",
                table: "Comments",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogPosts_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tags_TagId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TagId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentsId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogPostId",
                table: "Comments",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentsId",
                table: "Comments",
                column: "CommentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId",
                table: "Comments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentsId",
                table: "Comments",
                column: "CommentsId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
