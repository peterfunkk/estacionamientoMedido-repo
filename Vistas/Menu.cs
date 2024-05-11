using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Vistas;

namespace EstacionamientoMedido.Vistas
{
    public class Menu
    {
        ClienteVista vistaCliente = new ClienteVista();
        EstacionamientoVista vistaEstacionamiento = new EstacionamientoVista();
        public void mostrarMenu()
        {
            int eleccion;
            Console.WriteLine("1- Iniciar Estacionamiento");
            Console.WriteLine("2- Finalizar Estacionamiento");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("3- Nuevo cliente");
            Console.WriteLine("4- Mostrar clientes cargados");
            Console.WriteLine();
            Console.Write("Opcion: ");
            eleccion = int.Parse(Console.ReadLine());


            switch (eleccion)
            {
                case 1:
                    vistaEstacionamiento.IniciarEstacionamiento();
                    mostrarMenu();
                    break;
                
                case 2:
                    vistaEstacionamiento.FinalizarEstacionamiento();
                    mostrarMenu();
                    break;

                case 3: // cargar un nuevo cliente al sistema
                    vistaCliente.CargarDatosCliente();
                    Console.WriteLine(); // Espacio en blanco antes de mostrar el menu
                    mostrarMenu(); // Una vez cargado, volvemos a mostrar el menú para elegir otra acción

                    break;
                case 4:
                    // veo clientes registrados

                    vistaCliente.MostrarClientesRegistrados();

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
