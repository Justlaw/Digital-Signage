using CarteleriaDigital.DAO;
using CarteleriaDigital.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital
{
    abstract class Banner
    {
        public Boolean iActivo;
        public String iNombre;
        public String iTipo;
        public Rango iRango;


#region Accesores
        public Boolean Activo
        {
            get { return this.iActivo; }
            set { this.iActivo = value; }
        }

        public String Nombre
        {
            get { return this.Nombre; }
            set { this.iNombre = value; }
        }

        public String Tipo
        {
            get { return this.iTipo; }
            set { this.iTipo = value; }
        }

        public Rango Rango
        {
            get { return this.iRango; }
            set { iRango = value; }
        }

#endregion

   /*     /// <summary>
        /// Busca si existe un banner que deba pasarse actualmente. Si lo hace, devuelve el texto a deslizar, sino devuelve null.
        /// </summary>
        public String TextoADeslizar
        {
            get
            {
                RangoDAO rngDAO = new RangoDAO();
                DateTime hoy = DateTime.Today;
                foreach (RangoDTO rango in rngDAO.RangosBanners())
                {
                    if (
                        (hoy.Date >= rango.FechaInicio.Date && hoy.Date <= rango.FechaFin.Date) &&
                        (hoy.Hour >= rango.HoraInicio && hoy.Hour <= rango.HoraFin) &&
                        (hoy.Minute >= rango.MinutoInicio && hoy.Minute <= rango.MinutoFin)
                       )
                    {
                        BannerDAO bDAO = new BannerDAO();
                        foreach (BannerDTO banner in bDAO.ListarPorActivo(true))
                        {
                            if (rango.IdRango == banner.IdRango)
                            {
                                if (banner.Tipo = "simple")
                                BannerSimpleDAO bsDAO = new BannerSimpleDAO();
                                BannerSimpleDTO bsDTO = bsDAO.BuscarPorId(banner.IdBanner);
                                if (bsDTO == null)
                                {
                                    BannerRSSDAO brssDAO = new BannerRSSDAO();
                                    BannerRSS brss = new BannerRSS(brssDAO.BuscarPorId(banner.IdBanner), new Rango(rango));
                                    return brss.TextoADeslizar;
                                }
                                else { return bsDTO.Texto; }
                            }
                        }
                    }
                }
                return null;
            } */
        }
    }

