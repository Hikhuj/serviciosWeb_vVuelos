//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace vVuelos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class airline
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public airline()
        {
            this.flights = new HashSet<flight>();
        }
    
        public string consecutive_airline_id { get; set; }
        public string name { get; set; }
        public string consecutive_country_id_FK { get; set; }
        public string image { get; set; }
    
        public virtual country country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<flight> flights { get; set; }
    }
}
