using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileCourtPOC.WebAPI.Models
{
    public class ValidationCodeViewModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ReportAs { get; set; }

        public int ValidationCategoryCodeRefID { get; set; }

        
    }
}