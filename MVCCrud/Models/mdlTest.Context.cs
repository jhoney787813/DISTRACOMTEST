﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_TESTASPNETEntities : DbContext
    {
        public DB_TESTASPNETEntities()
            : base("name=DB_TESTASPNETEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    
        public virtual ObjectResult<sp_GetAllSeriesUser_Result> sp_GetAllSeriesUser()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetAllSeriesUser_Result>("sp_GetAllSeriesUser");
        }
    
        public virtual ObjectResult<sp_GetSeriesUser_Result> sp_GetSeriesUser(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetSeriesUser_Result>("sp_GetSeriesUser", userNameParameter);
        }
    }
}
