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

    public partial class EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            this.CAFETERIAEMPLEADO = new HashSet<CAFETERIAEMPLEADO>();
            this.FACTURACION_ARTICULOS = new HashSet<FACTURACION_ARTICULOS>();
            this.Factura = new HashSet<Factura>();
        }
    
        public int ID { get; set; }

        [Display(Name = "Tanda Labor"), Required(ErrorMessage = "Es obligatorio")]
        public Nullable<int> IDTANDALABOR { get; set; }

        [Display(Name = "Empleado"), Required(ErrorMessage = "Es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras permitidas!")]
        public string NOMBRE { get; set; }

        [Display(Name = "Cedula"), Required(ErrorMessage = "Es obligatorio.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Debe ser un numero!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "La longitud de la Cedula es incorrecta.")]
        public string CEDULA { get; set; }

        [Display(Name = "Comision"), Required(ErrorMessage = "Es obligatorio.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Debe ser un numero!")]
        public decimal COMISION { get; set; }

        [Display(Name = "Fecha de Registro"), Required(ErrorMessage = "Es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FECHAREGISTRO { get; set; }
        public Nullable<int> Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAFETERIAEMPLEADO> CAFETERIAEMPLEADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURACION_ARTICULOS> FACTURACION_ARTICULOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual TANDALABOR TANDALABOR { get; set; }
        public virtual ESTADO ESTADO1 { get; set; }
    }
}
