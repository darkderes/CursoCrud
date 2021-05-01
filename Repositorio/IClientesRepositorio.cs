using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoCrud.Data;

namespace CursoCrud.Repositorio
{
    interface IClientesRepositorio
    {
       Task<bool> GuardarCliente(Clientes cliente);

       Task<IEnumerable<Clientes>> DameTodosLosClientes(); 

       Task<Clientes> DameDatosClientes(int id);

       Task<bool> ModificarClientes(Clientes cliente);

       Task<bool>  BorrarClientes(int id);

       Task<IEnumerable<Clientes>> DameTodosLosClientes(string busqueda); 
    }  
    
}

