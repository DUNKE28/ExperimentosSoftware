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
        Parking parking = new Parking();
        var mockParkingRepository = new Mock<IParkingRepository>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockParkingRepository.Setup(sp => sp.Save(parking)).Returns(true);
        IParkingService parkingService = new ParkingService(mockParkingRepository.Object,mockEspacioRepository.Object);
        
        var resultado = parkingService.Save(parking);
        Assert.True(resultado);
    }
    [Fact]
    public void UpdateParking_True()
    {
        Parking parking = new Parking();
        var mockParkingRepository = new Mock<IParkingRepository>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockParkingRepository.Setup(sp => sp.Update(parking)).Returns(true);
        IParkingService parkingService = new ParkingService(mockParkingRepository.Object,mockEspacioRepository.Object);
        
        var resultado = parkingService.Update(parking);
        Assert.True(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void GetByIdParking_True(int id)
    {
        Parking parking = new Parking();
        parking.Id = id;
        var mockParkingRepository = new Mock<IParkingRepository>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockParkingRepository.Setup(sp => sp.Get(id)).Returns(parking);
        IParkingService parkingService = new ParkingService(mockParkingRepository.Object,mockEspacioRepository.Object);
        
        var resultado = parkingService.Get(id);
        Assert.Equal(1, resultado.Id);
    }
    [Fact]
    public void GetAllParking_True()
    {
        List<Parking> aux = new List<Parking>();
        Parking tar = new Parking();
        aux.Add(tar);
        IEnumerable<Parking> parkings = aux;
        var mockParkingRepository = new Mock<IParkingRepository>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockParkingRepository.Setup(sp => sp.GetAll()).Returns(parkings);
        IParkingService parkingService = new ParkingService(mockParkingRepository.Object,mockEspacioRepository.Object);
        
        var resultado = parkingService.GetAll();
        Assert.NotEmpty(resultado);
    }
    [Theory]
    [InlineData(1)]
    public void DeleteParking_True(int id)
    {
        var mockParkingRepository = new Mock<IParkingRepository>();
        var mockEspacioRepository = new Mock<IEspacioRepository>();
        mockParkingRepository.Setup(sp => sp.Delete(id)).Returns(true);
        IParkingService parkingService = new ParkingService(mockParkingRepository.Object,mockEspacioRepository.Object);
        
        var resultado = parkingService.Delete(id);
        Assert.True(resultado);
    }
}