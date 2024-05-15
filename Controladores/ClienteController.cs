using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Helpers;
using FluentValidation.Results;
using EstacionamientoMedido.Validaciones;

namespace EstacionamientoMedido.Controladores
{
    public class ClienteController
    {

        Repositorio repo = Repositorio.ObtenerInstancia();
        
        public void GuardarCliente(Cliente c)
        {
            ClienteValidator valida = new ClienteValidator();
            ValidationResult resultadoValidacion = valida.Validate(c);
            if (resultadoValidacion.IsValid)
            {
                repo.Clientes.Add(c);
            }
            else
            {
                foreach (var item in resultadoValidacion.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }
            
        }

        public List<Cliente> ObtenerClientes()
        {
            return repo.Clientes;
        }

        public Cliente Modificar(Cliente c)
        {
            Cliente clienteAEliminar = repo.Clientes.Find(x => x.DNI == c.DNI);

            repo.Clientes.Remove(clienteAEliminar);

            repo.Clientes.Add(c);

            return c;
        }
        public void Eliminar(Cliente c)
        {
            Cliente clienteAEliminar = repo.Clientes.Find(x => x.DNI == c.DNI);

            repo.Clientes.Remove(clienteAEliminar);

        }
        public void AsignarVehiculo() { }
        GestorRespuesta<Cliente, string> ObtenerUnCliente(string dni)
        {
            Cliente clienteBuscado = repo.Clientes.Find(x => x.DNI == dni);

            if (clienteBuscado == null)
            {
                return new GestorRespuesta<Cliente, string>(true, "No se encontro cliente");
            }

            else
            {
                return new GestorRespuesta<Cliente, string>(false, clienteBuscado);
            }

        }

        GestorRespuesta<List<Cliente>, string> ObtenerClientesPorApellido(string filtro)
        {
            List<Cliente> busqueda = repo.Clientes
                .Where(x => x.Apellido.Contains(filtro) || x.Nombre.Contains(filtro) )
                .ToList();

            if(busqueda == null)
            {
                return new GestorRespuesta<List<Cliente>, string>(true, "No se encuentra el cliente");
            } 
            else
            {
                return new GestorRespuesta<List<Cliente>, string> (false, busqueda);
            }
        }
    }
}
