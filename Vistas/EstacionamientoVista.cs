using EstacionamientoMedido.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Modelos;

namespace EstacionamientoMedido.Vistas
{
    public class EstacionamientoVista
    {
        VehiculoController VehiculoControlador = new VehiculoController();
        VehiculoVista vehiculoVista = new VehiculoVista();  
        EstacionamientoController controladorEstacionamiento = new EstacionamientoController(); 

        public void IniciarEstacionamiento()
        {
            Console.WriteLine("Ingrese patente para verificar si existe: ");
            string patente = Console.ReadLine();

            if (!VehiculoControlador.ExistePatente(patente))
            {
                Console.WriteLine("Esta patente no está registrada, vuelva a ingresar");
                vehiculoVista.CrearVehiculo();
            }
            if (!controladorEstacionamiento.YaEstaEstacionado(patente))
            {
                Vehiculo vehiculoEncontrado = VehiculoControlador.ObtenerVehiculoPorPatente(patente);
                controladorEstacionamiento.IniciarEstacionamiento(vehiculoEncontrado);
            }
            Console.WriteLine("Patente registrada, Iniciando Estacionamiento...");
            Console.WriteLine("------------------------------------------------");
            
            
        }
        public void FinalizarEstacionamiento()
        {
            Console.WriteLine();
            Console.WriteLine("Ingrese patente para finalizar estacionamiento: ");
            string patente = Console.ReadLine();
            Estacionamiento salida = controladorEstacionamiento.FinalizarEstacionamiento(patente);
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Precio Total: ${salida.TotalEstacionamiento}, Patente: {salida.VehiculoEstacionado.Patente}");
            Console.WriteLine("---------------------------------");
        }

        public void MostrarVehiculosEstacionados()
        {
            List<Estacionamiento> listadoEstacionamientos = controladorEstacionamiento.MostrarVehiculosEstacionados();
            if(listadoEstacionamientos.Count == 0) 
            {
                Console.WriteLine("No hay estacionamientos");
            }
            else
            {
                foreach (var item in listadoEstacionamientos)
                {
                    if (item.Estado == Enumeracion.EstadoEstacionamiento.Activo)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" >{item.VehiculoEstacionado.Patente} - {item.Entrada} ");
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($" >{item.VehiculoEstacionado.Patente} - {item.Entrada} / {item.Salida} ");
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            
        }
    }
}
