using DevEvolucional.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEvolucional.Data.Mapping
{
	public class AlunoConfig : IEntityTypeConfiguration<Aluno>
	{
		public void Configure(EntityTypeBuilder<Aluno> builder)
		{
			builder.ToTable("Aluno");
			builder.HasKey(t => t.IdAluno);
			builder.Property(t => t.IdAluno);
			builder.Property(t => t.Nome);
		}
	}
}
