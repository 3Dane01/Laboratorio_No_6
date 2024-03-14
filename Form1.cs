using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_No_6
{
    public partial class Form1 : Form
    {
        List<Vehículos> ListaVehículos = new List<Vehículos>();
        List<Clientes> ListaClientes = new List<Clientes>();
        List<ReporteAlquiler> reportesAlquileres = new List<ReporteAlquiler>();
        List<Alquileres> ListaAlquileres = new List<Alquileres>();


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Vehículos nuevoVehículo = new Vehículos();
            nuevoVehículo.Placa = textBoxPlaca.Text;
            nuevoVehículo.Marca = textBoxMarca.Text;
            nuevoVehículo.Modelo = textBoxModelo.Text;
            nuevoVehículo.Color = textBoxColor.Text;
            nuevoVehículo.PrecioKilometro = Convert.ToInt32(textBoxPrecio.Text);
            ListaVehículos.Add(nuevoVehículo);
            string nombreArchivo = "Vehículos.txt";
            FileStream stream = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            // Escribir el último vehículo agregado en el archivo
            Vehículos últimoVehículo = ListaVehículos.Last();
            writer.WriteLine(últimoVehículo.Placa);
            writer.WriteLine(últimoVehículo.Marca);
            writer.WriteLine(últimoVehículo.Modelo);
            writer.WriteLine(últimoVehículo.Color);
            writer.WriteLine(últimoVehículo.PrecioKilometro);

            // Cerrar el StreamWriter
            writer.Close();


        }
        private void buttonCargar_Click(object sender, EventArgs e)
        {
            //cargar archivo Vehículos
            string nombreArchivo = "Vehículos.txt";
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                //leer datos
                Vehículos lista = new Vehículos();
                lista.Placa = reader.ReadLine();
                lista.Marca = reader.ReadLine();
                lista.Modelo = reader.ReadLine();
                lista.Color = reader.ReadLine();
                lista.PrecioKilometro = Convert.ToInt32(reader.ReadLine());
                ListaVehículos.Add(lista);
            }
            //para que cierre despues de abrir el archivo y no se quede abierto
            reader.Close();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListaVehículos;
            dataGridView1.Refresh();

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();

            //Cargar archivo Clientes
            string Archivo = "Clientes.txt";
            FileStream escritura = new FileStream(Archivo, FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(escritura);
            while (leer.Peek() > -1)
            {
                //leer datos
                Clientes listClientes = new Clientes();
                listClientes.Nit = leer.ReadLine();
                listClientes.Nombre = leer.ReadLine();
                listClientes.Direccion = leer.ReadLine();
                ListaClientes.Add(listClientes);
            }
            //para que cierre despues de abrir el archivo y no se quede abierto
            leer.Close();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = ListaClientes;
            dataGridView2.Refresh();

            dataGridView2.AutoResizeColumns();
            dataGridView2.AutoResizeRows();

        }

        private void buttonResultados_Click(object sender, EventArgs e)
        {
            string nombreArchivoAlquileres = "Alquileres.txt";
            FileStream streamAlquileres = new FileStream(nombreArchivoAlquileres, FileMode.Open, FileAccess.Read);
            StreamReader readerAlquileres = new StreamReader(streamAlquileres);

            while (readerAlquileres.Peek() > -1)
            {
                Alquileres alquiler = new Alquileres();
                alquiler.NitAlquiler = readerAlquileres.ReadLine();
                alquiler.PlacaAlquiler = readerAlquileres.ReadLine();
                alquiler.FechaAlquiler = readerAlquileres.ReadLine();
                alquiler.FechaDevolucion = readerAlquileres.ReadLine();
                alquiler.KilometrosRecorridos = Convert.ToDecimal(readerAlquileres.ReadLine());

                ListaAlquileres.Add(alquiler);
            }

            readerAlquileres.Close();

            foreach (Alquileres alquiler in ListaAlquileres)
            {
                Clientes clienteAlquiler = ListaClientes.FirstOrDefault(c => c.Nit == alquiler.NitAlquiler);

                Vehículos vehiculoAlquiler = ListaVehículos.FirstOrDefault(v => v.Placa == alquiler.PlacaAlquiler);

                if (clienteAlquiler != null && vehiculoAlquiler != null)
                {
                    ReporteAlquiler reporteAlquiler = new ReporteAlquiler();
                    reporteAlquiler.NombreCliente = clienteAlquiler.Nombre;
                    reporteAlquiler.PlacaVehiculo = vehiculoAlquiler.Placa;
                    reporteAlquiler.MarcaVehiculo = vehiculoAlquiler.Marca;
                    reporteAlquiler.ModeloVehiculo = vehiculoAlquiler.Modelo;
                    reporteAlquiler.ColorVehiculo = vehiculoAlquiler.Color;
                    reporteAlquiler.FechaDevolucion = alquiler.FechaDevolucion;
                    reporteAlquiler.TotalAPagar = alquiler.KilometrosRecorridos * vehiculoAlquiler.PrecioKilometro;

                    reportesAlquileres.Add(reporteAlquiler);
                }
            }
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = reportesAlquileres;
            dataGridView3.Refresh();
            Alquileres alquilerMaximo = ListaAlquileres.OrderByDescending(a => a.KilometrosRecorridos).First();
            labelMayorRecorrido.Text = alquilerMaximo.KilometrosRecorridos.ToString();
        }
    }
}
