using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cronus.HotelMIS.Models
{
    public class StateModel
    {
        public int StateID { get; set; }
        [DisplayName("State Name")]
        [Required(ErrorMessage = "An State Name is required")]
        public string StateName { get; set; }
       
        public Nullable<int> StateCountryID { get; set; }
        public Nullable<int> StateAddedBy { get; set; }
        public Nullable<System.DateTime> StateAddedDate { get; set; }
        public Nullable<int> StateEditedBy { get; set; }
        public Nullable<System.DateTime> StateEditedDate { get; set; }
        public Nullable<bool> StateIsActive { get; set; }

        //public virtual ICollection<CityModel> Cities { get; set; }
        public virtual CountryModel Country { get; set; }
    }
}