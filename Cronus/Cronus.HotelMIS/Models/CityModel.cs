using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cronus.HotelMIS.Models
{
    public class CityModel
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public Nullable<int> CityStateID { get; set; }
        public Nullable<int> CityAddedBy { get; set; }
        public Nullable<System.DateTime> CityAddedDate { get; set; }
        public Nullable<int> CityEditedBy { get; set; }
        public Nullable<System.DateTime> CityEditedDate { get; set; }
        public Nullable<bool> CityIsActive { get; set; }

        public virtual StateModel State { get; set; }
    }
}