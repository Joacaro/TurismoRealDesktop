using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
