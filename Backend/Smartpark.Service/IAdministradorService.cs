using Smartpark.Domain;

namespace Smartpark.Service
{
    public interface IAdministradorService:IService<Administrador>
    {
        Administrador Login(string Username, string Contraseña);
    }
}