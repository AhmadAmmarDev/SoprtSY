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
    
    public partial class Rquest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rquest()
        {
            this.RequestStatuses = new HashSet<RequestStatuses>();
        }
    
        public System.Guid ID { get; set; }
        public System.Guid FromPersonID { get; set; }
        public System.Guid ToPersonID { get; set; }
        public Nullable<int> RequestTypeID { get; set; }
    
        public virtual RequestsTypes RequestsTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestStatuses> RequestStatuses { get; set; }
    }
}