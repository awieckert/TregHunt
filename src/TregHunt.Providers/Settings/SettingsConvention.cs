using BaselineTypeDiscovery;
using Lamar;
using Lamar.Scanning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TregHunt.Services.Settings
{
    public class SettingsConvention : IRegistrationConvention
    {
        readonly IConfiguration _configuration;

        public SettingsConvention(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ScanTypes(TypeSet types, ServiceRegistry services)
        {
            var settingTypes = types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed)
                .Where(t =>
                {
                    var hasDefaultConstructor = t.GetConstructor(Type.EmptyTypes) != null;
                    var isSettingsClass = t.Name.EndsWith("settings", StringComparison.OrdinalIgnoreCase);

                    return isSettingsClass && hasDefaultConstructor;
                });

            foreach (var type in settingTypes)
            {
                var config = Activator.CreateInstance(type);
                _configuration.Bind(type.Name, config);
                services.AddSingleton(type, x => config);
            }
        }
    }
}
