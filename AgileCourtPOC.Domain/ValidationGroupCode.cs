using AgileCourtPOC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileCourtPOC.Domain
{
    public class ValidationGroupCode:Entity<int>
    {
        public string Code { get; set; }

        public string Description { get; set; }

     
        public ICollection<ValidationCategoryCode> ValidationCategoryCodes { get; set; }

    }
}
