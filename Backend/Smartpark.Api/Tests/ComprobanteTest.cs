using Smartpark.Domain;
using Smartpark.Service;
using Xunit;
using Moq;
using Smartpark.Repository;
using Smartpark.Service.Implementacion;
using System.Collections.Generic;

public class ComprobanteTest
{
    [Fact]
    public void UpdateComprobante_True()
    {
        Comprobante comprobante = new Comprobante();
        var mockComprobanteRepository = new Mock<IComprobanteRepository>();
        mockComprobanteRepository.Setup(sp => sp.Update(comprobante)).Returns(true);
        IComprobanteService comprobanteService = new ComprobanteService(mockComprobanteRepository.Object);
        
        var resultado = comprobanteService.Update(comprobante);
        Assert.True(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void GetByIdComprobante_True(int id)
    {
        Comprobante comprobante = new Comprobante();
        comprobante.Id = id;
        var mockComprobanteRepository = new Mock<IComprobanteRepository>();
        mockComprobanteRepository.Setup(sp => sp.Get(id)).Returns(comprobante);
        IComprobanteService comprobanteService = new ComprobanteService(mockComprobanteRepository.Object);
        
        var resultado = comprobanteService.Get(id);
        Assert.Equal(1, resultado.Id);
    }
    [Fact]
    public void GetAllComprobante_True()
    {
        List<Comprobante> aux = new List<Comprobante>();
        Comprobante tar = new Comprobante();
        aux.Add(tar);
        IEnumerable<Comprobante> comprobantes = aux;
        var mockComprobanteRepository = new Mock<IComprobanteRepository>();
        mockComprobanteRepository.Setup(sp => sp.GetAll()).Returns(comprobantes);
        IComprobanteService comprobanteService = new ComprobanteService(mockComprobanteRepository.Object);
        
        var resultado = comprobanteService.GetAll();
        Assert.NotEmpty(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void DeleteComprobante_True(int id)
    {
        var mockComprobanteRepository = new Mock<IComprobanteRepository>();
        mockComprobanteRepository.Setup(sp => sp.Delete(id)).Returns(true);
        IComprobanteService comprobanteService = new ComprobanteService(mockComprobanteRepository.Object);
        
        var resultado = comprobanteService.Delete(id);
        Assert.True(resultado);
    }
}