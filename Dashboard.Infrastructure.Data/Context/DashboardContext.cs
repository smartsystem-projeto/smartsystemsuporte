using Dashboard.Domain.Entities;
using Dashboard.Infrastructure.Data.EntityTypeConfigs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Dashboard.Infrastructure.Data.Context
{
    public class DashboardContext : DbContext
    {
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ClienteProduto> ClienteProdutos { get; set; }
        public virtual DbSet<Chamado> Chamados { get; set; }
        public virtual DbSet<TipoChamado> TiposChamado { get; set; }
        public virtual DbSet<AssuntoChamado> AssuntosChamado { get; set; }
        public virtual DbSet<PosicionamentoChamado> PosicionamentosChamado { get; set; }

        public DashboardContext(DbContextOptions<DashboardContext> options)
            : base(options)
        { }

        public DashboardContext()
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TelefoneEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new EnderecoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ClienteEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new FuncionarioEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new UsuarioEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ProdutoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ChamadoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new TipoChamadoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new AssuntoChamadoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new PosicionamentoChamadoEntityTypeConfig());

            modelBuilder.Entity<Telefone>()
                .HasOne(telefone => telefone.Cliente)
                .WithMany(cliente => cliente.Telefones)
                .HasForeignKey(telefone => telefone.ClienteId);
            modelBuilder.Entity<Telefone>()
                .HasOne(telefone => telefone.Funcionario)
                .WithMany(funcionario => funcionario.Telefones)
                .HasForeignKey(telefone => telefone.FuncionarioId);

            modelBuilder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cliente)
                .WithOne(cliente => cliente.Endereco)
                .HasForeignKey<Cliente>(endereco => endereco.ClienteId);
            modelBuilder.Entity<Endereco>()
                .HasOne(endereco => endereco.Funcionario)
                .WithOne(funcionario => funcionario.Endereco)
                .HasForeignKey<Funcionario>(endereco => endereco.FuncionarioId);

            modelBuilder.Entity<ClienteProduto>()
            .HasKey(clienteProduto => new { clienteProduto.ClienteId, clienteProduto.ProdutoId });
            modelBuilder.Entity<ClienteProduto>()
                .HasOne(clienteProduto => clienteProduto.Cliente)
                .WithMany(cliente => cliente.ClienteProdutos)
                .HasForeignKey(clienteProduto => clienteProduto.ClienteId);
            modelBuilder.Entity<ClienteProduto>()
                .HasOne(clienteProduto => clienteProduto.Produto)
                .WithMany(produto => produto.ClienteProdutos)
                .HasForeignKey(clienteProduto => clienteProduto.ProdutoId);

            modelBuilder.Entity<Usuario>()
                .HasOne(usuario => usuario.Cliente)
                .WithMany(cliente => cliente.Usuarios)
                .HasForeignKey(usuario => usuario.ClienteId);


            modelBuilder.Entity<Chamado>()
                .HasOne(chamado => chamado.Cliente)
                .WithMany(cliente => cliente.Chamados)
                .HasForeignKey(chamado => chamado.ClienteId);
            modelBuilder.Entity<Chamado>()
                .HasOne(chamado => chamado.Funcionario)
                .WithMany(funcionario => funcionario.Chamados)
                .HasForeignKey(chamado => chamado.FuncionarioId);

            modelBuilder.Entity<Chamado>()
                .HasOne(chamado => chamado.Produto)
                .WithMany(produto => produto.Chamados)
                .HasForeignKey(chamado => chamado.ProdutoId);
            modelBuilder.Entity<Chamado>()
                .HasOne(chamado => chamado.TipoChamado)
                .WithMany(tipoChamado => tipoChamado.Chamados)
                .HasForeignKey(chamado => chamado.TipoChamadoId);
            modelBuilder.Entity<Chamado>()
                .HasOne(chamado => chamado.AssuntoChamado)
                .WithMany(assuntoChamado => assuntoChamado.Chamados)
                .HasForeignKey(chamado => chamado.AssuntoChamadoId);
            modelBuilder.Entity<Chamado>()
                .HasOne(chamado => chamado.Cliente)
                .WithMany(cliente => cliente.Chamados)
                .HasForeignKey(chamado => chamado.ClienteId);
            modelBuilder.Entity<Chamado>()
                .HasOne(chamado => chamado.Funcionario)
                .WithMany(funcionario => funcionario.Chamados)
                .HasForeignKey(chamado => chamado.FuncionarioId);

            modelBuilder.Entity<PosicionamentoChamado>()
                .HasOne(posicionamentoChamado => posicionamentoChamado.Chamado)
                .WithMany(chamado => chamado.PosicionamentosChamado)
                .HasForeignKey(posicionamentoChamado => posicionamentoChamado.ChamadoId);
            modelBuilder.Entity<PosicionamentoChamado>()
                .HasOne(posicionamentoChamado => posicionamentoChamado.Cliente)
                .WithMany(cliente => cliente.PosicionamentosChamado)
                .HasForeignKey(posicionamentoChamado => posicionamentoChamado.ClienteId);
            modelBuilder.Entity<PosicionamentoChamado>()
                .HasOne(posicionamentoChamado => posicionamentoChamado.Funcionario)
                .WithMany(funcionario => funcionario.PosicionamentosChamado)
                .HasForeignKey(posicionamentoChamado => posicionamentoChamado.FuncionarioId);

            modelBuilder.Entity<AssuntoChamado>()
                .HasOne(assuntoChamado => assuntoChamado.TipoChamado)
                .WithMany(tipoChamado => tipoChamado.AssuntosChamado)
                .HasForeignKey(assuntoChamado => assuntoChamado.TipoChamadoId);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Seed
            modelBuilder.Entity<Funcionario>().HasData(new Funcionario
            {
                FuncionarioId = 1,
                Status = true,
                NomeTratamento = "Admin",
                CPF = "12345678912",
                DataCadastro = DateTime.Now
            });
            modelBuilder.Entity<Endereco>().HasData(new Endereco {
                EnderecoId = 1,
                Rua = "Rua",
                Numero = 123,
                Cidade = "Cidade",
                Bairro = "Bairro",
                UF = "UF",
                FuncionarioId = 1
            });
            modelBuilder.Entity<Usuario>().HasData(new Usuario {
                UsuarioId = 1,
                Status = true,
                Login = "admin",
                Senha = "admin",
                Nome = "Administrador",
                Email = "admin@email.com",
                Nivel = "Coordenador",
                FuncionarioId = 1,
                DataCadastro = DateTime.Now
            });
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAbertura") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataAbertura").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAbertura").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAtualizacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataAtualizacao").CurrentValue = null;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Responsavel") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("Responsavel").CurrentValue = "Técnico";
            }

            return base.SaveChanges();
        }
    }
}
