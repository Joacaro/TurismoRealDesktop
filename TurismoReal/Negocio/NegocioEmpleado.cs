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
    internal class NegocioEmpleado
    {
        ModelContext db;
        OracleConnection conn;

        public void Empleado()
        {
            db = new ModelContext();
            conn = (OracleConnection)db.Database.GetDbConnection();
        }
        public DataTable GetCursor()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string query = "SP_Empleados_List";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                OracleParameter param1 = oracleCommand.Parameters.Add("Empleados_curs", OracleDbType.RefCursor);
                oracleCommand.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)param1.Value).GetDataReader();
                dt.Load(reader);
                reader.Close();
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
    }
}
