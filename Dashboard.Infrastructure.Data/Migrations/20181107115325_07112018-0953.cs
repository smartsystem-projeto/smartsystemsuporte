using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Infrastructure.Data.Migrations
{
    public partial class _071120180953 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rua = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(type: "varchar(40)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(20)", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: true),
                    ClienteId = table.Column<int>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposChamado",
                columns: table => new
                {
                    TipoChamadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Prioridade = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposChamado", x => x.TipoChamadoId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(50)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(50)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    TempoResposta = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Enderecos_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    NomeTratamento = table.Column<string>(type: "varchar(30)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Enderecos_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssuntosChamado",
                columns: table => new
                {
                    AssuntoChamadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    TipoChamadoId = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssuntosChamado", x => x.AssuntoChamadoId);
                    table.ForeignKey(
                        name: "FK_AssuntosChamado_TiposChamado_TipoChamadoId",
                        column: x => x.TipoChamadoId,
                        principalTable: "TiposChamado",
                        principalColumn: "TipoChamadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteProdutos",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteProdutos", x => new { x.ClienteId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_ClienteProdutos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClienteProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    TelefoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DDD = table.Column<int>(maxLength: 2, nullable: false),
                    Numero = table.Column<int>(maxLength: 9, nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.TelefoneId);
                    table.ForeignKey(
                        name: "FK_Telefones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Telefones_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(nullable: false),
                    Login = table.Column<string>(type: "varchar(16)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nivel = table.Column<string>(type: "varchar(20)", nullable: false),
                    Acessos = table.Column<int>(nullable: true),
                    UltimoAcesso = table.Column<DateTime>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chamados",
                columns: table => new
                {
                    ChamadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(type: "varchar(25)", nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    TipoChamadoId = table.Column<int>(nullable: false),
                    AssuntoChamadoId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", nullable: false),
                    Responsavel = table.Column<string>(type: "varchar(7)", nullable: true),
                    UltimoPosicionamento = table.Column<DateTime>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: true),
                    DataAbertura = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamados", x => x.ChamadoId);
                    table.ForeignKey(
                        name: "FK_Chamados_AssuntosChamado_AssuntoChamadoId",
                        column: x => x.AssuntoChamadoId,
                        principalTable: "AssuntosChamado",
                        principalColumn: "AssuntoChamadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamados_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamados_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamados_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamados_TiposChamado_TipoChamadoId",
                        column: x => x.TipoChamadoId,
                        principalTable: "TiposChamado",
                        principalColumn: "TipoChamadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PosicionamentosChamado",
                columns: table => new
                {
                    PosicionamentoChamadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(255)", nullable: false),
                    ChamadoId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosicionamentosChamado", x => x.PosicionamentoChamadoId);
                    table.ForeignKey(
                        name: "FK_PosicionamentosChamado_Chamados_ChamadoId",
                        column: x => x.ChamadoId,
                        principalTable: "Chamados",
                        principalColumn: "ChamadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PosicionamentosChamado_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PosicionamentosChamado_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "EnderecoId", "Bairro", "Cidade", "ClienteId", "FuncionarioId", "Numero", "Rua", "UF" },
                values: new object[] { 1, "Bairro", "Cidade", null, 1, 123, "Rua", "UF" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "CPF", "DataAtualizacao", "DataCadastro", "NomeTratamento", "Status" },
                values: new object[] { 1, "12345678912", null, new DateTime(2018, 11, 7, 9, 53, 25, 145, DateTimeKind.Local), "Admin", true });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Acessos", "ClienteId", "DataAtualizacao", "DataCadastro", "Email", "FuncionarioId", "Login", "Nivel", "Nome", "Senha", "Status", "UltimoAcesso" },
                values: new object[] { 1, null, null, null, new DateTime(2018, 11, 7, 9, 53, 25, 148, DateTimeKind.Local), "admin@email.com", 1, "admin", "Coordenador", "Administrador", "admin", true, null });

            migrationBuilder.CreateIndex(
                name: "IX_AssuntosChamado_TipoChamadoId",
                table: "AssuntosChamado",
                column: "TipoChamadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_AssuntoChamadoId",
                table: "Chamados",
                column: "AssuntoChamadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_ClienteId",
                table: "Chamados",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_FuncionarioId",
                table: "Chamados",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_ProdutoId",
                table: "Chamados",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_TipoChamadoId",
                table: "Chamados",
                column: "TipoChamadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteProdutos_ProdutoId",
                table: "ClienteProdutos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PosicionamentosChamado_ChamadoId",
                table: "PosicionamentosChamado",
                column: "ChamadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PosicionamentosChamado_ClienteId",
                table: "PosicionamentosChamado",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PosicionamentosChamado_FuncionarioId",
                table: "PosicionamentosChamado",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_ClienteId",
                table: "Telefones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_FuncionarioId",
                table: "Telefones",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ClienteId",
                table: "Usuarios",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FuncionarioId",
                table: "Usuarios",
                column: "FuncionarioId",
                unique: true,
                filter: "[FuncionarioId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteProdutos");

            migrationBuilder.DropTable(
                name: "PosicionamentosChamado");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Chamados");

            migrationBuilder.DropTable(
                name: "AssuntosChamado");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "TiposChamado");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
