//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Otopark
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personel()
        {
            this.Customers = new HashSet<Customer>();
            this.Relationships = new HashSet<Relationship>();
        }
    
        public int PersonelID { get; set; }
        public string PersonelTC { get; set; }
        public string PersonelName { get; set; }
        public string PersonelSurname { get; set; }
        public string Password { get; set; }
        public string PersonelPhone { get; set; }
        public string PersonelEMail { get; set; }
        public string PersonelAddress { get; set; }
        public Nullable<int> PersonelBirthYear { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Relationship> Relationships { get; set; }
    }
}
