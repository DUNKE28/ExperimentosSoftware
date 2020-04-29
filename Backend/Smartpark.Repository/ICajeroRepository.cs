using Smartpark.Domain;

namespace Smartpark.Repository
{
    public interface ICajeroRepository:ICrudRepository<Cajero>
    {
        Cajero Login(string Username, string Contraseña);
    }
}