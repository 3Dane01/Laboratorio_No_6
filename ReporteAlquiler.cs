using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_No_6
{
    internal class ReporteAlquiler
    {
        public string NombreCliente { get; set; }
        public string PlacaVehiculo { get; set; }
        public string MarcaVehiculo { get; set; }
        public string ModeloVehiculo { get; set; }
        public string ColorVehiculo { get; set; }
        public string FechaDevolucion { get; set; }
        public decimal TotalAPagar { get; set; }
    }
}
