using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Windows;

namespace TurismoReal.Negocio
{
    class NegocioCliente
    {
        ModelContext db;
        OracleConnection conn;
        public void Cliente()
        {
            db = new ModelContext();
            conn = (OracleConnection)db.Database.GetDbConnection();
        }
        public void InsertCliente(Cliente cliente)
        {
            try
            {
                conn.Open();
                string query = "SP_Clientes_Mant";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@rut", null);
                oracleCommand.Parameters.Add("@nombre_cli", cliente.NombreCli);
                oracleCommand.Parameters.Add("@apaterno_cli", cliente.ApaternoCli);
                oracleCommand.Parameters.Add("@amaterno_cli", cliente.AmaternoCli);
                oracleCommand.Parameters.Add("@edad_cli", cliente.EdadCli);
                oracleCommand.Parameters.Add("@sexo_cli", cliente.SexoCli);
                oracleCommand.Parameters.Add("@direccion_cli", cliente.DireccionCli);
                oracleCommand.Parameters.Add("@estadocivil_cli", cliente.EstadocivilCli);
                oracleCommand.Parameters.Add("@telefono", cliente.Telefono);
                oracleCommand.Parameters.Add("@email", cliente.Email);
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                string title = "Error";
                MessageBox.Show(message, title);
            }
            finally
            {
                conn.Close();
            }
        }
        public void UpdateCliente(Cliente cliente)
        {
            try
            {
                conn.Open();
                string query = "SP_cliente_update";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@nombre_cli", cliente.NombreCli);
                oracleCommand.Parameters.Add("@apaterno_cli", cliente.ApaternoCli);
                oracleCommand.Parameters.Add("@amaterno_cli", cliente.AmaternoCli);
                oracleCommand.Parameters.Add("@edad_cli", cliente.EdadCli);
                oracleCommand.Parameters.Add("@sexo_cli", cliente.SexoCli);
                oracleCommand.Parameters.Add("@direccion_cli", cliente.DireccionCli);
                oracleCommand.Parameters.Add("@estadocivil_cli", cliente.EstadocivilCli);
                oracleCommand.Parameters.Add("@telefono", cliente.Telefono);
                oracleCommand.Parameters.Add("@email", cliente.Email);
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                string title = "Error";
                MessageBox.Show(message, title);
            }
            finally
            {
                conn.Close();
            }
        }
        public void DeleteCliente(Cliente cliente)
        {
            try
            {
                conn.Open();
                string query = "SP_cliente_delete";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@id_cli", cliente.IdCli);
                oracleCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                string title = "Error";
                MessageBox.Show(message, title);
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable GetCursor()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string query = "SP_Cliente_List";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleParameter param1 = oracleCommand.Parameters.Add("cursor_cli", OracleDbType.RefCursor);
                param1.Direction = ParameterDirection.Output;
                oracleCommand.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)param1.Value).GetDataReader();
                dt.Load(reader);
                reader.Close();
                //Liberar recursos
                reader.Dispose();
                param1.Dispose();
                oracleCommand.Dispose();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                string title = "Error";
                MessageBox.Show(message, title);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public List<Cliente> GetCliente()
        {
            return db.Clientes.Where(x => x.IsActive == 1).ToList();
        }
    }
}
