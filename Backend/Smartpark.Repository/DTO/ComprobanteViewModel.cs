using System;

namespace Smartpark.Repository.DTO
{
    public class ComprobanteViewModel
    {
        public int Id {get; set;}
        public DateTime horaInicio {get; set;}
        public DateTime horaFin {get; set;}
        public string parking {get; set;}
        public string espacio {get; set;}
        public double monto {get; set;}
    }
}