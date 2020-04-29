using System.Collections.Generic;
using Smartpark.Domain;
using Smartpark.Repository.DTO;

namespace Smartpark.Service
{
    public interface IIngresoService:IService<Ingreso>
    {
        IEnumerable<Ingreso> GetByParking(int idPark);
        IEnumerable<IngresoViewModel> Getall(int idPark);
    }
}