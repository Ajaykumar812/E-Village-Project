//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_VillageProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_registration
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Mothers_name { get; set; }
        public string Father_name { get; set; }
        public string Address { get; set; }
        public string Permanent_Address { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string DOB { get; set; }
        public string Profile { get; internal set; }
        public string Regdate { get; internal set; }
        public object Contactno { get; internal set; }
        public object ConfirmPassword { get; internal set; }
        public object Password { get; internal set; }
        public string EmailID { get; internal set; }
    }
}
