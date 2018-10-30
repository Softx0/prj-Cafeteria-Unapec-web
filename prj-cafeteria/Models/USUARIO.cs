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

    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.Factura = new HashSet<Factura>();
            this.FACTURACION_ARTICULOS = new HashSet<FACTURACION_ARTICULOS>();
        }
    
        public int ID { get; set; }

        [Display(Name = "Cliente"), Required(ErrorMessage = "Es obligatorio")]
        public string NOMBRE { get; set; }

        [Display(Name = "Cedula"), Required(ErrorMessage = "Es obligatorio.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "La longitud de la Cedula es incorrecta.")]
        public string CEDULA { get; set; }
        public Nullable<int> IDTIPOUSUARIO { get; set; }

        [Display(Name = "Limite de Credito"), Required(ErrorMessage = "Es obligatorio.")]
        public Nullable<decimal> LIMITECREDITO { get; set; }

        [Display(Name = "Fecha de Registro"), Required(ErrorMessage = "Es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHAREGISTRO { get; set; }
        public Nullable<int> Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Factura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURACION_ARTICULOS> FACTURACION_ARTICULOS { get; set; }
        public virtual TIPOUSUARIO TIPOUSUARIO { get; set; }
        public virtual ESTADO ESTADO1 { get; set; }
    }
}
