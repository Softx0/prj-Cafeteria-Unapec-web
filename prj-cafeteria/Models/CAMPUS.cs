//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prj_cafeteria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CAMPUS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAMPUS()
        {
            this.CAFETERIA = new HashSet<CAFETERIA>();
        }
    
        public int ID { get; set; }

        [Display(Name = "Campus"), Required(ErrorMessage = "Es obligatorio")]
        public string NOMBRE { get; set; }

        [Display(Name = "Descripcion"), Required(ErrorMessage = "Es obligatorio")]
        public string DESCRIPCION { get; set; }
        public Nullable<int> Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAFETERIA> CAFETERIA { get; set; }
        public virtual ESTADO ESTADO1 { get; set; }
    }
}
