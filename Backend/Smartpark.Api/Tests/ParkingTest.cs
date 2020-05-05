using Smartpark.Domain;
using Smartpark.Service;
using Xunit;
using Moq;
using Smartpark.Repository;
using Smartpark.Service.Implementacion;
using System.Collections.Generic;

public class ParkingTest
{
    [Fact]
    public void SaveParking_True()
    {
        Parking Parking = new Parking();
        var mockParkingRepository = new Mock<IParkingRepository>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockParkingRepository.Setup(sp => sp.Save(Parking)).Returns(true);
        IParkingService ParkingService = new ParkingService(mockParkingRepository.Object,mockEspacioRepository.Object);
        
        var resultado = ParkingService.Save(Parking);
        Assert.True(resultado);
    }
    [Fact]
    public void UpdateParking_True()
    {
        Parking Parking = new Parking();
        var mockParkingRepository = new Mock<IParkingRepository>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockParkingRepository.Setup(sp => sp.Update(Parking)).Returns(true);
        IParkingService ParkingService = new ParkingService(mockParkingRepository.Object,mockEspacioRepository.Object);
        
        var resultado = ParkingService.Update(Parking);
        Assert.True(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void GetByIdParking_True(int id)
    {
        Parking Parking = new Parking();
        Parking.Id = id;
        var mockParkingRepository = new Mock<IParkingRepository>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockParkingRepository.Setup(sp => sp.Get(id)).Returns(Parking);
        IParkingService ParkingService = new ParkingService(mockParkingRepository.Object,mockEspacioRepository.Object);
        
        var resultado = ParkingService.Get(id);
        Assert.Equal(1, resultado.Id);
    }
    [Fact]
    public void GetAllParking_True()
    {
        List<Parking> aux = new List<Parking>();
        Parking tar = new Parking();
        aux.Add(tar);
        IEnumerable<Parking> Parkings = aux;
        var mockParkingRepository = new Mock<IParkingRepository>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockParkingRepository.Setup(sp => sp.GetAll()).Returns(Parkings);
        IParkingService ParkingService = new ParkingService(mockParkingRepository.Object,mockEspacioRepository.Object);
        
        var resultado = ParkingService.GetAll();
        Assert.NotEmpty(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void DeleteParking_True(int id)
    {
        var mockParkingRepository = new Mock<IParkingRepository>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockParkingRepository.Setup(sp => sp.Delete(id)).Returns(true);
        IParkingService ParkingService = new ParkingService(mockParkingRepository.Object,mockEspacioRepository.Object);
        
        var resultado = ParkingService.Delete(id);
        Assert.True(resultado);
    }
}