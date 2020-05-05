using Smartpark.Domain;
using Smartpark.Service;
using Xunit;
using Moq;
using Smartpark.Repository;
using Smartpark.Service.Implementacion;
using System.Collections.Generic;

public class TarifaTest
{
    [Fact]
    public void SaveTarifa_True()
    {
        Tarifa tarifa = new Tarifa();
        var mockTarifaRepository = new Mock<ITarifaRepository>();
        mockTarifaRepository.Setup(sp => sp.Save(tarifa)).Returns(true);
        ITarifaService tarifaService = new TarifaService(mockTarifaRepository.Object);
        
        var resultado = tarifaService.Save(tarifa);
        Assert.True(resultado);
    }
    [Fact]
    public void UpdateTarifa_True()
    {
        Tarifa tarifa = new Tarifa();
        var mockTarifaRepository = new Mock<ITarifaRepository>();
        mockTarifaRepository.Setup(sp => sp.Update(tarifa)).Returns(true);
        ITarifaService tarifaService = new TarifaService(mockTarifaRepository.Object);
        
        var resultado = tarifaService.Update(tarifa);
        Assert.True(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void GetByIdTarifa_True(int id)
    {
        Tarifa tarifa = new Tarifa();
        tarifa.Id = id;
        var mockTarifaRepository = new Mock<ITarifaRepository>();
        mockTarifaRepository.Setup(sp => sp.Get(id)).Returns(tarifa);
        ITarifaService tarifaService = new TarifaService(mockTarifaRepository.Object);
        
        var resultado = tarifaService.Get(id);
        Assert.Equal(1, resultado.Id);
    }
    [Fact]
    public void GetAllTarifa_True()
    {
        List<Tarifa> aux = new List<Tarifa>();
        Tarifa tar = new Tarifa();
        aux.Add(tar);
        IEnumerable<Tarifa> tarifas = aux;
        var mockTarifaRepository = new Mock<ITarifaRepository>();
        mockTarifaRepository.Setup(sp => sp.GetAll()).Returns(tarifas);
        ITarifaService tarifaService = new TarifaService(mockTarifaRepository.Object);
        
        var resultado = tarifaService.GetAll();
        Assert.NotEmpty(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void DeleteTarifa_True(int id)
    {
        var mockTarifaRepository = new Mock<ITarifaRepository>();
        mockTarifaRepository.Setup(sp => sp.Delete(id)).Returns(true);
        ITarifaService tarifaService = new TarifaService(mockTarifaRepository.Object);
        
        var resultado = tarifaService.Delete(id);
        Assert.True(resultado);
    }
}