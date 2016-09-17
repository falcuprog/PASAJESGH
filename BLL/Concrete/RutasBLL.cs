﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using BLL.Abstract;
using Misc;
using System.Data.Entity;

namespace BLL.Concrete
{
    public class RutasBLL:IAbstract<RUTAS, WInteger>
    {

        private PasajesBDEntities db;

        public void Add(RUTAS obj)
        {
            try
            {
                using (db = new PasajesBDEntities())
                {
                    db.RUTAS.Add(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(RUTAS obj)
        {
            try
            {
                using (db = new PasajesBDEntities())
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(RUTAS obj)
        {
            try
            {
                using (db = new PasajesBDEntities())
                {
                    db.Entry(obj).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RUTAS GetById(WInteger id)
        {
            try
            {
                using (db = new PasajesBDEntities())
                {
                    return (from t in db.RUTAS
                            where t.IdRuta.Equals(id.Value)
                            select t).SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<object> GetAll2()
        {
            try
            {
                using (db = new PasajesBDEntities())
                {
                    return (from t in db.RUTAS
                             join ciu in db.CIUDADES
                             on t.CiudadOrigen equals ciu.IdCiudad 
                             join ciu2 in db.CIUDADES
                             on t.CiudadDestino equals ciu2.IdCiudad
                             select new { idruta = t.IdRuta, ciudadOrigen = ciu.NombreCiudad, ciudadDestino = ciu2.NombreCiudad, valor = t.Valor}).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Save(RUTAS obj, WInteger id)
        {
            var x = GetById(id);

            if (x == null)
            {
                Add(obj);
            }
            else
            {
                Update(obj);
            }
        }

        public IEnumerable<RUTAS> GetAll()
        {
            try
            {
                using (db = new PasajesBDEntities())
                {
                    return (from t in db.RUTAS                            
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
