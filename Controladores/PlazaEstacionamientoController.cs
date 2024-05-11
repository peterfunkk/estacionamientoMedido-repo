using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Helpers;


namespace EstacionamientoMedido.Controladores 
{
    public class PlazaEstacionamientoController 
    {
        Repositorio repo = Repositorio.ObtenerInstancia();

        public void GuardarPlaza(PlazaEstacionamiento p)
        {
            repo.PlazasEstacionamiento.Add(p); 
        }

        public List<PlazaEstacionamiento> ObtenerPlazas()
        {
            return repo.PlazasEstacionamiento;
        }
    }
}