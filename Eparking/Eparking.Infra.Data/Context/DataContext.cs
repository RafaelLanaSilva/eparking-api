using Eparking.Infra.Data.Mappings;
using Eparking.Infra.Data.Settings;
using Microsoft.EntityFrameworkCore;

namespace Eparking.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlServerSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstacionamentoMap());
            modelBuilder.ApplyConfiguration(new MovimentacaoMap());
            modelBuilder.ApplyConfiguration(new TarifaMap());
            modelBuilder.ApplyConfiguration(new VagaMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
        }
    }
}
