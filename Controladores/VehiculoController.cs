using EstacionamientoMedido.Modelos;

namespace EstacionamientoMedido.Controladores {

    public class VehiculoController 
    {
        Repositorio repo = new Repositorio();

        public void GuardarVehiculos(v)
        {
            repo.Vehiculos.Add(v);
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            return repo.Vehiculos;
        }
    }
}