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
    
    public partial class FolioDetail
    {
        public int FolioDetailID { get; set; }
        public int FolioID { get; set; }
        public Nullable<int> FolioDetailRoomID { get; set; }
        public Nullable<int> FolioDetailRoomRateID { get; set; }
        public Nullable<int> FolioDetailAddedBy { get; set; }
        public Nullable<System.DateTime> FolioDetailAddedDate { get; set; }
        public Nullable<int> FolioDetailEditedBy { get; set; }
        public Nullable<System.DateTime> FolioDetailEditedDate { get; set; }
    
        public virtual Folio Folio { get; set; }
        public virtual RoomRate RoomRate { get; set; }
        public virtual Room Room { get; set; }
    }
}
