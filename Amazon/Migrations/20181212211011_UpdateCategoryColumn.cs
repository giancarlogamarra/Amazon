using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazon.Migrations
{
    public partial class UpdateCategoryColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: "c8917d26-2244-48f6-b2fb-08d65e020523",
                column: "Category",
                value: "Technology"
            );
            migrationBuilder.UpdateData(
             table: "Books",
             keyColumn: "BookId",
             keyValue: "f0f96637-21df-4879-b2fc-08d65e020523",
             column: "Category",
             value: "Technology"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
              table: "Books",
              keyColumn: "BookId",
              keyValue: "c8917d26-2244-48f6-b2fb-08d65e020523",
              column: "Category",
              value: null
          );
            migrationBuilder.UpdateData(
             table: "Books",
             keyColumn: "BookId",
             keyValue: "f0f96637-21df-4879-b2fc-08d65e020523",
             column: "Category",
             value: null
            );
        }
    }
}
