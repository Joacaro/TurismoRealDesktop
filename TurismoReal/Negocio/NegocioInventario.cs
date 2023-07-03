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
    class NegocioInventario
    {
        ModelContext db;
        OracleConnection conn;

        public NegocioInventario()
        {
            db = new ModelContext();
            conn = (OracleConnection)db.Database.GetDbConnection();
        }
        public void InsertInv(Inventario inv)
        {
            try
            {
                conn.Open();
                string query = "SP_Inv_Mant";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@nombre_item", inv.NombreItem);
                oracleCommand.Parameters.Add("@cantidad", inv.Cantidad);
                oracleCommand.Parameters.Add("@tipo_item", inv.TipoItemId);
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
        public List<TipoItem> ObtenerTipo()
        {
            return db.TipoItems.ToList();
        }
    }
}
