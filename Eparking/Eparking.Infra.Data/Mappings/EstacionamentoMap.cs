using Eparking.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eparking.Infra.Data.Mappings
{
    public class EstacionamentoMap : IEntityTypeConfiguration<Estacionamento>
    {
        public void Configure(EntityTypeBuilder<Estacionamento> builder)
        {
            builder.ToTable("TB_ESTACIONAMENTO");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Endereco)
                .HasColumnName("ENDERECO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.QuantidadeVagasCarro)
                .HasColumnName("QTD_VAGAS_CARRO")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.QuantidadeVagasMotocicleta)
                .HasColumnName("QTD_VAGAS_MOTOCICLETA")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.QuantidadeVagasPreferencial)
                .HasColumnName("QTD_VAGAS_PREFERENCIAL")
                .HasColumnType("int")
                .IsRequired();

            #region Relacionamentos

            builder.HasMany(e => e.Vagas)
                .WithOne(v => v.Estacionamento)
                .HasForeignKey(v => v.EstacionamentoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(e => e.Vagas).AutoInclude();

            builder.HasMany(e => e.Tarifas)
                .WithOne(t => t.Estacionamento)
                .HasForeignKey(t => t.EstacionamentoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(e => e.Tarifas).AutoInclude();

            builder.HasMany(e => e.Movimentacoes)
                .WithOne(m => m.Estacionamento)
                .HasForeignKey(m => m.EstacionamentoId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

        }
    }
}
