//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCSERIESTEST.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Series
    {
        public int IDSeries { get; set; }
        public int IDUser { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string SeriesSplit { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
