using Microsoft.EntityFrameworkCore.Migrations;

namespace T4i_WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dev",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    position = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dev", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projetos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projetos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "works",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    equipe = table.Column<string>(type: "TEXT", nullable: true),
                    devid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_works", x => x.id);
                    table.ForeignKey(
                        name: "FK_works_dev_devid",
                        column: x => x.devid,
                        principalTable: "dev",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pw",
                columns: table => new
                {
                    projetoId = table.Column<int>(type: "INTEGER", nullable: false),
                    worksId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pw", x => new { x.projetoId, x.worksId });
                    table.ForeignKey(
                        name: "FK_pw_projetos_projetoId",
                        column: x => x.projetoId,
                        principalTable: "projetos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pw_works_worksId",
                        column: x => x.worksId,
                        principalTable: "works",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dev",
                columns: new[] { "id", "name", "position" },
                values: new object[] { 1, "Alessandro Bezerra", "Engenheiro de Dados" });

            migrationBuilder.InsertData(
                table: "dev",
                columns: new[] { "id", "name", "position" },
                values: new object[] { 2, "Juliane", "Engenheira de software" });

            migrationBuilder.InsertData(
                table: "dev",
                columns: new[] { "id", "name", "position" },
                values: new object[] { 3, "Samuel", "Analista Sênior" });

            migrationBuilder.InsertData(
                table: "dev",
                columns: new[] { "id", "name", "position" },
                values: new object[] { 4, "André Silva", "Engenheiro de software" });

            migrationBuilder.InsertData(
                table: "dev",
                columns: new[] { "id", "name", "position" },
                values: new object[] { 5, "Anderson Gonçalves", "Estagiário full-stack" });

            migrationBuilder.InsertData(
                table: "dev",
                columns: new[] { "id", "name", "position" },
                values: new object[] { 6, "Rodrigo Nunes de Lucena", "Desenvolvedor de software sênior" });

            migrationBuilder.InsertData(
                table: "dev",
                columns: new[] { "id", "name", "position" },
                values: new object[] { 7, "Tomaz Santos Junior", "Engenheiro de sofware full-Stack Sênior" });

            migrationBuilder.InsertData(
                table: "dev",
                columns: new[] { "id", "name", "position" },
                values: new object[] { 8, "Igor Albuquerque", "Engenheiro de software" });

            migrationBuilder.InsertData(
                table: "dev",
                columns: new[] { "id", "name", "position" },
                values: new object[] { 9, "Vinicius Santos", "Estagiário Futuro Engenheiro" });

            migrationBuilder.InsertData(
                table: "projetos",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 1, "Rede de contatos e negócios", "NetWorks" });

            migrationBuilder.InsertData(
                table: "projetos",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 2, "Sistema para administração de serviços", "System For T4i" });

            migrationBuilder.InsertData(
                table: "projetos",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 3, "Sistema para verificar pré-requisitos de padrões de arquitetura dentro de um software", "System For Google" });

            migrationBuilder.InsertData(
                table: "projetos",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 4, "Melhorias em nosso sistema", "Upgrade Our System" });

            migrationBuilder.InsertData(
                table: "projetos",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 5, "Planejar, estruturar e criar um sistema inovador", "Create An Innovative System" });

            migrationBuilder.InsertData(
                table: "works",
                columns: new[] { "id", "devid", "equipe" },
                values: new object[] { 1, 2, "Equipe A" });

            migrationBuilder.InsertData(
                table: "works",
                columns: new[] { "id", "devid", "equipe" },
                values: new object[] { 2, 3, "Equipe B" });

            migrationBuilder.InsertData(
                table: "works",
                columns: new[] { "id", "devid", "equipe" },
                values: new object[] { 3, 5, "Equipe C" });

            migrationBuilder.InsertData(
                table: "works",
                columns: new[] { "id", "devid", "equipe" },
                values: new object[] { 4, 8, "Equipe E" });

            migrationBuilder.InsertData(
                table: "works",
                columns: new[] { "id", "devid", "equipe" },
                values: new object[] { 5, 9, "Equipe D" });

            migrationBuilder.InsertData(
                table: "pw",
                columns: new[] { "projetoId", "worksId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "pw",
                columns: new[] { "projetoId", "worksId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "pw",
                columns: new[] { "projetoId", "worksId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "pw",
                columns: new[] { "projetoId", "worksId" },
                values: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "pw",
                columns: new[] { "projetoId", "worksId" },
                values: new object[] { 5, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_pw_worksId",
                table: "pw",
                column: "worksId");

            migrationBuilder.CreateIndex(
                name: "IX_works_devid",
                table: "works",
                column: "devid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pw");

            migrationBuilder.DropTable(
                name: "projetos");

            migrationBuilder.DropTable(
                name: "works");

            migrationBuilder.DropTable(
                name: "dev");
        }
    }
}
