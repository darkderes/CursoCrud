using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoCrud.Data;
using CursoCrud.Interfaz;
using CursoCrud.Repositorio;

namespace CursoCrud.Servicios
{
    public class ServicioCliente:IClientesServices    
    {
        private IClientesRepositorio ClientesRepositorio;
        private SqlConfiguracion configuracion;

        public ServicioCliente(SqlConfiguracion c)
        {
            configuracion = c;
            ClientesRepositorio = new RepositorioClientes(configuracion.CadenaConexion);
        }
        public Task<bool> GuardarCliente(Clientes cliente)
        {
             if(cliente.Id == 0)
                return ClientesRepositorio.GuardarCliente(cliente);
            else 
                return ClientesRepositorio.ModificarClientes(cliente);

        }
        public Task<IEnumerable<Clientes>> DameTodosLosClientes()
        {
            return ClientesRepositorio.DameTodosLosClientes();
        }
        public Task<Clientes> DameDatosClientes(int id)
        {
            return ClientesRepositorio.DameDatosClientes(id);
        }

        public Task<bool> BorrarClientes(int id)
        {
            return ClientesRepositorio.BorrarClientes(id);
        }
        public Task<IEnumerable<Clientes>> DameTodosLosClientes(string busqueda)
        {
            return ClientesRepositorio.DameTodosLosClientes(busqueda);
        }
        

    }
}

