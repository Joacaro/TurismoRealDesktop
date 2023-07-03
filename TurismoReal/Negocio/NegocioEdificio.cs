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
    class NegocioEdificio
    {
        ModelContext db;
        OracleConnection conn;
        public NegocioEdificio() {
            db = new ModelContext();
            conn = (OracleConnection)db.Database.GetDbConnection();
        }
        public void InsertEdificio(Edificio edificio)
        {
            string query = "SP_Edificio_Mant";
            try
            {
                conn.Open();
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@direccion_ed", edificio.DireccionEd);
                oracleCommand.Parameters.Add("@telefono_ed", edificio.TelefonoEd);
                oracleCommand.Parameters.Add("@cant_pisos", edificio.CantPisos);
                oracleCommand.Parameters.Add("@nombre_adm", edificio.NombreAdm);
                oracleCommand.Parameters.Add("@comuna_id_com", edificio.ComunaIdCom);
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
        public List<Edificio> ObtenerEdificio()
        {
            return db.Edificios.ToList();
        }
    }
}
