using Eparking.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eparking.Infra.Data.Mappings
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TB_VEICULO");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(v => v.Modelo)
                .HasColumnName("MODELO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(v => v.Placa)
                .HasColumnName("PLACA")
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(v => v.Cor)
                .HasColumnName("COR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Navigation(v => v.Movimentacoes).AutoInclude();

            builder.HasMany(v => v.Movimentacoes)
                .WithOne(m => m.Veiculo)
                .HasForeignKey(m => m.VeiculoId);
        }
    }
}
