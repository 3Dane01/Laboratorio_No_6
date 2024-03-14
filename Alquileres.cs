using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_No_6
{
    internal class Alquileres
    {
        //Nit, placa, fecha alquiler, fecha devolución, kilómetros recorridos.
        string nitAlquiler;
        string placaAlquiler;
        string fechaAlquiler;
        string fechaDevolucion;
        decimal kilometrosRecorridos;
        

        public string NitAlquiler { get => nitAlquiler; set => nitAlquiler = value; }
        public string PlacaAlquiler { get => placaAlquiler; set => placaAlquiler = value; }
        public string FechaAlquiler { get => fechaAlquiler; set => fechaAlquiler = value; }
        public string FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public decimal KilometrosRecorridos { get => kilometrosRecorridos; set => kilometrosRecorridos = value; }
    }
}
