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
    public class ValidationCodeEntityConfiguration:EntityTypeConfiguration<ValidationCode>
    {

        public ValidationCodeEntityConfiguration()
        {
            ToTable("VALIDATION_CODE");
            HasKey<int>(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Code).HasColumnName("Code");
            Property(x => x.Description).HasColumnName("Description");
            Property(x => x.BeginDate).HasColumnName("BeginDate");
            Property(x => x.EndDate).HasColumnName("EndDate");
            Property(x => x.ReportAs).HasColumnName("ReportAs");
            Property(x => x.ValidationCategoryCodeRefID).HasColumnName("ValidationCategoryCodeRefID");
            HasRequired<ValidationCategoryCode>(x => x.ValidationCategoryCode).WithMany(x => x.ValidationCodes)
                .HasForeignKey(x => x.ValidationCategoryCodeRefID);
            
        }
    }
}
