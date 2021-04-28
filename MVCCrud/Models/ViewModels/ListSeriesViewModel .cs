using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSERIESTEST.Models.ViewModels
{
    public class ListSeriesViewModel
    {
        public int IDSeries { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string SeriesSplit { get; set; }
     
    }
}