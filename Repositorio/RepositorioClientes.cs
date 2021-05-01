using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CursoCrud.Data;

namespace CursoCrud.Repositorio
{
    public class RepositorioClientes:IClientesRepositorio
    {
        private string CadenaConexion;

        public RepositorioClientes(String cadena)
        {
            CadenaConexion = cadena;
        }

        private SqlConnection conexion()
        {
            return new SqlConnection(CadenaConexion);
        }
       public async Task<bool> GuardarCliente (Clientes cliente)
       {
           Boolean clienteCreado = false;
           SqlConnection sqlConexion = conexion();
           SqlCommand Comm = null;
           try
           {
              sqlConexion.Open();
              Comm = sqlConexion.CreateCommand();
              Comm.CommandText = "dbo.InsertarCliente";
              Comm.CommandType = CommandType.StoredProcedure;
              Comm.Parameters.Add("@cliente",SqlDbType.VarChar,500).Value = cliente.Cliente;

                 await Comm.ExecuteNonQueryAsync();

               clienteCreado = true;      
           }
           catch (SqlException ex)
           {
               
               throw new Exception("Error al guardar "+ex.Message);
           } 
           finally
           {
               Comm.Dispose();
               sqlConexion.Close();
               sqlConexion.Dispose();
           }
           return clienteCreado;
       }
       public async Task<IEnumerable<Clientes>> DameTodosLosClientes()
       {
           List<Clientes> lista = new List<Clientes>();
           SqlConnection sqlConexion = conexion();
           SqlCommand Comm = null;
            try     
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.TraerClientes";
                Comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                while(reader.Read())
                {
                    Clientes c = new Clientes();
                    c.Id = Convert.ToInt32(reader["Cod_Cliente"]);
                    c.Cliente = reader["Cliente"].ToString();
                    lista.Add(c);
                }
                reader.Close();

            }
            catch(SqlException ex)
            {
                throw new Exception (ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
            return lista;
       }
       public async Task<IEnumerable<Clientes>> DameTodosLosClientes(string busqueda)
       {
           List<Clientes> lista = new List<Clientes>();
           SqlConnection sqlConexion = conexion();
           SqlCommand Comm = null;
            try     
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.TraerClientes";
                Comm.CommandType = CommandType.StoredProcedure;
                  Comm.Parameters.Add("@busqueda",SqlDbType.VarChar,500).Value = busqueda;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                while(reader.Read())
                {
                    Clientes c = new Clientes();
                    c.Id = Convert.ToInt32(reader["Cod_Cliente"]);
                    c.Cliente = reader["Cliente"].ToString();
                    lista.Add(c);
                }
                reader.Close();

            }
            catch(SqlException ex)
            {
                throw new Exception (ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
            return lista;
       }


        public async Task<Clientes> DameDatosClientes(int id)
        {
           Clientes cd = new Clientes(); 
           SqlConnection sqlConexion = conexion();
           SqlCommand Comm = null;
            try     
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.TraerClientes";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@id",SqlDbType.Int).Value = id;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                if(reader.Read())
                {
                    cd.Id = Convert.ToInt32(reader["Cod_Cliente"]);
                    cd.Cliente = reader["Cliente"].ToString();
                }
                reader.Close();

            }
            catch(SqlException ex)
            {
                throw new Exception (ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
            return cd;
       
        }
       public async Task<bool> ModificarClientes (Clientes cliente)
       {
           Boolean clienteModificado = false;
           SqlConnection sqlConexion = conexion();
           SqlCommand Comm = null;
           try
           {
              sqlConexion.Open();
              Comm = sqlConexion.CreateCommand();
              Comm.CommandText = "dbo.InsertarCliente";
              Comm.CommandType = CommandType.StoredProcedure;
              Comm.Parameters.Add("@cliente",SqlDbType.VarChar,500).Value = cliente.Cliente;
              Comm.Parameters.Add("@id",SqlDbType.Int).Value = cliente.Id;


                 await Comm.ExecuteNonQueryAsync();

               clienteModificado = true;      
           }
           catch (SqlException ex)
           {
               
               throw new Exception("Error al guardar "+ex.Message);
           } 
           finally
           {
               Comm.Dispose();
               sqlConexion.Close();
               sqlConexion.Dispose();
           }
           return clienteModificado;
       }
    public async Task<bool> BorrarClientes(int id)
    {
           Boolean clienteBorrado = false;
           SqlConnection sqlConexion = conexion();
           SqlCommand Comm = null;
           try
           {
              sqlConexion.Open();
              Comm = sqlConexion.CreateCommand();
              Comm.CommandText = "dbo.BorrarCliente";
              Comm.CommandType = CommandType.StoredProcedure;
              Comm.Parameters.Add("@id",SqlDbType.Int).Value = id;

                if(id > 0)
                 await Comm.ExecuteNonQueryAsync();

               clienteBorrado = true;      
           }
           catch (SqlException ex)
           {            
               throw new Exception("Error al borrar "+ex.Message);
           } 
           finally
           {
               Comm.Dispose();
               sqlConexion.Close();
               sqlConexion.Dispose();
           }
           return clienteBorrado ;

    }



    }
}