using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DAO;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital
{
    class BannerSimple : Banner
    {
        private String iText;

        public BannerSimple(String pText, Boolean pActivo, String pNombre, Rango pRango)
        {
            this.iActivo = pActivo;
            this.iNombre = pNombre;
            this.iText = pText;
            this.iRango = pRango;
        }

        public BannerSimple() { }

        #region Accesores
        public Boolean Activo
        {
            get { return this.iActivo; }
            set { this.iActivo = value; }
        }

        public String Nombre
        {
            get { return this.iNombre; }
            set { this.iNombre = value; }
        }

        public String Text
        {
            get { return this.iText; }
            set { this.iText = value; }
        }

        public Rango Rango
        {
            get { return this.iRango; }
            set { iRango = value; }
        }
        #endregion

        public bool Guardar(BannerSimpleDTO bs_DTO, RangoDTO rng_DTO)
        {
            BannerSimpleDAO bs_DAO = new BannerSimpleDAO();
            BannerDAO b_DAO = new BannerDAO();
            RangoDAO rng_DAO = new RangoDAO();

            BannerDTO b_DTO = new BannerDTO();
            b_DTO.Nombre = bs_DTO.Nombre;

            Rango rng = new Rango(rng_DTO.FechaInicio, rng_DTO.FechaFin, rng_DTO.HoraInicio, rng_DTO.HoraFin);

            //Se controla que el rango esté disponible
            if (rng.RangoDisponibleBanner())
            {
                rng_DAO.Insertar(rng_DTO);

                b_DTO.IdRango = rng_DAO.ObtenerUltimoId();
                b_DAO.Insertar(b_DTO);


                bs_DTO.IdBanner = b_DAO.ObtenerUltimoId();
                bs_DAO.Insertar(bs_DTO);

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
