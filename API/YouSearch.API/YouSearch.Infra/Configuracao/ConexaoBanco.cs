using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace YouSearch.Infra.Configuracao
{
    public class ConexaoBanco
    {
        public static IConfiguration ConnectionConfiguration
        {
            get
            {
                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    //.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                return Configuration;
            }
        }
    }
}
