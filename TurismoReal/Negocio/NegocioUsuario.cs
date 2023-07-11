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
        public string Validar(string user, string pass)
        {
            try
            {
                conn.Open();
                string sql = "SP_Validar_Emp";
                OracleCommand oracleCommand = new OracleCommand(sql, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //parametros               
                oracleCommand.Parameters.Add("puser", OracleDbType.Varchar2).Value = user;
                oracleCommand.Parameters.Add("cursor_val", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                oracleCommand.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)oracleCommand.Parameters["cursor_val"].Value).GetDataReader();
                while (reader.Read())
                {
                    string nombre_emp = reader.GetString(0); // Assuming nombre_emp is at index 0
                    string clave_emp = reader.GetString(1); // Assuming clave is at index 1
                    string nombre_tipo = reader.GetString(2); // Assuming nombre_tipo is at index 2

                    // Use the retrieved values in an IF statement
                    if (nombre_emp == user && clave_emp == pass)
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
