using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Domain.Entity;
namespace AgileCourtPOC.Domain
{
    public class ValidationCategoryCode:Entity<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }

       
        public int ValidationMasterCategoryCodeRefId { get; set; }

        public virtual ICollection<ValidationCode> ValidationCodes { get; set; }

        public virtual ValidationGroupCode ValidationMasterCode { get; set; }
       
    }
}
