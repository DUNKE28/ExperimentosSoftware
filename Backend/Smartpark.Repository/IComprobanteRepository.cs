using System.Collections.Generic;
using Smartpark.Domain;
using Smartpark.Repository.DTO;

namespace Smartpark.Repository
{
    public interface IComprobanteRepository:ICrudRepository<Comprobante>
    {
         IEnumerable<ComprobanteViewModel> Getall();
    }
}