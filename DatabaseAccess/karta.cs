//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class karta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public karta()
        {
            this.putniks = new HashSet<putnik>();
            this.prodavacs = new HashSet<prodavac>();
        }
    
        public string idkarte { get; set; }
        public string jednosmerna { get; set; }
        public string povratna { get; set; }
        public string mesecna { get; set; }
        public string tip_karte_idtipa { get; set; }
        public string vozna_linija_idlinije { get; set; }
    
        public virtual tip_karte tip_karte { get; set; }
        public virtual vozna_linija vozna_linija { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<putnik> putniks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prodavac> prodavacs { get; set; }
    }
}
