using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using BLL.Concrete;
using Misc;

namespace BLL.Extensions
{    
    public static class RutasBLLExtension
    {
        private static PasajesBDEntities db;

        public static IEnumerable<CIUDADES> GetAllId(this RutasBLL r ,  WInteger id)
        {
            try
            {
                using (db = new PasajesBDEntities())
                {
                    return (from t in db.CIUDADES
                            where !t.IdCiudad.Equals(id.Value)
                            select t).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
