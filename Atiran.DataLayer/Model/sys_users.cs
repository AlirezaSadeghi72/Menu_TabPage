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
    
    public partial class sys_users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_users()
        {
            this.UserFavorites = new HashSet<UserFavorite>();
        }
    
        public int user_id { get; set; }
        public byte[] user_password { get; set; }
        public string user_name { get; set; }
        public string user_lname { get; set; }
        public string user_fname { get; set; }
        public Nullable<int> role_id { get; set; }
        public Nullable<int> skin_id { get; set; }
        public byte[] user_pic { get; set; }
        public Nullable<bool> IsLocked { get; set; }
        public Nullable<bool> IsLoggedIn { get; set; }
        public string TafsilCow { get; set; }
        public Nullable<long> TafsilID { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string nationalCode { get; set; }
        public string address { get; set; }
        public Nullable<bool> active { get; set; }
        public int shmo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
    }
}
