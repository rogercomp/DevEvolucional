using System;
using DevEvolucional.Data.Mapping;
using DevEvolucional.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevEvolucional.Data
{
	public class ApplicationContext : DbContext
    {
        private readonly ILogger<ApplicationContext> _logger;


        public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Aluno> Alunos { get; set; }
		public DbSet<Disciplina> Disciplinas { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options, ILogger<ApplicationContext> logger)
			: base(options)
		{
            _logger = logger;
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            _logger.Log(LogLevel.Information, "OnModelCreating...");
			modelBuilder.ApplyConfiguration(new UsuarioConfig());
			modelBuilder.ApplyConfiguration(new AlunoConfig());
			modelBuilder.ApplyConfiguration(new DisciplinaConfig());
		}
	}
}
