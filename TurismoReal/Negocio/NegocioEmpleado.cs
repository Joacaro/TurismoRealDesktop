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

        public NegocioEmpleado()
        {
            db = new ModelContext();
            conn = (OracleConnection)db.Database.GetDbConnection();
        }
        public void InsertEmp(Empleado emp)
        {
            try
            {
                conn.Open();
                string query = "SP_Emp_Mant";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@vat", null);
                oracleCommand.Parameters.Add("@nombre_emp", emp.NombreEmp);
                oracleCommand.Parameters.Add("@apaterno_emp", emp.ApatenoEmp);
                oracleCommand.Parameters.Add("@amaterno_emp", emp.AmaternoEmp);
                oracleCommand.Parameters.Add("@telefono", emp.Telefono);
                oracleCommand.Parameters.Add("@id_tipo_emp_id", emp.IdTipoEmpNavigation);
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
        public void UpdateEmp(Empleado emp)
        {
            try
            {
                conn.Open();
                string query = "SP_Deptos_update";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@nombre_emp", emp.NombreEmp);
                oracleCommand.Parameters.Add("@apaterno_emp", emp.ApatenoEmp);
                oracleCommand.Parameters.Add("@amaterno_emp", emp.AmaternoEmp);
                oracleCommand.Parameters.Add("@telefono", emp.Telefono);
                oracleCommand.Parameters.Add("@id_tipo_emp_id", emp.IdTipoEmpNavigation);
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
        public void DeleteEmp(Empleado emp)
        {
            try
            {
                conn.Open();
                string query = "SP_Emp_delete";
                OracleCommand oracleCommand = new OracleCommand(query, conn);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                //Parametros
                oracleCommand.Parameters.Add("@id_emp", emp.IdEmp);
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
        public List<Empleado> ObtenerAdmin()
        {
            return db.Empleados.Where(x => x.IdTipoEmpId == 1).ToList();
        }
    }
}
