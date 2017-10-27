using CarteleriaDigital.DAO;
using CarteleriaDigital.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital
{
    class BannerRSS : Banner
    {
        private String iURL;
        public BannerRSS() { }

        public BannerRSS(String pURL, Boolean pActivo, String pNombre, Rango pRango)
        {
            this.iActivo = pActivo;
            this.iNombre = pNombre;
            this.iURL = pURL;
            this.iRango = pRango;
        }

        #region Accesores

        public Boolean Activo
        {
            get { return this.iActivo; }
            set { this.iActivo = value; }
        }

        public String URL
        {
            get { return this.iURL; }
            set { this.iURL = value; }
        }

        public String Nombre
        {
            get { return this.iNombre; }
            set { this.iNombre = value; }
        }

        public Rango Rango
        {
            get { return this.iRango; }
            set { this.iRango = value; }
        }

        #endregion

        public bool Guardar(BannerRSSDTO brss_DTO, RangoDTO rng_DTO)
        {
            BannerRSSDAO brss_DAO = new BannerRSSDAO();
            BannerDAO b_DAO = new BannerDAO();
            RangoDAO rng_DAO = new RangoDAO();

            BannerDTO b_DTO = new BannerDTO();
            b_DTO.Nombre = brss_DTO.Nombre;

            Rango rng = new Rango(rng_DTO.FechaInicio, rng_DTO.FechaFin, rng_DTO.HoraInicio, rng_DTO.MinutoInicio, rng_DTO.HoraFin, rng_DTO.MinutoFin);

            //Se controla que el rango esté disponible
            if (rng.RangoDisponibleBanner())
            {
                rng_DAO.Insertar(rng_DTO);

                b_DTO.IdRango = rng_DAO.ObtenerUltimoId();
                b_DAO.Insertar(b_DTO);


                brss_DTO.IdBanner = b_DAO.ObtenerUltimoId();
                brss_DAO.Insertar(brss_DTO);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
