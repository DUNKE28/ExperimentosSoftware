using Smartpark.Domain;
using Smartpark.Service;
using Xunit;
using Moq;
using Smartpark.Repository;
using Smartpark.Service.Implementacion;
using System.Collections.Generic;

public class IngresoTest 
{
    [Fact]
    public void UpdateIngreso_True()
    {
        Ingreso ingreso = new Ingreso();
        var mockIngresoRepository = new Mock<IIngresoRepository>();
        mockIngresoRepository.Setup(sp => sp.Update(ingreso)).Returns(true);
        IIngresoService ingresoService = new IngresoService(mockIngresoRepository.Object);
        
        var resultado = ingresoService.Update(ingreso);
        Assert.True(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void GetByIdIngreso_True(int id)
    {
        Ingreso ingreso = new Ingreso();
        ingreso.Id = id;
        var mockIngresoRepository = new Mock<IIngresoRepository>();
        mockIngresoRepository.Setup(sp => sp.Get(id)).Returns(ingreso);
        IIngresoService ingresoService = new IngresoService(mockIngresoRepository.Object);
        
        var resultado = ingresoService.Get(id);
        Assert.Equal(1, resultado.Id);
    }
    [Fact]
    public void GetAllIngreso_True()
    {
        List<Ingreso> aux = new List<Ingreso>();
        Ingreso tar = new Ingreso();
        aux.Add(tar);
        IEnumerable<Ingreso> ingresos = aux;
        var mockIngresoRepository = new Mock<IIngresoRepository>();
        mockIngresoRepository.Setup(sp => sp.GetAll()).Returns(ingresos);
        IIngresoService ingresoService = new IngresoService(mockIngresoRepository.Object);
        
        var resultado = ingresoService.GetAll();
        Assert.NotEmpty(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void DeleteIngreso_True(int id)
    {
        var mockIngresoRepository = new Mock<IIngresoRepository>();
        mockIngresoRepository.Setup(sp => sp.Delete(id)).Returns(true);
        IIngresoService ingresoService = new IngresoService(mockIngresoRepository.Object);
        
        var resultado = ingresoService.Delete(id);
        Assert.True(resultado);
    }
}