//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WoodShop.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class StoreAddress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StoreAddress()
        {
            this.Store = new HashSet<Store>();
        }
    
        public int ADDRESS_ID { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string building { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store> Store { get; set; }
    }
}
