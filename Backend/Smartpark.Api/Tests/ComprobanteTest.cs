using Smartpark.Domain;
using Smartpark.Service;
using Xunit;
using Moq;
using Smartpark.Repository;
using Smartpark.Service.Implementacion;
using System.Collections.Generic;
using Smartpark.Repository.Context;

public class ComprobanteTest
{
    [Fact]
    public void SaveComprobante_True()
    {
        Comprobante Comprobante = new Comprobante();
        var mockComprobanteRepository = new Mock<IComprobanteRepository>();
        var mockContext = new Mock<ApplicationDbContext>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockComprobanteRepository.Setup(sp => sp.Save(Comprobante)).Returns(true);
        IComprobanteService ComprobanteService = new ComprobanteService(mockComprobanteRepository.Object, mockContext.Object, mockEspacioRepository.Object);
        
        var resultado = ComprobanteService.Save(Comprobante);
        Assert.True(resultado);
    }
    [Fact]
    public void UpdateComprobante_True()
    {
        Comprobante Comprobante = new Comprobante();
        var mockComprobanteRepository = new Mock<IComprobanteRepository>();
        var mockContext = new Mock<ApplicationDbContext>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockComprobanteRepository.Setup(sp => sp.Update(Comprobante)).Returns(true);
        IComprobanteService ComprobanteService = new ComprobanteService(mockComprobanteRepository.Object, mockContext.Object, mockEspacioRepository.Object);
        
        var resultado = ComprobanteService.Update(Comprobante);
        Assert.True(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void GetByIdComprobante_True(int id)
    {
        Comprobante Comprobante = new Comprobante();
        Comprobante.Id = id;
        var mockComprobanteRepository = new Mock<IComprobanteRepository>();
        var mockContext = new Mock<ApplicationDbContext>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockComprobanteRepository.Setup(sp => sp.Get(id)).Returns(Comprobante);
        IComprobanteService ComprobanteService = new ComprobanteService(mockComprobanteRepository.Object, mockContext.Object, mockEspacioRepository.Object);
        
        var resultado = ComprobanteService.Get(id);
        Assert.Equal(1, resultado.Id);
    }
    [Fact]
    public void GetAllComprobante_True()
    {
        List<Comprobante> aux = new List<Comprobante>();
        Comprobante tar = new Comprobante();
        aux.Add(tar);
        IEnumerable<Comprobante> Comprobantes = aux;
        var mockComprobanteRepository = new Mock<IComprobanteRepository>();
        var mockContext = new Mock<ApplicationDbContext>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockComprobanteRepository.Setup(sp => sp.GetAll()).Returns(Comprobantes);
        IComprobanteService ComprobanteService = new ComprobanteService(mockComprobanteRepository.Object, mockContext.Object, mockEspacioRepository.Object);
        
        var resultado = ComprobanteService.GetAll();
        Assert.NotEmpty(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void DeleteComprobante_True(int id)
    {
        var mockComprobanteRepository = new Mock<IComprobanteRepository>();
        var mockContext = new Mock<ApplicationDbContext>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockComprobanteRepository.Setup(sp => sp.Delete(id)).Returns(true);
        IComprobanteService ComprobanteService = new ComprobanteService(mockComprobanteRepository.Object, mockContext.Object, mockEspacioRepository.Object);
        
        var resultado = ComprobanteService.Delete(id);
        Assert.True(resultado);
    }
}