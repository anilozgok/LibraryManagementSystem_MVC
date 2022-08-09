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
    using System.ComponentModel.DataAnnotations;
    
    public partial class employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employees()
        {
            this.transactions = new HashSet<transactions>();
        }
    
        public int employee_id { get; set; }


        [Required(ErrorMessage = "Please enter name.")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 character.")]
        public string employee_name { get; set; }


        [Required(ErrorMessage = "Please enter surname.")]
        [MaxLength(50, ErrorMessage = "Surname cannot be longer than 50 character.")]
        public string employee_surname { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transactions> transactions { get; set; }
    }
}
