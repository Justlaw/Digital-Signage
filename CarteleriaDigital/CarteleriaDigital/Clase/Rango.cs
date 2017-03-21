using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital
{
    class Rango
    {
        private DateTime iFechaInicio;
        private DateTime iFechaFin;
        private DateTime iHoraInicio;
        private DateTime iHoraFin;

        public Rango(DateTime pFechaInicio, DateTime pFechaFin, DateTime pHoraInicio, DateTime pHoraFin)
        {
            this.iFechaInicio = pFechaInicio;
            this.iFechaFin = pFechaFin;
            this.iHoraInicio = pHoraInicio;
            this.iHoraFin = pHoraFin;
        }

        public DateTime FechaInicio
        {
            get { return this.iFechaInicio; }
            set { iFechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return this.iFechaFin; }
            set { iFechaFin = value; }
        }

        public DateTime HoraInicio
        {
            get { return this.iHoraInicio; }
            set { iHoraInicio = value; }
        }

        public DateTime HoraFin
        {
            get { return this.iHoraFin; }
            set { iHoraFin = value; }
        }

    }
}
