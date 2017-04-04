using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.Controladores
{
    public static class ControladorBanners
    {
        public static void CrearBannerSimple(BannerSimpleDTO bs_DTO, RangoDTO rng_DTO)
        {
            Rango rng = new Rango(rng_DTO.FechaInicio, rng_DTO.FechaFin, rng_DTO.HoraInicio, rng_DTO.HoraFin);
            BannerSimple bs = new BannerSimple(bs_DTO.Texto, true, bs_DTO.Nombre, rng);
            bs.Guardar(bs_DTO, rng_DTO);
        }

        public static void CrearBannerRSS(BannerRSSDTO brss_DTO, RangoDTO rng_DTO)
        {

        }
    }
}
