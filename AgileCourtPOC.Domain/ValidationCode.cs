using AgileCourtPOC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileCourtPOC.Domain
{
    public class ValidationCode:Entity<int>
    {
       public string Code { get; set; }

        public string Description { get; set; } 

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ReportAs { get; set; }

        public int ValidationCategoryCodeRefID { get; set; }

        public virtual ValidationCategoryCode ValidationCategoryCode { get; set; }

    }
}
