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

            Estacionamiento estacionamiento = new Estacionamiento();    
            estacionamiento.Entrada = DateTime.Now;
            estacionamiento.VehiculoEstacionado = vehiculoObtenido;
            estacionamiento.PrecioHora = 2000;

            repo.Estacionamientos.Add(estacionamiento);
        
        }

        public Estacionamiento FinalizarEstacionamiento(string patente)
        {
            Estacionamiento salida = repo.Estacionamientos
                .Where(x => x.VehiculoEstacionado.Patente == patente)
                .OrderByDescending(x => x.Entrada)
                .FirstOrDefault();

            repo.Estacionamientos.Remove(salida);

            salida.Salida = DateTime.Now;

            TimeSpan lapso = salida.Salida - salida.Entrada;

            int horasTranscurridas = (int)Math.Round(lapso.TotalHours);

            //TAREA: calculo precio total
            salida.TotalEstacionamiento = horasTranscurridas * salida.PrecioHora;

            repo.Estacionamientos .Add(salida);

            return salida;
        }



        public List<Estacionamiento> MostrarVehiculosEstacionados()
        {
            return repo.Estacionamientos;
        }

    }
}
