using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DAO;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital
{
    public class Rango
    {
        private DateTime iFechaInicio;
        private DateTime iFechaFin;
        private short iHoraInicio;
        private short iMinutoInicio;
        private short iHoraFin;
        private short iMinutoFin;

        public Rango(DateTime pFechaInicio, DateTime pFechaFin, short pHoraInicio, short pMinutoInico, short pHoraFin, short pMinutoFin)
        {
            this.iFechaInicio = pFechaInicio;
            this.iFechaFin = pFechaFin;
            this.iHoraInicio = pHoraInicio;
            this.iMinutoInicio = pMinutoInico;
            this.iHoraFin = pHoraFin;
            this.iMinutoFin = pMinutoFin;
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

        public short HoraInicio
        {
            get { return this.iHoraInicio; }
            set { iHoraInicio = value; }
        }

        public short MinutoInicio
        {
            get { return this.iMinutoInicio; }
            set { iMinutoInicio = value; }
        }

        public short HoraFin
        {
            get { return this.iHoraFin; }
            set { iHoraFin = value; }
        }

        public short MinutoFin
        {
            get { return this.iMinutoFin; }
            set { iMinutoFin = value; }
        }
        #endregion 

        /// <summary>
        /// Devuelve verdadero o falso según el rango esté disponible para agregar un banner
        /// </summary>
        /// <returns></returns>
        public bool RangoDisponibleBanner()
        {
            bool result = true;
            RangoDAO rng_DAO = new RangoDAO();
            List<RangoDTO> lista = rng_DAO.RangosBanners();
            foreach (RangoDTO rango in lista)
            {
                if (iFechaInicio >= rango.FechaInicio && iFechaInicio <= rango.FechaFin)
                {
                    if (
                        iHoraInicio >= rango.HoraInicio && iHoraInicio <= rango.HoraFin
                        && iMinutoInicio >= rango.MinutoInicio && iMinutoInicio <= rango.MinutoFin
                        )
                    {
                        result = false;
                        return result;
                    }
                }
            }

            return result;

        }

        /// <summary>
        /// Devuelve verdadero o falso según el rango esté disponible para agregar una campña
        /// </summary>
        /// <returns></returns>
        public bool RangoDisponibleCampaña()
        {
            bool result = true;
            RangoDAO rng_DAO = new RangoDAO();
            List<RangoDTO> lista = rng_DAO.RangosCampañas();
            foreach (RangoDTO rango in lista)
            {
                if (iFechaInicio >= rango.FechaInicio && iFechaInicio <= rango.FechaFin)
                {
                    if (
                        iHoraInicio >= rango.HoraInicio && iHoraInicio <= rango.HoraFin
                        && iMinutoInicio >= rango.MinutoInicio && iMinutoInicio <= rango.MinutoFin
                        )
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
