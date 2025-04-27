using Microsoft.OpenApi.Models;

namespace Eparking.API.Configuration
{
    public class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                // Definindo informações da API
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Eparking - API para gerenciamento de estacionamentos rotativos",
                    Description = "API desenvolvida como ferramenta de estudo.",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael Lana, Daniel Cid",
                        Email = "rafaellanas@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });
            });
        }

        /// <summary>
        /// Método para executar e aplicar as configurações do Swagger
        /// </summary>
        public static void UseSwaggerConfiguration(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // Customizando o título e o tema do SwaggerUI
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Parking API v1");
                c.DocumentTitle = "EparkingApp - Sistema de Gerenciamento para Estacionamentos";
            });
        }
    }
}
