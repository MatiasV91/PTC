using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class Productos
    {

        public int ProductosId { get; set; }
        [Required(ErrorMessage ="Debe ingresar el Nombre del producto.")]
        [Display(Name ="Nombre del Producto")]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "El Nombre del Producto debe tener mas de {2} caracteres y menos de {1}.")]
        public string NombreProducto { get; set; }
        [Display(Name = "Fecha de Introduccion" )]
        [Range(typeof(DateTime), "1/1/2000", "31/12/2025", ErrorMessage ="La fecha de introduccion debe ser entre {1} y {2}")]
        public DateTime FechaIntroduccion { get; set; }
        [Display(Name = "URL")]
        [Required(ErrorMessage = "Debe ingresar el URL.")]
        [StringLength(2000, MinimumLength = 8, ErrorMessage = "El URL debe tener mas de {2} caracteres y menos de {1}.")]
        public string Url { get; set; }
        [Range(1,9999, ErrorMessage ="{0} debe ser entre {1} y {2}")]
        public decimal Precio { get; set; }
    }
}
