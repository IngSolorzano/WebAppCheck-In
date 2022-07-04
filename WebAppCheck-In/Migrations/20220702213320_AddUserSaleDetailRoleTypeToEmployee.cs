using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCheck_In.Migrations
{
    public partial class AddUserSaleDetailRoleTypeToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeTypeId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeArea = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeType_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId",
                principalTable: "EmployeeType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeType_EmployeeTypeId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeTypeId",
                table: "Employees");
        }
    }
}
