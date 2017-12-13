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
            Rango rng = new Rango(rng_DTO);
            BannerSimple bs = new BannerSimple(bs_DTO, rng);
            return bs.Guardar(bs_DTO, rng_DTO);
        }

        public static bool CrearBannerRSS(BannerRSSDTO brss_DTO, RangoDTO rng_DTO)
        {
            Rango rng = new Rango(rng_DTO);
            BannerRSS brss = new BannerRSS(brss_DTO, rng);
            return brss.Guardar(brss_DTO, rng_DTO);
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

        public static void ModificarBannerSimple(BannerSimpleDTO bsDTO, RangoDTO rngDTO)
        {
            RangoDAO rDAO = new RangoDAO();
            BannerDAO bDAO = new BannerDAO();
            BannerSimpleDAO bsDAO = new BannerSimpleDAO();

            BannerDTO bDTO = new BannerDTO()
            {
                IdBanner = bsDTO.IdBanner,
                Nombre = bsDTO.Nombre,
                Tipo = "simple"
            };

            rDAO.Modificar(rngDTO);
            bDAO.Modificar(bDTO);
            bsDAO.Modificar(bsDTO);
        }

        public static void ModificarBannerRSS(BannerRSSDTO brssDTO, RangoDTO rngDTO)
        {
            RangoDAO rDAO = new RangoDAO();
            BannerDAO bDAO = new BannerDAO();
            BannerRSSDAO brssDAO = new BannerRSSDAO();

            BannerDTO bDTO = new BannerDTO()
            {
                IdBanner = brssDTO.IdBanner,
                Nombre = brssDTO.Nombre,
                Tipo = "rss"
            };

            rDAO.Modificar(rngDTO);
            bDAO.Modificar(bDTO);
            brssDAO.Modificar(brssDTO);
        }
    }
}
