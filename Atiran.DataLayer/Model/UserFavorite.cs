//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atiran.DataLayer.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserFavorite
    {
        public int RowID { get; set; }
        public int UserID { get; set; }
        public int MenuID { get; set; }
    
        public virtual sys_users sys_users { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
