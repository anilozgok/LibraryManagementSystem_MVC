//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace libraryManagementSystem.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class fines
    {
        public int id { get; set; }
        public int member { get; set; }
        public int transaction_id { get; set; }
        public decimal total_fine { get; set; }
    
        public virtual members members { get; set; }
        public virtual transactions transactions { get; set; }
    }
}
