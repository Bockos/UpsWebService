//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPSWebService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class B_UPSOnDemantPickup_Order
    {
        public int id { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEMail { get; set; }
        public string CustomerState { get; set; }
        public string CustomerCounty { get; set; }
        public string CustomerAddress { get; set; }
        public string SerialNumber { get; set; }
        public string DefectDesc { get; set; }
        public string ContactType { get; set; }
        public string UPSTrackingNum { get; set; }
        public string ServiceOrderId { get; set; }
        public Nullable<int> ServiceLocation { get; set; }
        public string ServiceCustAccount { get; set; }
        public string AxRecId { get; set; }
        public string PartyId { get; set; }
        public string CargoType { get; set; }
        public string TEMTrackingNum { get; set; }
    }
}
