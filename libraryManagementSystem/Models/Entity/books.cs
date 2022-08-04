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
    
    public partial class books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public books()
        {
            this.transactions = new HashSet<transactions>();
        }
    
        public int book_id { get; set; }
        public string book_name { get; set; }
        public int category { get; set; }
        public int author { get; set; }
        public int publisher { get; set; }
        public string publishing_year { get; set; }
        public Nullable<int> page_number { get; set; }
        public Nullable<bool> status { get; set; }
        public string image_link { get; set; }
    
        public virtual author author1 { get; set; }
        public virtual category category1 { get; set; }
        public virtual publishers publishers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transactions> transactions { get; set; }
    }
}
