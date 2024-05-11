using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Validaciones;
using FluentValidation.Results;

namespace EstacionamientoMedido.Controladores {

    public class VehiculoController 
    {
        Repositorio repo = Repositorio.ObtenerInstancia();

        public void GuardarVehiculos(Vehiculo v)
        {
            VehiculoValidator valida = new VehiculoValidator();

            ValidationResult resultadoValidacion = valida.Validate(v);

            if (resultadoValidacion.IsValid)
            {
                repo.Vehiculos.Add(v);
            }
            else
            {
                foreach (var item in resultadoValidacion.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }
            
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            return repo.Vehiculos;
        }

        public bool ExistePatente(string patente)
        {
            bool resultado;
            resultado = repo.Vehiculos.Any(x => x.Patente == patente);

            //Any devuelve un bool, sirve para saber si hay alguno

            return resultado;

        }

        public Vehiculo ObtenerVehiculoPorPatente(string patente)
        {
            Vehiculo vehiculoBuscado = repo.Vehiculos.Find(x => x.Patente == patente);
            return vehiculoBuscado;
        }
    }
}