using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class Menu
    {
        void mostrarMenu()
        {
            int eleccion;
            Console.WriteLine("1- Cargar un cliente");
            Console.WriteLine("2- Ver clientes registrados");
            Console.WriteLine();
            Console.Write("Opcion: ");
            eleccion = int.Parse(Console.ReadLine());


            switch (eleccion)
            {
                case 1: // cargar un nuevo cliente al sistema

                    Cliente clienteTemporal = CargarDatosCliente();

                    // validaciones

                    controladorClientes.GuardarCliente(clienteTemporal); // Agregamos el nuevo cliente a la lista de clientes

                    // Clientes.Add( CargarDatosCliente() );  // Opcion de una sola linea

                    Console.WriteLine(); // Espacio en blanco antes de mostrar el menu
                    mostrarMenu(); // Una vez cargado, volvemos a mostrar el menú para elegir otra acción

                    break;
                case 2:
                    // veo clientes registrados

                    MostrarClientesRegistrados(controladorClientes.ObtenerClientes());

                    Console.WriteLine();
                    mostrarMenu();
                    break;

                default:
                    Console.Clear();
                    mostrarMenu();
                    break;
            }
        }
    }
}
