﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Helpers;

namespace EstacionamientoMedido.Controladores
{
    public class ClienteController
    {

        Repositorio repo = new Repositorio();

        public void GuardarCliente(Cliente c)
        {
            repo.Clientes.Add(c);
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
        public Cliente Eliminar(Cliente c)
        {
            Cliente clienteAEliminar = repo.Clientes.Find(x => x.DNI == c.DNI);

            repo.Clientes.Remove(clienteAEliminar);

        }
        public void AsignarVehiculo() { }
        public GestorRespuesta<Cliente> ObtenerUnCliente(string dni)
        {
            Cliente clienteBuscado = repo.Clientes.Find(x => x.DNI == dni);

            if (clienteBuscado == null)
            {
                return new GestorRespuesta<Cliente>()
                {
                    HayError = true,
                    MensajeError = "No se encuentra cliente con ese DNI",
                };

            }

            else
            {
                return new GestorRespuesta<Cliente>()
                {
                    HayError = false,
                    Respuesta = clienteBuscado,

                };
            }

        }

        public GestorRespuesta<List<Cliente>> ObtenenerClientesPorApellido(string filtro)
        {
            List<Cliente> busqueda = repo.Clientes
                .Where(x => x.Apellido.Contains(filtro) || x.Nombre.Contains(filtro) )
                .ToList();

            if(busqueda == null)
            {
                return new GestorRespuesta<List<Cliente>>()
                { HayError = true, MensajeError = "No se encuentra el cliente" };
            } 
            else
            {
                return new GestorRespuesta<List<Cliente>>()
                { Respuesta = busqueda };
            }
        }
    }
}
