using Smartpark.Domain;

namespace Smartpark.Repository
{
    public interface IAdministradorRepository:ICrudRepository<Administrador>
    {
         Administrador Login(string Username, string Contraseña);
    }
}