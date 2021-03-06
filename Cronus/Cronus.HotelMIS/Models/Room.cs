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
    
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            this.FolioDetails = new HashSet<FolioDetail>();
        }
    
        public int RoomID { get; set; }
        public Nullable<int> RoomHotelID { get; set; }
        public string RoomCode { get; set; }
        public Nullable<int> RoomFloor { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomStatusId { get; set; }
        public Nullable<int> RoomAddedBy { get; set; }
        public Nullable<System.DateTime> RoomAddedDate { get; set; }
        public Nullable<int> RoomEditedBy { get; set; }
        public Nullable<System.DateTime> RoomEditedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FolioDetail> FolioDetails { get; set; }
        public virtual RoomStatu RoomStatu { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
