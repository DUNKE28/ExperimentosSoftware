using Smartpark.Domain;
using Smartpark.Service;
using Xunit;
using Moq;
using Smartpark.Repository;
using Smartpark.Service.Implementacion;
using System.Collections.Generic;

public class CajeroTest
{
    [Fact]
    public void SaveCajero_True()
    {
        Cajero cajero = new Cajero();
        var mockCajeroRepository = new Mock<ICajeroRepository>();
        mockCajeroRepository.Setup(sp => sp.Save(cajero)).Returns(true);
        ICajeroService cajeroService = new CajeroService(mockCajeroRepository.Object);
        
        var resultado = cajeroService.Save(cajero);
        Assert.True(resultado);
    }
    [Fact]
    public void UpdateCajero_True()
    {
        Cajero cajero = new Cajero();
        var mockCajeroRepository = new Mock<ICajeroRepository>();
        mockCajeroRepository.Setup(sp => sp.Update(cajero)).Returns(true);
        ICajeroService cajeroService = new CajeroService(mockCajeroRepository.Object);
        
        var resultado = cajeroService.Update(cajero);
        Assert.True(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void GetByIdCajero_True(int id)
    {
        Cajero cajero = new Cajero();
        cajero.Id = id;
        var mockCajeroRepository = new Mock<ICajeroRepository>();
        mockCajeroRepository.Setup(sp => sp.Get(id)).Returns(cajero);
        ICajeroService cajeroService = new CajeroService(mockCajeroRepository.Object);
        
        var resultado = cajeroService.Get(id);
        Assert.Equal(1, resultado.Id);
    }
    [Fact]
    public void GetAllCajero_True()
    {
        List<Cajero> aux = new List<Cajero>();
        Cajero tar = new Cajero();
        aux.Add(tar);
        IEnumerable<Cajero> cajeros = aux;
        var mockCajeroRepository = new Mock<ICajeroRepository>();
        mockCajeroRepository.Setup(sp => sp.GetAll()).Returns(cajeros);
        ICajeroService cajeroService = new CajeroService(mockCajeroRepository.Object);
        
        var resultado = cajeroService.GetAll();
        Assert.NotEmpty(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void DeleteCajero_True(int id)
    {
        var mockCajeroRepository = new Mock<ICajeroRepository>();
        mockCajeroRepository.Setup(sp => sp.Delete(id)).Returns(true);
        ICajeroService cajeroService = new CajeroService(mockCajeroRepository.Object);
        
        var resultado = cajeroService.Delete(id);
        Assert.True(resultado);
    }
}