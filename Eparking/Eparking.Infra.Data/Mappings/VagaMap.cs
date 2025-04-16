using Eparking.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eparking.Infra.Data.Mappings
{
    public class VagaMap : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.ToTable("TB_VAGA");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(v => v.Numero)
                .HasColumnName("NUMERO")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(v => v.TipoVaga)
                .HasColumnName("TIPO_VAGA")
                .HasConversion<int>()
                .IsRequired();

            builder.Property(v => v.Ocupado)
                .HasColumnName("OCUPADO")
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(v => v.EstacionamentoId)
                .HasColumnName("ESTACIONAMENTO_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Navigation(v => v.Movimentacoes).AutoInclude();

            builder.HasOne(v => v.Estacionamento)
                .WithMany(e => e.Vagas)
                .HasForeignKey(v => v.EstacionamentoId);
        }
    }
}
