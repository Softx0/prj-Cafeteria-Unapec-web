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

    public partial class CAFETERIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAFETERIA()
        {
            this.CAFETERIARTICULO = new HashSet<CAFETERIARTICULO>();
            this.CAFETERIAEMPLEADO = new HashSet<CAFETERIAEMPLEADO>();
            this.Factura = new HashSet<Factura>();
        }
    
        public int ID { get; set; }

        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Solo letras permitidas!")]
        [Display(Name = "Nombre"), Required(ErrorMessage = "El nombre del ítem es obligatorio")]
        public string NOMBRE { get; set; }

        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Solo letras permitidas!")]
        [Display(Name = "Descripcion"), Required(ErrorMessage = "El nombre del ítem es obligatorio")]
        public string DESCRIPCION { get; set; }

        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Solo letras permitidas!")]
        [Display(Name = "Encargado"), Required(ErrorMessage = "El nombre del ítem es obligatorio")]
        public string ENCARGADO { get; set; }

        [Display(Name = "Campus"), Required(ErrorMessage = "El nombre del ítem es obligatorio")]
        public Nullable<int> IDCAMPUS { get; set; }

        [Display(Name = "Estado"), Required(ErrorMessage = "El nombre del ítem es obligatorio")]
        public Nullable<int> Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAFETERIARTICULO> CAFETERIARTICULO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAFETERIAEMPLEADO> CAFETERIAEMPLEADO { get; set; }
        public virtual CAMPUS CAMPUS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ESTADO ESTADO1 { get; set; }
    }
}
