using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    public abstract class RepositorioBase
    {
        protected readonly String connectionString;
        protected readonly IConfiguration configuration;

        protected RepositorioBase(IConfiguration configuration)
        {
            this.connectionString = "Server = (localdb)\\MSSQLLocalDB;Database=LilloLSInmobiliaria;Trusted_Connection=True;MultipleActiveResultSets=true";
            this.configuration = configuration;
        }
    }
}
