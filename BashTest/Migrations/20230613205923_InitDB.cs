using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BashTest.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "varchar(250)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shifr = table.Column<string>(type: "varchar(250)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsPacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    MarkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsPacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentsPacks_Marks_MarkId",
                        column: x => x.MarkId,
                        principalTable: "Marks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(250)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectItems_ProjectItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProjectItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItemsDocuments",
                columns: table => new
                {
                    DocumentsPackId = table.Column<int>(type: "int", nullable: false),
                    ProjectItemId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItemsDocuments", x => new { x.ProjectItemId, x.DocumentsPackId });
                    table.ForeignKey(
                        name: "FK_ProjectItemsDocuments_DocumentsPacks_DocumentsPackId",
                        column: x => x.DocumentsPackId,
                        principalTable: "DocumentsPacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectItemsDocuments_ProjectItems_ProjectItemId",
                        column: x => x.ProjectItemId,
                        principalTable: "ProjectItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "FullName", "ShortName" },
                values: new object[,]
                {
                    { 1, "Mark One", "Mark 1" },
                    { 2, "Mark Two", "Mark 2" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name", "Shifr" },
                values: new object[,]
                {
                    { 1, "Project 1", "pr-1" },
                    { 2, "Project 2", "pr-2" }
                });

            migrationBuilder.InsertData(
                table: "DocumentsPacks",
                columns: new[] { "Id", "MarkId", "Number" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "ProjectItems",
                columns: new[] { "Id", "Code", "Name", "ParentId", "ProjectId" },
                values: new object[,]
                {
                    { 1, "Code 1", "Name Item 1", null, 1 },
                    { 3, "Code 3", "Name Item 3", null, 2 },
                    { 2, "Code 2", "Name Item 2", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProjectItemsDocuments",
                columns: new[] { "DocumentsPackId", "ProjectItemId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 4, 3, 4 },
                    { 3, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsPacks_MarkId",
                table: "DocumentsPacks",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ParentId",
                table: "ProjectItems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ProjectId",
                table: "ProjectItems",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItemsDocuments_DocumentsPackId",
                table: "ProjectItemsDocuments",
                column: "DocumentsPackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectItemsDocuments");

            migrationBuilder.DropTable(
                name: "DocumentsPacks");

            migrationBuilder.DropTable(
                name: "ProjectItems");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
