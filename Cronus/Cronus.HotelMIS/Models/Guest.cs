//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cronus.HotelMIS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Guest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Guest()
        {
            this.Folios = new HashSet<Folio>();
        }
    
        public int GuestID { get; set; }
        public string GuestTitle { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestMiddleName { get; set; }
        public string GuestLastName { get; set; }
        public string GuestGender { get; set; }
        public string GuestEmailAddress { get; set; }
        public string GuestHandPhone { get; set; }
        public string GuestTelPhone { get; set; }
        public string GuestFaxNumber { get; set; }
        public Nullable<int> GuestIDType { get; set; }
        public string GuestIDTypeNumber { get; set; }
        public string GuestAddress { get; set; }
        public Nullable<int> GuestCountryID { get; set; }
        public Nullable<int> GuestAddedBy { get; set; }
        public Nullable<System.DateTime> GuestAddedDate { get; set; }
        public Nullable<int> GuestEditedBy { get; set; }
        public Nullable<System.DateTime> GuestEditedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Folio> Folios { get; set; }
    }
}
