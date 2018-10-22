using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCorePro.Migrations.aplicationdbcontext
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TodoItemDetailId",
                table: "TodoItem",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TodoItemDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItemDetail", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_TodoItemDetailId",
                table: "TodoItem",
                column: "TodoItemDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_TodoItemDetail_TodoItemDetailId",
                table: "TodoItem",
                column: "TodoItemDetailId",
                principalTable: "TodoItemDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_TodoItemDetail_TodoItemDetailId",
                table: "TodoItem");

            migrationBuilder.DropTable(
                name: "TodoItemDetail");

            migrationBuilder.DropIndex(
                name: "IX_TodoItem_TodoItemDetailId",
                table: "TodoItem");

            migrationBuilder.DropColumn(
                name: "TodoItemDetailId",
                table: "TodoItem");
        }
    }
}
