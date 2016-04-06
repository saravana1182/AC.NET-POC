using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AgileCourtPOC.Domain;
using System.Data.Entity.ModelConfiguration;

namespace AgileCourtPOC.Data.Configurations
{
    public class ValidationGroupCodeEntityConfiguration: EntityTypeConfiguration<ValidationGroupCode>
    {
        public ValidationGroupCodeEntityConfiguration()
        {
            ToTable("VALIDATION_MAS_CATEGORY_CODE");
            HasKey<int>(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Description).HasColumnName("Description").HasMaxLength(255);

          

           
        }


    }
}
