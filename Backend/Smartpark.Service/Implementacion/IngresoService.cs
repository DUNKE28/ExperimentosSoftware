using System.Collections.Generic;
using System.Linq;
using Smartpark.Domain;
using Smartpark.Repository;
using Smartpark.Repository.Context;
using Smartpark.Repository.DTO;

namespace Smartpark.Service.Implementacion
{
    public class IngresoService : IIngresoService
    {
        private IIngresoRepository ingresorepository;
        private IEspacioRepository espacioRepository;
        private ApplicationDbContext context;
        public IngresoService(IIngresoRepository ingresoRepository)
        {
            this.ingresorepository=ingresoRepository;
        }
        public IngresoService(IIngresoRepository ingresoRepository, IEspacioRepository espacioRepository, ApplicationDbContext context){
            this.ingresorepository=ingresoRepository;
            this.espacioRepository=espacioRepository;
            this.context=context;
        }
        public bool Delete(int id)
        {
            return ingresorepository.Delete(id);
        }

        public Ingreso Get(int id)
        {
            return ingresorepository.Get(id);
        }

        public IEnumerable<Ingreso> GetAll()
        {
            return ingresorepository.GetAll();
        }

        public IEnumerable<IngresoViewModel> Getall(int idPark)
        {
            return ingresorepository.Getall(idPark);
        }

        public IEnumerable<Ingreso> GetByParking(int idPark)
        {
            return ingresorepository.GetByParking(idPark);
        }

        public bool Save(Ingreso entity)
        {
            var espacio = context.Espacios.Single(x=>x.Id==entity.EspacioId);
            espacio.Disponibilidad_espacio = false;
            espacioRepository.Update(espacio);
            return ingresorepository.Save(entity);
        }

        public bool Update(Ingreso entity)
        {
            return ingresorepository.Update(entity);
        }
    }
}