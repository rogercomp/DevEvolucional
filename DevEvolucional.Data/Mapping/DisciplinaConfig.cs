using DevEvolucional.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEvolucional.Data.Mapping
{
	public class DisciplinaConfig : IEntityTypeConfiguration<Disciplina>
	{
		public void Configure(EntityTypeBuilder<Disciplina> builder)
		{
			builder.ToTable("Disciplina");
			builder.HasKey(t => t.IdDisciplina);
			builder.Property(t => t.IdDisciplina);
			builder.Property(t => t.Descricao);
		}
	}
}
