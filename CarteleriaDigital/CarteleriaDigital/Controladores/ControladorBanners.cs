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

        public static string ObtenerTextoActual()
        {
            BannerDAO bDAO = new BannerDAO();
            BannerDTO bDTO = bDAO.ObtenerActual(DateTime.Now);
            if (bDTO == null)
            {
                return null;
            }
            else
            {
                if (bDTO.Tipo == "rss")
                {
                    BannerRSSDAO brssDAO = new BannerRSSDAO();
                    BannerRSSDTO brssDTO = brssDAO.BuscarPorId(bDTO.IdBanner);
                    BannerRSS brss = new BannerRSS(brssDTO, null);

                    String texto = brss.ObtenerTitulos();
                    if (texto != null)
                    {
                        brssDTO.TextoDeRespaldo = texto;
                        brssDAO.Modificar(brssDTO);
                    }

                    return texto;

                }
                else //if (bDTO.Tipo == "simple")
                {
                    BannerSimpleDAO bsDAO = new BannerSimpleDAO();
                    BannerSimpleDTO bsDTO = bsDAO.BuscarPorId(bDTO.IdBanner);
                    BannerSimple bs = new BannerSimple(bsDTO, null);
                    return bs.Texto;
                }
            }
        }

        public static void EliminarBanner(short idBanner)
        {
            BannerDAO bDAO = new BannerDAO();
            BannerDTO bDTO = bDAO.BuscarPorId(idBanner);
            if (bDTO.Tipo == "rss")
            {
                BannerRSSDAO brssDAO = new BannerRSSDAO();
                brssDAO.Eliminar(idBanner);
            }
            if (bDTO.Tipo == "simple")
            {
                BannerSimpleDAO bsDAO = new BannerSimpleDAO();
                bsDAO.Eliminar(idBanner);
            }
            bDAO.Eliminar(idBanner);
            RangoDAO rngDAO = new RangoDAO();
            rngDAO.Eliminar(bDTO.IdRango);
            

        }
    }
}