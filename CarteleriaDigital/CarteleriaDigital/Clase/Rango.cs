using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DAO;
using CarteleriaDigital.DTO;

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

        #region Accesores
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
        #endregion 

        public bool RangoDisponible()
        {
            bool result = true;
            RangoDAO rng_DAO = new RangoDAO();
            foreach (RangoDTO rango in rng_DAO.RangosBanners())
            {
                if (iFechaInicio >= rango.FechaInicio && iFechaInicio <= rango.FechaFin)
                {
                    if (iHoraInicio >= rango.HoraInicio && iHoraInicio <= rango.HoraFin)
                    {
                        result = false;
                        return result;
                    }
                }
            }

            return result;

        }
    }
}
