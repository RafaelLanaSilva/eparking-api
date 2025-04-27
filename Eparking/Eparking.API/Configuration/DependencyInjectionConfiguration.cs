using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Mappings;
using Eparking.Domain.Services;
using Eparking.Infra.Data.Repositories;

namespace Eparking.API.Configuration
{
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services)
        {
            //AutoMapper
            services.AddAutoMapper(typeof(ProfileMap));

            services.AddTransient<IEstacionamentoService, EstacionamentoDomainService>();
            services.AddTransient<IVagaService, VagaDomainService>();
            services.AddTransient<ITarifaService, TarifaDomainService>();
            services.AddTransient<IMovimentacaoService, MovimentacaoDomainService>();
            services.AddTransient<IVeiculoService, VeiculoDomainService>();

            services.AddTransient<IEstacionamentoRepository, EstacionamentoRepository>();
            services.AddTransient<IVagaRepository, VagaRepository>();          
            services.AddTransient<ITarifaRepository, TarifaRepository>();
            services.AddTransient<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddTransient<IVeiculoRepository, VeiculoRepository>();

        }
    }
}
