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
    
    public partial class FILM_CATEGORY
    {
        public decimal FILM_ID { get; set; }
        public decimal CATEGORY_ID { get; set; }
        public System.DateTime LAST_UPDATE { get; set; }
    
        public virtual CATEGORY CATEGORY { get; set; }
        public virtual FILM FILM { get; set; }
    }
}