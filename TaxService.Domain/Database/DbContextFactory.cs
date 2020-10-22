using System;
using System.Collections.Generic;
using System.Text;

namespace TaxService.Domain.Database
{
    using System.Security.Cryptography.X509Certificates;
    using Core;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public interface IDbContextFactory
    {
        TaxDbContext Create();
    }

    [RegisterScoped]
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IServiceCollection _services;

        public DbContextFactory(IServiceCollection services)
        {
            _services = services;
        }

        public TaxDbContext Create()
        {
            var context = _services.BuildServiceProvider().GetService<TaxDbContext>();
            return context;
        }
    }
}
