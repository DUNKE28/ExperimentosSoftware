using System.Collections.Generic;
using Smartpark.Domain;

namespace Smartpark.Repository
{
    public interface IEspacioRepository:ICrudRepository<Espacio>
    {
        IEnumerable<Espacio> GetByIdPark(int idPark);
    }
}