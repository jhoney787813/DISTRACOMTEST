using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSERIESTEST.Models.ViewModels
{
    public class SeriesAddViewModel
    {

        [StringLength(20)]
        [Display(Name = "Nombre Usuario")]
        public string UserName { get; set; }
        public int InvtervalInitial { get; set; }
        public int InvtervalEnd { get; set; }


    }
}