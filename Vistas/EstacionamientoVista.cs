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
                vehiculoVista.CrearVehiculo();
            }
            controladorEstacionamiento.IniciarEstacionamiento(patente);
            
        }
        public void FinalizarEstacionamiento()
        {
            Console.WriteLine();
            Console.WriteLine("Ingrese patente para estacionar: ");
            string patente = Console.ReadLine();
            controladorEstacionamiento.FinalizarEstacionamiento(patente);
        }

        public void MostrarVehiculosEstacionados()
        {
            List<Estacionamiento> listadoEstacionamientos = controladorEstacionamiento.MostrarVehiculosEstacionados();

            foreach (var item in listadoEstacionamientos)
            {
                Console.WriteLine($"> Patente: {item.VehiculoEstacionado.Patente} - Marca: {item.VehiculoEstacionado.Marca} - Color: {item.VehiculoEstacionado.Color} - Modelo: {item.VehiculoEstacionado.Modelo}");
            }
        }
    }
}
