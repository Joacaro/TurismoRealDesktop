using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.Datos;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Windows;

namespace TurismoReal.Negocio
{
    class NegocioServicios
    {
        ModelContext db;
        OracleConnection conn;

        public NegocioServicios()
        {
            db = new ModelContext();
            conn = (OracleConnection)db.Database.GetDbConnection();
        }
        public void InsertServicio(TipoCompaniaServicio tipoCompaniaServicio)
        {
            string query = "SP_Servicios_Mant";
            try
            {
                conn.Open();
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@nombre_comp", tipoCompaniaServicio.NombreComp);
                oracleCommand.Parameters.Add("@telefono_comp", tipoCompaniaServicio.TelefonoComp);
                oracleCommand.Parameters.Add("@correo_comp", tipoCompaniaServicio.CorreoComp);
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
    }
}
