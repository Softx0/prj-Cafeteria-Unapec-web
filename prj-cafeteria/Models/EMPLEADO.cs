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
        public Nullable<int> IDTANDALABOR { get; set; }
        public string NOMBRE { get; set; }
        public string CEDULA { get; set; }
        public decimal COMISION { get; set; }
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
