//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class COUNTRY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COUNTRY()
        {
            this.CITY = new HashSet<CITY>();
        }
    
        public decimal COUNTRY_ID { get; set; }
        public string COUNTRY1 { get; set; }
        public Nullable<System.DateTime> LAST_UPDATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITY> CITY { get; set; }
    }
}
