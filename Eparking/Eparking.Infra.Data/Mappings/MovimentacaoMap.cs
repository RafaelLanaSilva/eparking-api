using Eparking.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eparking.Infra.Data.Mappings
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.ToTable("TB_MOVIMENTACAO");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(m => m.EstacionamentoId)
                .HasColumnName("ESTACIONAMENTO_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(m => m.VagaId)
                .HasColumnName("VAGA_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(m => m.HoraEntrada)
                .HasColumnName("HORA_ENTRADA")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(m => m.HoraSaida)
                .HasColumnName("HORA_SAIDA")
                .HasColumnType("datetime");

            builder.Property(m => m.ValorCobrado)
                .HasColumnName("VALOR_COBRADO")
                .HasColumnType("decimal(10,2)");

            #region Relacionamentos

            builder.HasOne(m => m.Estacionamento)
                .WithMany(e => e.Movimentacoes)
                .HasForeignKey(m => m.EstacionamentoId);

            builder.HasOne(m => m.Vaga)
                .WithMany(v => v.Movimentacoes)
                .HasForeignKey(m => m.VagaId);

            builder.HasOne(m => m.Veiculo)
                .WithMany(v => v.Movimentacoes)
                .HasForeignKey(m => m.VeiculoId);

            #endregion
        }
    }
}
