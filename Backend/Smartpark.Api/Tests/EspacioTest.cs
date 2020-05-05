using System.Collections.Generic;
using System.Linq;
using Moq;
using Smartpark.Domain;
using Smartpark.Repository;
using Smartpark.Service;
using Smartpark.Service.Implementacion;
using Xunit;

namespace Smartpark.Api.Tests
{
    public class EspacioTest
    {
        [Fact]
        public void SaveEspacio_True()
        {
            Espacio espacio = new Espacio();
            var mockEspacioRepository = new Mock<IEspacioRepository>();
            mockEspacioRepository.Setup(sp => sp.Save(espacio)).Returns(true);
            IEspacioService espacioService = new EspacioService(mockEspacioRepository.Object);
            
            var resultado = espacioService.Save(espacio);
            Assert.True(resultado);
        }
        [Fact]
        public void UpdateEspacio_True()
        {
            Espacio espacio = new Espacio();
            var mockEspacioRepository = new Mock<IEspacioRepository>();
            mockEspacioRepository.Setup(sp => sp.Update(espacio)).Returns(true);
            IEspacioService espacioService = new EspacioService(mockEspacioRepository.Object);
            
            var resultado = espacioService.Update(espacio);
            Assert.True(resultado);
        }
        [Theory]
        [InlineData(1)]
        public void GetByIdEspacio_True(int id)
        {
            Espacio espacio = new Espacio();
            espacio.Id = id;
            var mockEspacioRepository = new Mock<IEspacioRepository>();
            mockEspacioRepository.Setup(sp => sp.Get(id)).Returns(espacio);
            IEspacioService espacioService = new EspacioService(mockEspacioRepository.Object);
            
            var resultado = espacioService.Get(id);
            Assert.Equal(1, resultado.Id);
        }
        [Fact]
        public void GetAllEpacio_True()
        {
            List<Espacio> auxList = new List<Espacio>();
            Espacio esp = new Espacio();
            auxList.Add(esp);
            IEnumerable<Espacio> espacios = auxList;
            var mockEspacioRepository = new Mock<IEspacioRepository>();
            mockEspacioRepository.Setup(sp => sp.GetAll()).Returns(espacios);
            IEspacioService espacioService = new EspacioService(mockEspacioRepository.Object);
            
            var resultado = espacioService.GetAll();
            Assert.NotEmpty(resultado);
        }
        [Theory]
        [InlineData(1)]
        public void DeleteEspacio_True(int id)
        {
            var mockEspacioRepository = new Mock<IEspacioRepository>();
            mockEspacioRepository.Setup(sp => sp.Delete(id)).Returns(true);
            IEspacioService espacioService = new EspacioService(mockEspacioRepository.Object);
            
            var resultado = espacioService.Delete(id);
            Assert.True(resultado);
        }
        [Theory]
        [InlineData(1)]
        public void GetByIdPark_True(int id)
        {
            List<Espacio> auxList = new List<Espacio>();
            Espacio espacio = new Espacio();

            espacio.id_parking = id;
            auxList.Add(espacio);
            IEnumerable<Espacio> espacios = auxList;

            var mockEspacioRepository = new Mock<IEspacioRepository>();
            mockEspacioRepository.Setup(sp => sp.GetByIdPark(id)).Returns(espacios);
            IEspacioService espacioService = new EspacioService(mockEspacioRepository.Object);
            
            var resultado = espacioService.GetByIdPark(id);

            Assert.NotEmpty(resultado);
        }
    }
}