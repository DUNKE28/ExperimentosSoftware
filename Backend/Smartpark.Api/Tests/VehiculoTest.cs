using System.Collections.Generic;
using Moq;
using Smartpark.Domain;
using Smartpark.Repository;
using Smartpark.Service;
using Smartpark.Service.Implementacion;
using Xunit;

namespace Smartpark.Api.Tests
{
    public class VehiculoTest
    {
        [Fact]
        public void SaveVehiculo_True()
        {
            Vehiculo vehiculo = new Vehiculo();
            var mockVehiculoRepository = new Mock<IVehiculoRepository>();
            mockVehiculoRepository.Setup(sp => sp.Save(vehiculo)).Returns(true);
            IVehiculoService vehiculoService = new VehiculoService(mockVehiculoRepository.Object);
            
            var resultado = vehiculoService.Save(vehiculo);
            Assert.True(resultado);
        }
        [Fact]
        public void UpdateVehiculo_True()
        {
            Vehiculo vehiculo = new Vehiculo();
            var mockVehiculoRepository = new Mock<IVehiculoRepository>();
            mockVehiculoRepository.Setup(sp => sp.Update(vehiculo)).Returns(true);
            IVehiculoService vehiculoService = new VehiculoService(mockVehiculoRepository.Object);
            
            var resultado = vehiculoService.Update(vehiculo);
            Assert.True(resultado);
        }
        [Theory]
        [InlineData(1)]
        public void GetByIdVehiculo_True(int id)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.Id = id;
            var mockVehiculoRepository = new Mock<IVehiculoRepository>();
            mockVehiculoRepository.Setup(sp => sp.Get(id)).Returns(vehiculo);
            IVehiculoService vehiculoService = new VehiculoService(mockVehiculoRepository.Object);
            
            var resultado = vehiculoService.Get(id);
            Assert.Equal(1, resultado.Id);
        }
        [Fact]
        public void GetAllVehiculo_True()
        {
            List<Vehiculo> auxList = new List<Vehiculo>();
            Vehiculo veh = new Vehiculo();
            auxList.Add(veh);
            IEnumerable<Vehiculo> vehiculos = auxList;
            var mockVehiculoRepository = new Mock<IVehiculoRepository>();
            mockVehiculoRepository.Setup(sp => sp.GetAll()).Returns(vehiculos);
            IVehiculoService vehiculoService = new VehiculoService(mockVehiculoRepository.Object);
            
            var resultado = vehiculoService.GetAll();
            Assert.NotEmpty(resultado);
        }
        [Theory]
        [InlineData(1)]
        public void DeleteVehiculo_True(int id)
        {
            var mockVehiculoRepository = new Mock<IVehiculoRepository>();
            mockVehiculoRepository.Setup(sp => sp.Delete(id)).Returns(true);
            IVehiculoService vehiculoService = new VehiculoService(mockVehiculoRepository.Object);
            
            var resultado = vehiculoService.Delete(id);
            Assert.True(resultado);
        }
    }
}