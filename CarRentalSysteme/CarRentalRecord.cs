//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRentalSysteme
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarRentalRecord
    {
        public int id { get; set; }
        public string CostamerName { get; set; }
        public Nullable<System.DateTime> dateRented { get; set; }
        public Nullable<System.DateTime> dateRenturnd { get; set; }
        public Nullable<decimal> coste { get; set; }
        public Nullable<int> Typeofcars { get; set; }
    
        public virtual CarRentalRecord CarRentalRecord1 { get; set; }
        public virtual CarRentalRecord CarRentalRecord2 { get; set; }
        public virtual TypeOfCar TypeOfCar { get; set; }
    }
}