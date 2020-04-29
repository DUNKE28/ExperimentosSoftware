using System.Collections.Generic;
using Smartpark.Domain;
using Smartpark.Repository.DTO;

namespace Smartpark.Repository
{
    public interface IIngresoRepository:ICrudRepository<Ingreso>
    {
        IEnumerable<Ingreso> GetByParking(int idPark);
        IEnumerable<IngresoViewModel> Getall(int idPark);
        
    }
}