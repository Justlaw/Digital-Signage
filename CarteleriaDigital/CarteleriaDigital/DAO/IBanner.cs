using CarteleriaDigital.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DAO
{
    interface IBanner 
       
    {
        void Insertar(BannerDTO ban);

        void Modificar(BannerDTO ban);

        BannerDTO BuscarPorNombre(String pNombre);

        List<BannerDTO> ListarPorActivo(Boolean pActivo);

        List<BannerDTO> ListarPorFecha(DateTime pFechaIni, DateTime pFechaFin);
    }
}
