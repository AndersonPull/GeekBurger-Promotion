using System;
using Repository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository.SQLServer
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext() {}
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) {}

        public DbSet<PromotionEntity> Promotion { get; set; }
    }
}