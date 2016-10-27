using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cronus.HotelMIS.Models
{
    public class CountryModel
    {
        public int CountryID { get; set; }
        [DisplayName("Country Code")]
        [Required(ErrorMessage = "An Country Code is required")]
        public string CountryCode { get; set; }
        [DisplayName("Country Name")]
        [Required(ErrorMessage = "An Country Name is required")]
        public string CountryName { get; set; }
        public Nullable<int> CountryAddedBy { get; set; }
        public Nullable<System.DateTime> CountryAddedDate { get; set; }
        public Nullable<int> CountryEditedBy { get; set; }
        public Nullable<System.DateTime> CountryEditedDate { get; set; }
        public Nullable<bool> CountryIsActive { get; set; }

       // public virtual ICollection<StateModel> States { get; set; }
    }
}