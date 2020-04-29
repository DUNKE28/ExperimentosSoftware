using System.Collections.Generic;
using System.Linq;
using Smartpark.Domain;
using Smartpark.Repository;

namespace Smartpark.Service.Implementacion
{
    public class ParkingService : IParkingService
    {
         private IParkingRepository parkingRepository;
         private IEspacioRepository espacioRepository;

        public ParkingService(IParkingRepository parkingRepository,IEspacioRepository espacioRepository)
        {
            this.parkingRepository =parkingRepository;
            this.espacioRepository=espacioRepository;
        }

        public bool Delete(int id)
        {
             return parkingRepository.Delete(id);
        }

        public Parking Get(int id)
        {
             return parkingRepository.Get(id);
        }

        public IEnumerable<Parking> GetAll()
        {
            return parkingRepository.GetAll();
        }

        public bool Save(Parking entity)
        {
            if (parkingRepository.Save(entity))
            {
                for (int i = 0; i < entity.Numero_Espacios; i++)
                {
                        var nuevo= new Espacio{
                        Identificador="COD "+ (i+1),
                        Disponibilidad_espacio=true,
                        id_parking= entity.Id
                        };
                        espacioRepository.Save(nuevo);
                } 
                return true;
            }
            return false;
        }

        public bool Update(Parking entity)
        {
            return parkingRepository.Update(entity);
        }
    }
}