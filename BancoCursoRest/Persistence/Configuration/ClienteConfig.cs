using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(p => p.Id);

            builder.Property(x => x.Nombre)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.Apellido)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.FechaNacimiento)
                .IsRequired();

            builder.Property(x => x.Telefono)
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100);

            builder.Property(x => x.Direccion)
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(x => x.Edad);

            builder.Property(x => x.CreatedBy)
                .HasMaxLength(30);

            builder.Property(x => x.LastModifyBy)
                .HasMaxLength(30);
        }
    }
}