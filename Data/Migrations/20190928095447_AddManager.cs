using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibraryV2.Data.Migrations
{
    public partial class AddManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, 
                                  SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
                                  VALUES('55aeb6c1-70e5-4d8a-a75d-7b219a8bbd14', 'manager@library.co.za', 'MANAGER@LIBRARY.CO.ZA', 'manager@library.co.za', 'MANAGER@LIBRARY.CO.ZA', 1, 
                                  'AQAAAAEAACcQAAAAEPm/XqD3FlxAk3Jl4W5m/d4lTfLRwOxniDvkO04E10rEDwecHnRrglRea1VMlYTj2g==', 
                                  'RVE5SDI5UWFRFHU2XLJRJPWV5GUUNLOB', 'b951dc6d-c5da-4ede-8214-aec8043bb595', 0, 0, 0, 0)");

            migrationBuilder.Sql(@"INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                                   VALUES('412b16bb-bea7-4e6b-aec2-729566df79cf', 'Administrator', 'ADMINISTRATOR')");

            migrationBuilder.Sql(@"INSERT INTO AspNetUserRoles(UserId, RoleId)
                                   VALUES('55aeb6c1-70e5-4d8a-a75d-7b219a8bbd14', '412b16bb-bea7-4e6b-aec2-729566df79cf')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
