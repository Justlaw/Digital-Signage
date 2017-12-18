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

        public Rango(DateTime pFechaInicio, DateTime pFechaFin, short pHoraInicio, short pMinutoInicio, short pHoraFin, short pMinutoFin)
        {
            this.iFechaInicio = pFechaInicio;
            this.iFechaFin = pFechaFin;
            this.iHoraInicio = pHoraInicio;
            this.iMinutoInicio = pMinutoInicio;
            this.iHoraFin = pHoraFin;
            this.iMinutoFin = pMinutoFin;
        }

        public Rango(RangoDTO rngDTO)
        {
            this.iFechaInicio = rngDTO.FechaInicio;
            this.iFechaFin = rngDTO.FechaFin;
            this.iHoraInicio = rngDTO.HoraInicio;
            this.iMinutoInicio = rngDTO.MinutoInicio;
            this.iHoraFin = rngDTO.HoraFin;
            this.iMinutoFin = rngDTO.MinutoFin;
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

        private bool EstaDisponible(List<RangoDTO> listaRangos, RangoDTO rng_DTO)
        {
            foreach (RangoDTO rango in listaRangos)
            {
                if ((rng_DTO.FechaInicio.Date >= rango.FechaInicio.Date && rng_DTO.FechaInicio.Date < rango.FechaFin.Date) ||
                    (rng_DTO.FechaFin.Date >= rango.FechaInicio.Date && rng_DTO.FechaFin.Date < rango.FechaFin.Date))
                {
                    if (
                        rng_DTO.HoraInicio >= rango.HoraInicio && rng_DTO.HoraInicio < rango.HoraFin
                        && rng_DTO.MinutoInicio >= rango.MinutoInicio && rng_DTO.MinutoInicio < rango.MinutoFin
                        )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Devuelve verdadero o falso según el rango esté disponible para agregar un banner
        /// </summary>
        /// <returns></returns>
        public bool RangoDisponibleBanner(RangoDTO rng_DTO)
        {
            RangoDAO rng_DAO = new RangoDAO();
            List < RangoDTO > lista = rng_DAO.RangosBanners();
            bool disp = EstaDisponible(lista, rng_DTO);
            return disp;
        }

        /// <summary>
        /// Devuelve verdadero o falso según el rango esté disponible para agregar una campña
        /// </summary>
        /// <returns></returns>
        public bool RangoDisponibleCampaña(RangoDTO rng_DTO)
        {
            RangoDAO rng_DAO = new RangoDAO();
            List<RangoDTO> lista = rng_DAO.RangosCampañas();
            bool disp = EstaDisponible(lista, rng_DTO);
            return disp;
        }
    }
}
