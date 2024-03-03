using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using RazorWeb.Models;

#nullable disable

namespace RazorWeb.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.ID);
                });

                Randomizer.Seed = new Random(8675309);
                var fakeArticle = new Faker<Article>();

                fakeArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
                fakeArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2000,1,1), new DateTime(2025,1,1)));
                fakeArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1,4));

                for(int i = 0; i < 150; ++i)
                {
                    Article article = fakeArticle.Generate();

                    migrationBuilder.InsertData(
                        table: "article",
                        columns: new [] {"Title", "Created", "Content"},
                        values: new object[] {
                            article.Title,
                            article.Created,
                            article.Content
                        }
                    );
                }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article");
        }
    }
}
