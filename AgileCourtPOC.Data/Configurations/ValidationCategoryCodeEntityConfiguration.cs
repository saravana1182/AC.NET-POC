using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using AgileCourtPOC.Domain;

namespace AgileCourtPOC.Data.Configurations
{
    public class ValidationCategoryCodeEntityConfiguration: EntityTypeConfiguration<ValidationCategoryCode>
    {

        public ValidationCategoryCodeEntityConfiguration()
        {
            ToTable("VALIDATION_CATEGORY_CODE");
            HasKey<int>(x => x.Id);
            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Code).HasColumnName("Code").HasMaxLength(100);
            Property(x => x.Description).HasColumnName("Description").HasMaxLength(255);
            Property(x => x.ValidationMasterCategoryCodeRefId).HasColumnName("ValidationMasterCategoryCodeRefId");
            HasRequired<ValidationGroupCode>(x => x.ValidationMasterCode).WithMany(x => x.ValidationCategoryCodes)
                .HasForeignKey(x => x.ValidationMasterCategoryCodeRefId);            

        }
    }
}
