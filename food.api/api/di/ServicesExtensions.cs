using domain.interfaces.repository.inmemory;
using domain.interfaces.services;
using domain.services;
using infrastruture.inmemory.repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;

namespace api.di
{
    public static class ServicesExtensions
    {
        public static void AddProjectDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            #region [ InMemory Dependency]

            services.AddSingleton<ILancheServices, LancheServices>();
            services.AddSingleton<ILancheRepository, LancheRepository>();
            services.AddSingleton<IIngredienteServices, IngredienteServices>();
            services.AddSingleton<IIngredienteRepository, IngredienteRepository>();

            #endregion
        }
    }
}
