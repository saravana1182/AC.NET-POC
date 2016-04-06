using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AgileCourtPOC.Domain;
using AgileCourtPOC.Data.Configurations;

namespace AgileCourtPOC.Data
{
    public class AgileCourtDBContext : DbContext, IDbContext
    {


        public AgileCourtDBContext():base("name=AgileCourtDb")
        {
             Configuration.AutoDetectChangesEnabled = true;
            //Configuration.ValidateOnSaveEnabled = false;            
           // Database.SetInitializer<AgileCourtDBContext>(null);
        }


        public DbSet<ValidationCode> ValidationCode{get;set;}

        public DbSet<ValidationCategoryCode> ValidationCategoryCode { get; set; }

       public DbSet<ValidationGroupCode> ValidationMasterCategoryCode { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ValidationCategoryCodeEntityConfiguration());
            modelBuilder.Configurations.Add(new ValidationCodeEntityConfiguration());
            modelBuilder.Configurations.Add(new ValidationGroupCodeEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }

    public interface IDbContext
    {

    }
}
