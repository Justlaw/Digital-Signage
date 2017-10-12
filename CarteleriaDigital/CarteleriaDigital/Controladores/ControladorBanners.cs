using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DTO;
using CarteleriaDigital.DAO;

namespace CarteleriaDigital.Controladores
{
    public static class ControladorBanners
    {
        public static bool CrearBannerSimple(BannerSimpleDTO bs_DTO, RangoDTO rng_DTO)
        {
            Rango rng = new Rango(rng_DTO.FechaInicio, rng_DTO.FechaFin, rng_DTO.HoraInicio, rng_DTO.MinutoInicio, rng_DTO.HoraFin, rng_DTO.MinutoFin);
            BannerSimple bs = new BannerSimple(bs_DTO.Texto, true, bs_DTO.Nombre, rng);
            return bs.Guardar(bs_DTO, rng_DTO);
            
        }

        public static void CrearBannerRSS(BannerRSSDTO brss_DTO, RangoDTO rng_DTO)
        {

        }

        public static BannerSimpleDTO BuscarBannerSimple(int id)
        {
            BannerSimpleDAO bsDAO = new BannerSimpleDAO();
            return bsDAO.BuscarPorId(id);
        }

        public static BannerRSSDTO BuscarBannerRSS(int id)
        {
            BannerRSSDAO brssDAO = new BannerRSSDAO();
            return brssDAO.BuscarPorId(id);
        }

        public static RangoDTO BuscarRangoPorId(int id)
        {
            RangoDAO rngDAO = new RangoDAO();
            return rngDAO.BuscarRangoPorID(id);
        }
    }
}
