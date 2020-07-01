using System;

namespace FromTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int idTest = 4;
            switch (idTest)
                {
                    case 1:
                        //REGISTRO DE ADMINISTRADOR
                        Register register = new Register();
                        register.elUsuarioHaceClickEnRegistrar();
                        register.ingresaDatos();
                        register.registraAdministrador();
                        break;
                    case 2:
                        //REGISTRO DE CAJERO
                        LoginAdmin loginAdmin = new LoginAdmin();
                        loginAdmin.elUsuarioHaceClickEnLoginAdmin();
                        loginAdmin.ingresaCredenciales();
                        loginAdmin.iniciarSesion();
                        RegisterCajero registerCajero = new RegisterCajero();
                        registerCajero.listarCajero();
                        registerCajero.nuevoCajero();
                        registerCajero.ingresaDatosCajero();
                        registerCajero.registrarCajero();
                        break;
                    case 3:
                        //ACTUALIZAR REGISTRO DE CAJERO
                        LoginAdmin loginAdm = new LoginAdmin();
                        loginAdm.elUsuarioHaceClickEnLoginAdmin();
                        loginAdm.ingresaCredenciales();
                        loginAdm.iniciarSesion();
                        UpdateCajero updateCajero = new UpdateCajero();
                        updateCajero.listarCajero();
                        updateCajero.editarCajero();
                        updateCajero.modificarCajero();
                        updateCajero.actualizarCajero();
                        break;
                    case 4:
                        //ELIMINAR REGISTRO DE CAJERO
                        LoginAdmin loginAd = new LoginAdmin();
                        loginAd.elUsuarioHaceClickEnLoginAdmin();
                        loginAd.ingresaCredenciales();
                        loginAd.iniciarSesion();
                        DeleteCajero deleteCajero = new DeleteCajero();
                        deleteCajero.listarCajero();
                        deleteCajero.borrarCajero();
                        break;
                }

        }
    }
}
