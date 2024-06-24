using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class UserAndBidList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BidLists",
                columns: table => new
                {
                    BidListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    BidQuantity = table.Column<double>(nullable: false),
                    AskQuantity = table.Column<double>(nullable: false),
                    Bid = table.Column<double>(nullable: false),
                    Ask = table.Column<double>(nullable: false),
                    Benchmark = table.Column<string>(nullable: true),
                    BidListDate = table.Column<DateTime>(nullable: false),
                    Commentary = table.Column<string>(nullable: true),
                    Security = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Trader = table.Column<string>(nullable: true),
                    Book = table.Column<string>(nullable: true),
                    CreationName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    RevisionName = table.Column<string>(nullable: true),
                    RevisionDate = table.Column<DateTime>(nullable: false),
                    DealName = table.Column<string>(nullable: true),
                    DealType = table.Column<string>(nullable: true),
                    SouceListId = table.Column<string>(nullable: true),
                    Side = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidLists", x => x.BidListId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
