//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportSY.Data.SQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TeamMembers
    {
        public System.Guid TeamID { get; set; }
        public System.Guid PersonID { get; set; }
    
        public virtual Teams Teams { get; set; }
    }
}