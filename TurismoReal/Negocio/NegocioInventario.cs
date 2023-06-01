using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.Datos;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Types;

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
    }
}
