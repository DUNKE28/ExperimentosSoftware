using System;
using Smartpark.Domain;

namespace Smartpark.Repository.DTO
{
    public class IngresoViewModel
    {
        public int Id {get;set;}
        public string Placa{get;set;}
        public string Espacio{get;set;}
        public string NombreCajero{get;set;}
        public  DateTime HInicio{get;set;}

    }
}