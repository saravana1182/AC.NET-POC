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
    public class BaseValidationCodeEntityConfiguration : EntityTypeConfiguration<BaseValidationCode>
    {

        public BaseValidationCodeEntityConfiguration()
        {
            this.ToTable("Base_Validation_Code");

            this.HasKey<int>(x => x.Id);

            this.Property(x => x.Code).HasColumnName("Validation_Code");

            this.Property(x => x.Type).HasColumnName("Validation_Code_Type");

            this.Property(x => x.AuditUserId).HasColumnName("Audit_User_Id");

            this.Property(x => x.AuditDate).HasColumnName("Validation_Code_Group");





        }
    }
}
