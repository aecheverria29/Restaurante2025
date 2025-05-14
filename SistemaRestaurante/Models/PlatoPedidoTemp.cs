using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Models
{
    internal class PlatoPedidoTemp
    {
        public int IdPlato { get; set; }
        public string NombrePlato { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => PrecioUnitario * Cantidad;
        public string Comentario { get; set; }

        List<PlatoPedidoTemp> listaDetalle = new List<PlatoPedidoTemp>();

    }

}
