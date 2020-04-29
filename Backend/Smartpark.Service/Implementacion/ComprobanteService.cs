using System;
using System.Collections.Generic;
using System.Linq;
using Smartpark.Domain;
using Smartpark.Repository;
using Smartpark.Repository.Context;
using Smartpark.Repository.DTO;

namespace Smartpark.Service.Implementacion
{
    public class ComprobanteService : IComprobanteService
    {
        private IComprobanteRepository comprobanteRepository;
        private ApplicationDbContext context;
        private IEspacioRepository espacioRepository;
        public ComprobanteService(IComprobanteRepository comprobanteRepository, ApplicationDbContext context, IEspacioRepository espacioRepository)
        {
            this.comprobanteRepository=comprobanteRepository;
            this.context = context;
            this.espacioRepository = espacioRepository;
        }
        public bool Delete(int id)
        {
            return comprobanteRepository.Delete(id);
        }

        public Comprobante Get(int id)
        {
            return comprobanteRepository.Get(id);
        }

        public IEnumerable<Comprobante> GetAll()
        {
            return comprobanteRepository.GetAll();
        }

        public IEnumerable<ComprobanteViewModel> Getall()
        {
            return comprobanteRepository.Getall();
        }

        public bool Save(Comprobante entity)
        {
            entity.horaFin = DateTime.Now;
            var ingreso = context.Ingresos.Single(x=>x.Id==entity.cod_ingreso);
            var tarifa = context.Tarifas.Single(x=>x.Id==ingreso.TarifaId);
            var espacio = espacioRepository.Get(ingreso.EspacioId);

            if (entity.horaFin.Subtract(ingreso.HInicio).Minutes <= 30){
                entity.monto = tarifa.Monto/2;
            } else{
                entity.monto = ((entity.horaFin.Subtract(ingreso.HInicio).Minutes)*tarifa.Monto)/60;
            }

            espacio.Disponibilidad_espacio = true;

            espacioRepository.Update(espacio);

            return comprobanteRepository.Save(entity);
        }

        public bool Update(Comprobante entity)
        {
            return comprobanteRepository.Update(entity);
        }
    }
}