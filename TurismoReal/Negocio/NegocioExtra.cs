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
    internal class NegocioExtra
    {
        ModelContext db;
        OracleConnection conn;

        public NegocioExtra() {
            db = new ModelContext();
            conn = (OracleConnection)db.Database.GetDbConnection();
        }
    }
}
