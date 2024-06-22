using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegraCliente.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Integracao = table.Column<string>(type: "nvarchar(122)", maxLength: 122, nullable: true),
                    TpDoc = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Cgc = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Fantasia = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Fone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Cep = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
