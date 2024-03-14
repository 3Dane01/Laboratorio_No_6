using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_No_6
{
    internal class Vehículos
    {
        //vehículos: Placa, marca, modelo, color, precio por kilómetro. (se ingresan desde formulario)
        string placa;
        string marca;
        string modelo;
        string color;
        decimal precioKilometro;

        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public decimal PrecioKilometro { get => precioKilometro; set => precioKilometro = value; }
    }
}
