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

    public partial class Factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura()
        {
            this.DetalleFactura = new HashSet<DetalleFactura>();
        }
    
        public int ID { get; set; }

        [Display(Name = "Fecha Actual"), Required(ErrorMessage = "Es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public string fecha { get; set; }

        [Display(Name = "Modo De Pago"), Required(ErrorMessage = "Es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras permitidas!")]
        public string modoPago { get; set; }

        [Display(Name = "Monto Total"), Required(ErrorMessage = "Es obligatorio")]
        public Nullable<decimal> montoTotal { get; set; }

        [Display(Name = "Usuario"), Required(ErrorMessage = "Es obligatorio")]
        public Nullable<int> idUsuario { get; set; }

        [Display(Name = "Empleado"), Required(ErrorMessage = "Es obligatorio")]
        public Nullable<int> idEmpleado { get; set; }

        [Display(Name = "Cafeteria"), Required(ErrorMessage = "Es obligatorio")]
        public int idCafeteria { get; set; }
    
        public virtual CAFETERIA CAFETERIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
