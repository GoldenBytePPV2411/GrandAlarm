//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pills_reminder
{
    using System;
    using System.Collections.Generic;
    
    public partial class WeekIntake
    {
        public int Id { get; set; }
        public int Id_person { get; set; }
        public int Id_drug { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public string Amount { get; set; }
        public Nullable<bool> Intaken { get; set; }
    
        public virtual Drug Drug { get; set; }
        public virtual User User { get; set; }
    }
}