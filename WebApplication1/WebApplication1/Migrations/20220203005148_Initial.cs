using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1_A.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rating = table.Column<string>(nullable: false),
                    Edit = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Science Fantasy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Fantasy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Science Fiction" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Adventure" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 5, "Complete Waste of Time (Romance)" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 6, "Partial Waste of Time (Romantic Comedy)" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 7, "The Perfect Movie- The Princess Bride" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edit", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Gareth Edwards", false, "", "", "PG-13", "Rogue One: A Star Wars Story", "2016" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edit", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 1, "Irvin Kershner", false, "", "", "PG-13", "Star Wars: Empire Strikes Back", "1980" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edit", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 2, "Chris Sanders", false, "", "", "PG", "How to Train Your Dragon", "2010" });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryID",
                table: "Movies",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
