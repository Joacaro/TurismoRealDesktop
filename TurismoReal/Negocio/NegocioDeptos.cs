using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TurismoReal.Datos;

namespace TurismoReal.Negocio
{
    internal class NegocioDeptos
    {
        ModelContext db;
        OracleConnection conn;

        public void Deptos()
        {
            db = new ModelContext();
            conn = (OracleConnection)db.Database.GetDbConnection();
        }

        public void InsertDepto(Departamento depto)
        {
            try
            {
                conn.Open();
                string query = "SP_Deptos_Mant";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@n_depto", depto.NDepto);
                oracleCommand.Parameters.Add("@cant_hab", depto.CantHab);
                oracleCommand.Parameters.Add("@cant_ban", depto.CantBan);
                oracleCommand.Parameters.Add("@disponibilidad", depto.Disponibilidad);
                oracleCommand.Parameters.Add("@mantenimiento", depto.Mantenimiento);
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
        public void UpdateDepto(Departamento depto)
        {
            try
            {
                conn.Open();
                string query = "SP_Deptos_update";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@n_depto", depto.NDepto);
                oracleCommand.Parameters.Add("@cant_hab", depto.CantHab);
                oracleCommand.Parameters.Add("@cant_ban", depto.CantBan);
                oracleCommand.Parameters.Add("@disponibilidad", depto.Disponibilidad);
                oracleCommand.Parameters.Add("@mantenimiento", depto.Mantenimiento);
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
        public void DeleteCliente(Departamento depto)
        {
            try
            {
                conn.Open();
                string query = "SP_Depto_delete";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@id_depto", depto);
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
                string query = "SP_Deptos_List";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleParameter param1 = oracleCommand.Parameters.Add("cursor_depto", OracleDbType.RefCursor);
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
