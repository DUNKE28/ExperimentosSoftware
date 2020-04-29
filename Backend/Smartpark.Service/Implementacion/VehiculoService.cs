using System.Collections.Generic;
using Smartpark.Domain;
using Smartpark.Repository;

namespace Smartpark.Service.Implementacion
{
    public class VehiculoService : IVehiculoService
    {
        private IVehiculoRepository vehiculorepository;
        public VehiculoService(IVehiculoRepository vehiculorepository){
            this.vehiculorepository=vehiculorepository;
        }
        public bool Delete(int id)
        {
            return vehiculorepository.Delete(id);
        }

        public Vehiculo Get(int id)
        {
            return vehiculorepository.Get(id);
        }

        public IEnumerable<Vehiculo> GetAll()
        {
            return vehiculorepository.GetAll();
        }

        public bool Save(Vehiculo entity)
        {
            return vehiculorepository.Save(entity);
        }

        public bool Update(Vehiculo entity)
        {
            return vehiculorepository.Update(entity);
        }
    }
}