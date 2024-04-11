using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myWebProj1.Migrations
{
    /// <inheritdoc />
    public partial class ModFieldAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "PizzaMenu");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PizzaMenu",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaMenu",
                table: "PizzaMenu",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaMenu",
                table: "PizzaMenu");

            migrationBuilder.RenameTable(
                name: "PizzaMenu",
                newName: "Pizzas");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pizzas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "Id");
        }
    }
}
