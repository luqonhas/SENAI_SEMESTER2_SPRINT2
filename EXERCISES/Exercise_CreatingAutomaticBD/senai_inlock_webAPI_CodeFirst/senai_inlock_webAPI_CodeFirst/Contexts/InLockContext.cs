using Microsoft.EntityFrameworkCore;
using senai_inlock_webAPI_CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_CodeFirst.Contexts
{
    /// <summary>
    /// classe responsável pelo contexto do projeto
    /// faz a comunicação entre a API e o Banco de Dados
    /// </summary>
    public class InLockContext : DbContext
    {
        // define as entidades do banco de dados
        // o DbSet recebe dentro dele um Domain
        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Estudio> Estudio { get; set; }

        public DbSet<Jogo> Jogo { get; set; }

        /// <summary>
        /// define as opções de contrução do banco de dados
        /// </summary>
        /// <param name="optionsBuilder"> objeto com as configurações definidas </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Server ou Data Source terão a mesma finalidade
            // Database ou initial catalog terão a mesma finalidade
            optionsBuilder.UseSqlServer("Server=DESKTOP-HMTUR0P; Database=inlock_games_codefirst; user Id=SA; pwd=Soufoda2;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // define as entidade já com dados
            modelBuilder.Entity<TipoUsuario>().HasData(
                new TipoUsuario 
                { 
                    idTipoUsuario = 1,
                    permissao = "Administrador"
                },
                new TipoUsuario
                {
                    idTipoUsuario = 2,
                    permissao = "Cliente"
                }
                );

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasData(
                new Usuario
                {
                    idUsuario = 1,
                    email = "admin@admin.com",
                    senha = "admin",
                    idTipoUsuario = 1
                },
                new Usuario
                {
                    idUsuario = 2,
                    email = "cliente@cliente.com",
                    senha = "cliente",
                    idTipoUsuario = 2
                });

                // cria um índice que define que o campo email é único
                entity.HasIndex(u => u.email).IsUnique();
            });

            modelBuilder.Entity<Estudio>().HasData(
                new Estudio { idEstudio = 1, nomeEstudio = "Blizzard" },
                new Estudio { idEstudio = 2, nomeEstudio = "Rockstar Studios" },
                new Estudio { idEstudio = 3, nomeEstudio = "Square Enix" }
                );

            modelBuilder.Entity<Jogo>().HasData(
                new Jogo
                {
                    idJogo = 1,
                    nomeJogo = "Diablo 3",
                    dataLancamento = Convert.ToDateTime("15/05/2012"),
                    descricao = "É um jogo que contém bastante ação...",
                    valor = Convert.ToDecimal("99,00"),
                    idEstudio = 1
                },
                new Jogo
                {
                    idJogo = 2,
                    nomeJogo = "Red Dead Redemption II",
                    dataLancamento = Convert.ToDateTime("26/10/2018"),
                    descricao = "Jogo eletrônico de ação-aventura western.",
                    valor = Convert.ToDecimal("99,00"),
                    idEstudio = 1
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
