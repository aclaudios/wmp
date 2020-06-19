using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMotors.WebMotorsWeb.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_AnuncioWebmotors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(maxLength: 45, nullable: false),
                    Modelo = table.Column<string>(maxLength: 45, nullable: false),
                    Versao = table.Column<string>(maxLength: 45, nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Quilometragem = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_AnuncioWebmotors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tb_AnuncioWebmotors",
                columns: new[] { "Id", "Ano", "Marca", "Modelo", "Observacao", "Quilometragem", "Versao" },
                values: new object[,]
                {
                    { 1, 2020, "Tesla", "Cybertruck", "Tesla Cybertruck 2020 v1.0", 0, "1.0" },
                    { 2, 2019, "Tesla", "Roaster", "Tesla Roaster 2019 v1.0", 0, "1.0" },
                    { 3, 2020, "Fiat", "Argo", "Fiat Argo", 0, "1.0" },
                    { 4, 2020, "Ferrari", "Spider", "Ferrari Spider v1.0 2020", 0, "1.0" },
                    { 5, 2018, "Rolls-Royce", "Phanton", "Rolls-Royce Phanton VIII 2018", 0, "III" },
                    { 6, 2018, "Lamborghini", "Aventador", "Lamborghini aVentador 2020", 0, "1.0" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_AnuncioWebmotors");
        }
    }
}
