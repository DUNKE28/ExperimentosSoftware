using System.Collections.Generic;
using System.Linq;
using Smartpark.Domain;
using Smartpark.Repository.Context;

namespace Smartpark.Repository.Implementacion
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private ApplicationDbContext context;

        public VehiculoRepository(ApplicationDbContext context)
        {
            this.context=context;
        }
        public bool Delete(int id)
        {
            try
            {
                var vehiculo = context.Vehiculos.Single(x => x.Id == id);
                context.Remove(vehiculo);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public Vehiculo Get(int id)
        {
            var result = new Vehiculo();
            try
            {
                result = context.Vehiculos.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Vehiculo> GetAll()
        {
            var result = new List<Vehiculo>();
            try
            {
                result = context.Vehiculos.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Vehiculo entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public bool Update(Vehiculo entity)
        {
            try
            {
                var vehiculo = context.Vehiculos.Single(x => x.Id == entity.Id);
                vehiculo.Id = entity.Id;
                vehiculo.Nombre = entity.Nombre;
                vehiculo.Tipo_vehiculo = entity.Tipo_vehiculo;

                context.Update(vehiculo);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }
    }
}