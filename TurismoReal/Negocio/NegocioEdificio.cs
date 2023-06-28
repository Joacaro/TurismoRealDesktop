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
    }
}
