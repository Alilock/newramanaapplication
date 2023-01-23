using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    public partial class changeBaseEntit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_DeletedByUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Colors_AspNetUsers_CreatedByUserId",
                table: "Colors");

            migrationBuilder.DropForeignKey(
                name: "FK_Colors_AspNetUsers_DeletedByUserId",
                table: "Colors");

            migrationBuilder.DropForeignKey(
                name: "FK_Genders_AspNetUsers_CreatedByUserId",
                table: "Genders");

            migrationBuilder.DropForeignKey(
                name: "FK_Genders_AspNetUsers_DeletedByUserId",
                table: "Genders");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_AspNetUsers_CreatedByUserId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_AspNetUsers_DeletedByUserId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_AspNetUsers_CreatedByUserId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_AspNetUsers_DeletedByUserId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_DeletedByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeletedByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_CreatedByUserId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_DeletedByUserId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_Materials_CreatedByUserId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_DeletedByUserId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Genders_CreatedByUserId",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Genders_DeletedByUserId",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Colors_CreatedByUserId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_DeletedByUserId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DeletedByUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ProductImages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "ProductImages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Materials",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Materials",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Genders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Genders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Colors",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Colors",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Categories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Categories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeletedByUserId",
                table: "Products",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_CreatedByUserId",
                table: "ProductImages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_DeletedByUserId",
                table: "ProductImages",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CreatedByUserId",
                table: "Materials",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_DeletedByUserId",
                table: "Materials",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_CreatedByUserId",
                table: "Genders",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_DeletedByUserId",
                table: "Genders",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_CreatedByUserId",
                table: "Colors",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_DeletedByUserId",
                table: "Colors",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DeletedByUserId",
                table: "Categories",
                column: "DeletedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_DeletedByUserId",
                table: "Categories",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_AspNetUsers_CreatedByUserId",
                table: "Colors",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_AspNetUsers_DeletedByUserId",
                table: "Colors",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_AspNetUsers_CreatedByUserId",
                table: "Genders",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_AspNetUsers_DeletedByUserId",
                table: "Genders",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_AspNetUsers_CreatedByUserId",
                table: "Materials",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_AspNetUsers_DeletedByUserId",
                table: "Materials",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_AspNetUsers_CreatedByUserId",
                table: "ProductImages",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_AspNetUsers_DeletedByUserId",
                table: "ProductImages",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_DeletedByUserId",
                table: "Products",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
