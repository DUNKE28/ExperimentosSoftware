using Smartpark.Domain;
using Smartpark.Service;
using Xunit;
using Moq;
using Smartpark.Repository;
using Smartpark.Service.Implementacion;
using System.Collections.Generic;

public class ServicioTest
{
    [Fact]
    public void SaveServicio_True()
    {
        Servicio servicio = new Servicio();
        var mockServicioRepository = new Mock<IServicioRepository>();
        mockServicioRepository.Setup(sp => sp.Save(servicio)).Returns(true);
        IServicioService servicioService = new ServicioService(mockServicioRepository.Object);
        
        var resultado = servicioService.Save(servicio);
        Assert.True(resultado);
    }
    [Fact]
    public void UpdateServicio_True()
    {
        Servicio servicio = new Servicio();
        var mockServicioRepository = new Mock<IServicioRepository>();
        mockServicioRepository.Setup(sp => sp.Update(servicio)).Returns(true);
        IServicioService servicioService = new ServicioService(mockServicioRepository.Object);
        
        var resultado = servicioService.Update(servicio);
        Assert.True(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void GetByIdServicio_True(int id)
    {
        Servicio servicio = new Servicio();
        servicio.Id = id;
        var mockServicioRepository = new Mock<IServicioRepository>();
        mockServicioRepository.Setup(sp => sp.Get(id)).Returns(servicio);
        IServicioService servicioService = new ServicioService(mockServicioRepository.Object);
        
        var resultado = servicioService.Get(id);
        Assert.Equal(1, resultado.Id);
    }
    [Fact]
    public void GetAllServicio_True()
    {
        List<Servicio> aux = new List<Servicio>();
        Servicio tar = new Servicio();
        aux.Add(tar);
        IEnumerable<Servicio> servicios = aux;
        var mockServicioRepository = new Mock<IServicioRepository>();
        mockServicioRepository.Setup(sp => sp.GetAll()).Returns(servicios);
        IServicioService servicioService = new ServicioService(mockServicioRepository.Object);
        
        var resultado = servicioService.GetAll();
        Assert.NotEmpty(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void DeleteServicio_True(int id)
    {
        var mockServicioRepository = new Mock<IServicioRepository>();
        mockServicioRepository.Setup(sp => sp.Delete(id)).Returns(true);
        IServicioService servicioService = new ServicioService(mockServicioRepository.Object);
        
        var resultado = servicioService.Delete(id);
        Assert.True(resultado);
    }
}