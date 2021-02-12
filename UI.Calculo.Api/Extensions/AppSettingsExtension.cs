﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Calculo.Api.Extensions
{
    public static class AppSettingsExtension
    {
        public static void AddConfiguration<T>(this IServiceCollection services, IConfiguration configuration, string configurationTag = null)
        where T : class
        {
            if (string.IsNullOrEmpty(configurationTag))
                configurationTag = typeof(T).Name;

            var instance = Activator.CreateInstance<T>();
            new ConfigureFromConfigurationOptions<T>(configuration.GetSection(configurationTag)).Configure(instance);
            services.AddSingleton(instance);
        }
    }
}
