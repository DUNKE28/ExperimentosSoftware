using Smartpark.Domain;

namespace Smartpark.Service
{
    public interface ICajeroService:IService<Cajero>
    {
        Cajero Login(string Username, string Contraseña);
    }
}