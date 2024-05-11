using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    //Reglas a aplicar 
    /*
     * 1 -> constructor privado
     * 2-> metodo para obtener instancia
     * 2.1 -> si no existe la crea, y si existe devuelve la misma
     * 3-> el metodo tiene que ser estatico
     */



    public class Repositorio
    {
        public List<Cliente> Clientes = new List<Cliente>();
        public List<Vehiculo> Vehiculos = new List<Vehiculo>();
        public List<PlazaEstacionamiento> PlazasEstacionamiento = new List<PlazaEstacionamiento>();
        public List<Estacionamiento> Estacionamientos = new List<Estacionamiento>();

        private static Repositorio instancia;


        private Repositorio()
        {
            Clientes.Add(new Cliente()
            {
                Nombre = "Pepe",
                Apellido = "Gonzales",
                Telefono = "123456",
                Email = "notiene@gmail.com",
            });
            Clientes.Add(new Cliente()
            {
                Nombre = "Juan",
                Apellido = "Fernandez",
                Telefono = "654321",
                Email = "estesitiene@gmail.com",
            });
        }


        //patron de diseño SINGLETONE
        public static Repositorio ObtenerInstancia()
        {
            if(instancia == null)
            {
                instancia = new Repositorio();
                return instancia;
            }
            else
            {
                return instancia;
            }
        }

    }
}
