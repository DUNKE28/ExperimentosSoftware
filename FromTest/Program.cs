using System;

namespace FromTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Register register = new Register();
            register.elUsuarioHaceClickEnRegistrar();
            register.ingresaDatos();
            register.registraAdministrador();
        }
    }
}
