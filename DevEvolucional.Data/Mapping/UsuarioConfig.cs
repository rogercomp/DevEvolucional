using System;
using DevEvolucional.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEvolucional.Data.Mapping
{
	public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.ToTable("Usuario");
			builder.HasKey(t => t.IdUsuario);
			builder.Property(t => t.IdUsuario);
			builder.Property(t => t.Login);
			builder.Property(t => t.Hash);
			builder.Property(t => t.Salt);

		}
	}
}
