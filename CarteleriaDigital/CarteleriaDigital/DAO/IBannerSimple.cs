using CarteleriaDigital.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DAO
{
    interface IBannerSimple
    {
        void Insertar(BannerSimpleDTO bsDTO);

        void Modificar(BannerSimpleDTO bsDTO);

        void Eliminar(short id);
    }
}
