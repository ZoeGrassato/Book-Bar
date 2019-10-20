using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibraryV2.Data.Migrations
{
    public partial class UserBookOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userBookOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    BookName = table.Column<string>(nullable: true),
                    BookGenre = table.Column<string>(nullable:true),
                    DateCreated = table.Column<string>(nullable:true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userBookOrders", x => x.Id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
