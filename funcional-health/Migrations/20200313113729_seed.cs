using Microsoft.EntityFrameworkCore.Migrations;

namespace funcional_health.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ContasCorrentes (AccountNumber, Balance) VALUES ('123456', 1000)");
            migrationBuilder.Sql("INSERT INTO ContasCorrentes (AccountNumber, Balance) VALUES ('654321', 100)");
            migrationBuilder.Sql("INSERT INTO ContasCorrentes (AccountNumber, Balance) VALUES ('567890', 320)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ContasCorrentes WHERE AccountNumber = 123456");
            migrationBuilder.Sql("DELETE FROM ContasCorrentes WHERE AccountNumber = 654321");
            migrationBuilder.Sql("DELETE FROM ContasCorrentes WHERE AccountNumber = 567890");
        }
    }
}
