using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using TurismoReal.Datos;

namespace TurismoReal.Negocio
{
    class NegocioUsuario
    {
        ModelContext db;
        OracleConnection conn;
        private string tipo;

        public NegocioUsuario()
        {
            db = new ModelContext();
            conn = (OracleConnection)db.Database.GetDbConnection();
        }
        public string Validar(string user)
        {
            try
            {
                conn.Open();
                string sql = "SP_Validar_Emp";
                OracleCommand oracleCommand = new OracleCommand(sql, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //parametros
                OracleParameter param1 = oracleCommand.Parameters.Add("CLIENTE_CURSOR", OracleDbType.RefCursor);
                param1.Direction = ParameterDirection.Output;
                oracleCommand.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)param1.Value).GetDataReader();
                while (reader.Read())
                {
                    string nombre_emp = reader.GetString(0); // Assuming nombre_emp is at index 0
                    string nombre_tipo = reader.GetString(1); // Assuming nombre_tipo is at index 1

                    // Use the retrieved values in an IF statement
                    if (nombre_emp == user)
                    {
                        tipo = nombre_tipo;
                    }
                    else
                    {
                        tipo = "";
                    }
                }
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
            return tipo;
        }
    }
}
