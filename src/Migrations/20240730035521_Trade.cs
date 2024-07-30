using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Trade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    TradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    BuyQuantity = table.Column<double>(nullable: false),
                    SellQuantity = table.Column<double>(nullable: false),
                    BuyPrice = table.Column<double>(nullable: false),
                    SellPrice = table.Column<double>(nullable: false),
                    Benchmark = table.Column<string>(nullable: true),
                    TradeDate = table.Column<DateTime>(nullable: false),
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
                    SourceListId = table.Column<string>(nullable: true),
                    Side = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.TradeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trades");
        }
    }
}
