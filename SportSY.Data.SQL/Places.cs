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
    
    public partial class Places
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Places()
        {
            this.Activities = new HashSet<Activities>();
        }
    
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> CityID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    
        public virtual Cities Cities { get; set; }
        public virtual PlacesTypes PlacesTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activities> Activities { get; set; }
    }
}
