using System.Collections.Generic;
using Smartpark.Domain;
using Smartpark.Repository.DTO;

namespace Smartpark.Service
{
    public interface IComprobanteService:IService<Comprobante>
    {
         IEnumerable<ComprobanteViewModel> Getall();
    }
}