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
    
    public partial class act_zirsarfasls
    {
        public int rdf { get; set; }
        public string date { get; set; }
        public int rdf_zirsarfasls { get; set; }
        public string dis { get; set; }
        public decimal bed { get; set; }
        public decimal bes { get; set; }
        public string user { get; set; }
        public string bed_bes { get; set; }
        public decimal manafter { get; set; }
        public Nullable<int> kind { get; set; }
        public Nullable<int> sanadno { get; set; }
    
        public virtual zirsarfasl zirsarfasl { get; set; }
    }
}
