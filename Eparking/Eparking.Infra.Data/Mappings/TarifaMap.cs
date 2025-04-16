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
    public class TarifaMap : IEntityTypeConfiguration<Tarifa>
    {
        public void Configure(EntityTypeBuilder<Tarifa> builder)
        {
            builder.ToTable("TB_TARIFA");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(t => t.EstacionamentoId)
                .HasColumnName("ESTACIONAMENTO_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(t => t.TipoVeiculo)
                .HasColumnName("TIPO_VEICULO")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(t => t.ValorHora)
                .HasColumnName("VALOR_HORA")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(t => t.ValorFracao)
                .HasColumnName("VALOR_FRACAO")
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.ToleranciaMinutos)
                .HasColumnName("TOLERANCIA_MINUTOS")
                .HasColumnType("datetime");

            #region Relacionamentos

            builder.HasOne(t => t.Estacionamento)
                .WithMany(e => e.Tarifas)
                .HasForeignKey(t => t.EstacionamentoId);

            #endregion
        }
    }
}
