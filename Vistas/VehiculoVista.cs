using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;

namespace EstacionamientoMedido.Vistas
{
    public class VehiculoVista
    {
        Repositorio repo = Repositorio.ObtenerInstancia();
        VehiculoController vehiculoControlador = new VehiculoController();
        public void CrearVehiculo()
        {
            Vehiculo VehiculoCargar = new Vehiculo();

            Console.WriteLine("Patente: ");
            VehiculoCargar.Patente = Console.ReadLine();
            Console.WriteLine("Marca: ");
            VehiculoCargar.Marca =  Console.ReadLine ();
            Console.WriteLine("Color: ");
            VehiculoCargar.Color = Console.ReadLine();
            Console.WriteLine("Modelo: ");
            VehiculoCargar.Modelo = Console.ReadLine();

            repo.Vehiculos.Add(VehiculoCargar);
        }
        public void MostrarVehiculosRegistrados()
        {
            List<Vehiculo> listadoVehiculos = vehiculoControlador.ObtenerVehiculos();

            Console.WriteLine("Listado de clientes cargados en el sistema");

            foreach (var item in listadoVehiculos)
            {
                Console.WriteLine($"> Patente: {item.Patente} - Marca: {item.Marca} - Color: {item.Color} - Modelo: {item.Modelo}");
            }
        }
    }
}
