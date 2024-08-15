using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Updatedomainids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Trades",
                table: "Trades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidLists",
                table: "BidLists");

            migrationBuilder.DropColumn(
                name: "TradeId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "BidListId",
                table: "BidLists");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Trades",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Ratings",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BidLists",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trades",
                table: "Trades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidLists",
                table: "BidLists",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Trades",
                table: "Trades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidLists",
                table: "BidLists");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BidLists");

            migrationBuilder.AddColumn<int>(
                name: "TradeId",
                table: "Trades",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BidListId",
                table: "BidLists",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trades",
                table: "Trades",
                column: "TradeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "RatingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidLists",
                table: "BidLists",
                column: "BidListId");
        }
    }
}
