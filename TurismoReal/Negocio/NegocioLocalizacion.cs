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
    class NegocioLocalizacion
    {
        ModelContext db;

        public NegocioLocalizacion()
        {
            db = new ModelContext();
        }
        public List<Region> ObtenerRegion()
        {
            return db.Regions.ToList();
        }
        public List<Ciudad> ObtenerCiudad() {
            return db.Ciudads.ToList();
        }
        public List<Comuna> ObtenerComuna() 
        {
            return db.Comunas.ToList();
        }
    }

}