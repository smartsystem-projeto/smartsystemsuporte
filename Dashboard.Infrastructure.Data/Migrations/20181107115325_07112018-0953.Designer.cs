﻿// <auto-generated />
using System;
using Dashboard.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dashboard.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DashboardContext))]
    [Migration("20181107115325_07112018-0953")]
    partial class _071120180953
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dashboard.Domain.Entities.AssuntoChamado", b =>
                {
                    b.Property<int>("AssuntoChamadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAtualizacao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TipoChamadoId");

                    b.HasKey("AssuntoChamadoId");

                    b.HasIndex("TipoChamadoId");

                    b.ToTable("AssuntosChamado");
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Chamado", b =>
                {
                    b.Property<int>("ChamadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssuntoChamadoId");

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("DataAbertura");

                    b.Property<DateTime?>("DataAtualizacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("FuncionarioId");

                    b.Property<int>("ProdutoId");

                    b.Property<string>("Responsavel")
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<int>("TipoChamadoId");

                    b.Property<DateTime?>("UltimoPosicionamento");

                    b.HasKey("ChamadoId");

                    b.HasIndex("AssuntoChamadoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("TipoChamadoId");

                    b.ToTable("Chamados");
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId");

                    b.Property<string>("CNPJ")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime?>("DataAtualizacao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Status");

                    b.Property<int?>("TempoResposta");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.ClienteProduto", b =>
                {
                    b.Property<int>("ClienteId");

                    b.Property<int>("ProdutoId");

                    b.HasKey("ClienteId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ClienteProdutos");
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("ClienteId");

                    b.Property<int?>("FuncionarioId");

                    b.Property<int>("Numero");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UF")
                        .HasColumnType("varchar(2)");

                    b.HasKey("EnderecoId");

                    b.ToTable("Enderecos");

                    b.HasData(
                        new { EnderecoId = 1, Bairro = "Bairro", Cidade = "Cidade", FuncionarioId = 1, Numero = 123, Rua = "Rua", UF = "UF" }
                    );
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime?>("DataAtualizacao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("NomeTratamento")
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("Status");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");

                    b.HasData(
                        new { FuncionarioId = 1, CPF = "12345678912", DataCadastro = new DateTime(2018, 11, 7, 9, 53, 25, 145, DateTimeKind.Local), NomeTratamento = "Admin", Status = true }
                    );
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.PosicionamentoChamado", b =>
                {
                    b.Property<int>("PosicionamentoChamadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChamadoId");

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime?>("DataAtualizacao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("FuncionarioId");

                    b.HasKey("PosicionamentoChamadoId");

                    b.HasIndex("ChamadoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("PosicionamentosChamado");
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAtualizacao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Telefone", b =>
                {
                    b.Property<int>("TelefoneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId");

                    b.Property<int>("DDD")
                        .HasMaxLength(2);

                    b.Property<int?>("FuncionarioId");

                    b.Property<int>("Numero")
                        .HasMaxLength(9);

                    b.HasKey("TelefoneId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.TipoChamado", b =>
                {
                    b.Property<int>("TipoChamadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAtualizacao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Prioridade");

                    b.HasKey("TipoChamadoId");

                    b.ToTable("TiposChamado");
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Acessos");

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime?>("DataAtualizacao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("FuncionarioId");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UltimoAcesso");

                    b.HasKey("UsuarioId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId")
                        .IsUnique()
                        .HasFilter("[FuncionarioId] IS NOT NULL");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new { UsuarioId = 1, DataCadastro = new DateTime(2018, 11, 7, 9, 53, 25, 148, DateTimeKind.Local), Email = "admin@email.com", FuncionarioId = 1, Login = "admin", Nivel = "Coordenador", Nome = "Administrador", Senha = "admin", Status = true }
                    );
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.AssuntoChamado", b =>
                {
                    b.HasOne("Dashboard.Domain.Entities.TipoChamado", "TipoChamado")
                        .WithMany("AssuntosChamado")
                        .HasForeignKey("TipoChamadoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Chamado", b =>
                {
                    b.HasOne("Dashboard.Domain.Entities.AssuntoChamado", "AssuntoChamado")
                        .WithMany("Chamados")
                        .HasForeignKey("AssuntoChamadoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Dashboard.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Chamados")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Dashboard.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("Chamados")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Dashboard.Domain.Entities.Produto", "Produto")
                        .WithMany("Chamados")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Dashboard.Domain.Entities.TipoChamado", "TipoChamado")
                        .WithMany("Chamados")
                        .HasForeignKey("TipoChamadoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("Dashboard.Domain.Entities.Endereco", "Endereco")
                        .WithOne("Cliente")
                        .HasForeignKey("Dashboard.Domain.Entities.Cliente", "ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.ClienteProduto", b =>
                {
                    b.HasOne("Dashboard.Domain.Entities.Cliente", "Cliente")
                        .WithMany("ClienteProdutos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Dashboard.Domain.Entities.Produto", "Produto")
                        .WithMany("ClienteProdutos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("Dashboard.Domain.Entities.Endereco", "Endereco")
                        .WithOne("Funcionario")
                        .HasForeignKey("Dashboard.Domain.Entities.Funcionario", "FuncionarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.PosicionamentoChamado", b =>
                {
                    b.HasOne("Dashboard.Domain.Entities.Chamado", "Chamado")
                        .WithMany("PosicionamentosChamado")
                        .HasForeignKey("ChamadoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Dashboard.Domain.Entities.Cliente", "Cliente")
                        .WithMany("PosicionamentosChamado")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Dashboard.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("PosicionamentosChamado")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Telefone", b =>
                {
                    b.HasOne("Dashboard.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Telefones")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Dashboard.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("Telefones")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dashboard.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Dashboard.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Usuarios")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Dashboard.Domain.Entities.Funcionario", "Funcionario")
                        .WithOne("Usuario")
                        .HasForeignKey("Dashboard.Domain.Entities.Usuario", "FuncionarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}