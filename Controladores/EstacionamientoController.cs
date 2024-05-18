using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Controladores
{
    public class EstacionamientoController
    {
        Repositorio repo = Repositorio.ObtenerInstancia();
        VehiculoController VehiculoControlador = new VehiculoController();


        public void IniciarEstacionamiento(Vehiculo vehiculo)
        {
            Vehiculo vehiculoObtenido = vehiculo;

            Estacionamiento estacionamiento = new Estacionamiento(vehiculoObtenido, 2000);

            repo.Estacionamientos.Add(estacionamiento);

        }

        public Estacionamiento FinalizarEstacionamiento(string patente)
        {
            Estacionamiento salida = repo.Estacionamientos
                .Where(x => x.VehiculoEstacionado.Patente == patente)
                .OrderByDescending(x => x.Entrada)
                .FirstOrDefault();

            repo.Estacionamientos.Remove(salida);

            salida.SalidaEstacionamiento();

            repo.Estacionamientos .Add(salida);

            return salida;
        }



        public List<Estacionamiento> MostrarVehiculosEstacionados()
        {
            return repo.Estacionamientos;
        }

        public bool YaEstaEstacionado(string patente)
        {
            bool resultado;

            resultado = repo.Estacionamientos
                .Where(x => x.VehiculoEstacionado.Patente == patente)
                .Where(x => x.Estado == Enumeracion.EstadoEstacionamiento.Activo)
                .Any();
            return resultado;
        }
    }
}
