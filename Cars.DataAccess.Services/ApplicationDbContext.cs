using Cars.DataAccess.Contracts;
using Cars.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DataAccess.Services
{
    public class ApplicationDbContext :DbContext, IApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users{ get; set; }

        #region Arquitectura generica   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class
        {
            return Entry(entity);
        }

        public DatabaseFacade TheDatabase
        {
            get
            {
                return Database;
            }
        }

        public DbSet<T> GetEntitySet<T>() where T : class
        {
            return Set<T>();
        }

        public override int SaveChanges()
        {
            var modifiedEntites = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            modifiedEntites.ToList().ForEach(x =>
            {
                var entity = x.Entity as BaseEntity;
                entity?.SetAudit(x.State);
            });

            return base.SaveChanges();
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Car>().ToTable("Cars");
            builder.Entity<User>().ToTable("Users");

            


            // builder.Entity<Car>().Property(x => x.id).IsRequired().ValueGeneratedOnAdd();

            base.OnModelCreating(builder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {


                string mySqlConnectionStr = _configuration.GetConnectionString("DefaultConnection");
                MySqlDbContextOptionsBuilder mySqlDbContextOptionsBuilder = new MySqlDbContextOptionsBuilder(optionsBuilder);
                optionsBuilder.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)).EnableSensitiveDataLogging().UseLazyLoadingProxies();

            }

        }
    }
}
