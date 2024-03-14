using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_No_6
{
    internal class Clientes
    {
        //Uno con los clientes:  Nit, Nombre, Dirección(el archivo ya tiene que tener datos)
        string nit;
        string nombre;
        string direccion;

        public string Nit { get => nit; set => nit = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}
