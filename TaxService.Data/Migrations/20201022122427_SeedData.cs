using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxService.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert vatrates select 23, 1");
            migrationBuilder.Sql("insert vatrates select 8, 0");
            migrationBuilder.Sql("insert vatrates select 5, 0");
            migrationBuilder.Sql("insert vatrates select 0, 0");

            migrationBuilder.Sql("insert vatgroups select 'building_service', 'Building Service', (select top(1) id from vatrates where rate=8)");
            migrationBuilder.Sql("insert vatgroups select 'books', 'Books', (select top(1) id from vatrates where rate=5)");
            migrationBuilder.Sql("insert vatgroups select 'newspapers', 'Newspapers ', (select top(1) id from vatrates where rate=5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from vatgroups");
            migrationBuilder.Sql("delete from vatrates");
        }
    }
}
