using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AgileCourtPOC.WebAPI.Models
{
    public class ValidationCodesViewModels
    {

        public int Id { get; set; }
        public int CategoryID { get; set; }

        public string CategoryDescription { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }

    public class ValidationCategoryCodeViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }


}