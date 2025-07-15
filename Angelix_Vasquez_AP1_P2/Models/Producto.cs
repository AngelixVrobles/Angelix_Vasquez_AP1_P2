using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angelix_Vasquez_AP1_P2.Models
{
    public class Producto
    {
        [Key]
        public int ProductosId { get; set; }

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        public double Peso { get; set; }

        public virtual ICollection<EntradasDetalle> EntradasDetalle { get; set; } = new List<EntradasDetalle>();
    }
}
