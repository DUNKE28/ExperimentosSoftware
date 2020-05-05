using Smartpark.Domain;
using Smartpark.Service;
using Xunit;
using Moq;
using Smartpark.Repository;
using Smartpark.Service.Implementacion;
using System.Collections.Generic;

public class AdministradorTest
{
    [Fact]
    public void SaveAdministrador_True()
    {
        Administrador administrador = new Administrador();
        var mockAdministradorRepository = new Mock<IAdministradorRepository>();
        mockAdministradorRepository.Setup(sp => sp.Save(administrador)).Returns(true);
        IAdministradorService administradorService = new AdministradorService(mockAdministradorRepository.Object);
        
        var resultado = administradorService.Save(administrador);
        Assert.True(resultado);
    }
    [Fact]
    public void UpdateAdministrador_True()
    {
        Administrador administrador = new Administrador();
        var mockAdministradorRepository = new Mock<IAdministradorRepository>();
        mockAdministradorRepository.Setup(sp => sp.Update(administrador)).Returns(true);
        IAdministradorService administradorService = new AdministradorService(mockAdministradorRepository.Object);
        
        var resultado = administradorService.Update(administrador);
        Assert.True(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void GetByIdAdministrador_True(int id)
    {
        Administrador administrador = new Administrador();
        administrador.Id = id;
        var mockAdministradorRepository = new Mock<IAdministradorRepository>();
        mockAdministradorRepository.Setup(sp => sp.Get(id)).Returns(administrador);
        IAdministradorService administradorService = new AdministradorService(mockAdministradorRepository.Object);
        
        var resultado = administradorService.Get(id);
        Assert.Equal(1, resultado.Id);
    }
    [Fact]
    public void GetAllAdministrador_True()
    {
        List<Administrador> aux = new List<Administrador>();
        Administrador tar = new Administrador();
        aux.Add(tar);
        IEnumerable<Administrador> administradores = aux;
        var mockAdministradorRepository = new Mock<IAdministradorRepository>();
        mockAdministradorRepository.Setup(sp => sp.GetAll()).Returns(administradores);
        IAdministradorService administradorService = new AdministradorService(mockAdministradorRepository.Object);
        
        var resultado = administradorService.GetAll();
        Assert.NotEmpty(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void DeleteAdministrador_True(int id)
    {
        var mockAdministradorRepository = new Mock<IAdministradorRepository>();
        mockAdministradorRepository.Setup(sp => sp.Delete(id)).Returns(true);
        IAdministradorService administradorService = new AdministradorService(mockAdministradorRepository.Object);
        
        var resultado = administradorService.Delete(id);
        Assert.True(resultado);
    }
}