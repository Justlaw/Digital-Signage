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

        BannerDTO BuscarPorId(short id);

        List<BannerDTO> ListarPorActivo(Boolean pActivo);

        List<BannerDTO> ListarPorFecha(DateTime pFechaIni, DateTime pFechaFin);

        void Eliminar(short id);
    }
}
