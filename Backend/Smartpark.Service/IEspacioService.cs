using System.Collections.Generic;
using Smartpark.Domain;

namespace Smartpark.Service
{
    public interface IEspacioService:IService<Espacio>
    {
        IEnumerable<Espacio> GetByIdPark(int idPark);
    }
}